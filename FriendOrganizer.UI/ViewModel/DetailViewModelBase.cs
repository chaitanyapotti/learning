using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Service;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public abstract class DetailViewModelBase : ViewModelBase, IDetailViewModel
    {
        protected readonly IEventAggregator _eventAggregator;
        public readonly IMessageDialogService _messageDialogService;
        private bool _hasChanges;
        private int _id;
        private string _title;

        protected DetailViewModelBase(IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);
            CloseDetailViewCommand = new DelegateCommand(OnCloseDetailViewExecute);
        }

        protected abstract void OnDeleteExecute();

        protected abstract bool OnSaveCanExecute();

        protected abstract void OnSaveExecute();

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand CloseDetailViewCommand { get; set; }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public abstract Task LoadAsync(int id);

        protected virtual void RaiseDetailSavedEvent(int modelId, string displayMember)
        {
            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Publish(new AfterDetailSavedEventArgs(){Id = modelId, ViewModelName = this.GetType().Name, DisplayMember = displayMember});
        }

        protected virtual void RaiseDetailDeletedEvent(int modelId)
        {
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Publish(new AfterDetailDeletedEventArgs() { Id = modelId, ViewModelName = this.GetType().Name });
        }

        protected virtual void RaiseCollectionSavedEvent()
        {
            _eventAggregator.GetEvent<AfterCollectionSavedEvent>().Publish(new AfterCollectionSavedEventArgs() { ViewModelName = this.GetType().Name });
        }

        protected virtual async void OnCloseDetailViewExecute()
        {
            if (HasChanges)
            {
                var result = await _messageDialogService.ShowOkCancelDialog("You've made changes. Do you still wish to close this item?", "Question");
                if (result == MessageDialogResult.Cancel) return;
            }

            _eventAggregator.GetEvent<AfterDetailViewClosedEvent>()
                .Publish(new CloseDetailViewEventArgs() {Id = Id, ViewModelName = this.GetType().Name});
        }

        protected async Task SaveWithOptimisticConcurrencyAsync(Func<Task> saveFunc, Action afterSaveAction)
        {
            try
            {
                await saveFunc();
            }
            catch (DbUpdateConcurrencyException e)
            {
                var databaseValues = e.Entries.Single().GetDatabaseValues();
                if (databaseValues == null)
                {
                    await _messageDialogService.ShowInfoDialog("The Entity has been deleted by another user");
                    RaiseDetailDeletedEvent(Id);
                    return;
                }

                var result = await _messageDialogService.ShowOkCancelDialog(
                    "The entity in the meantime has been changed by someone else. Click Ok to save your changes or Click cancel to reload the entity from database.",
                    "Question");
                if (result == MessageDialogResult.Ok)
                {
                    var entry = e.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    await saveFunc();
                }
                else
                {
                    await e.Entries.Single().ReloadAsync();
                    await LoadAsync(Id);
                }
            }

            afterSaveAction();
        }
    }
}
