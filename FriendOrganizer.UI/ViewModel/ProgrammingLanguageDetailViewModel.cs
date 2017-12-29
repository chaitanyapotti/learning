using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.View.Service;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class ProgrammingLanguageDetailViewModel : DetailViewModelBase
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private ProgrammingLanguageWrapper _selectedProgrammingLanguage;

        public ProgrammingLanguageDetailViewModel(IEventAggregator eventAggregator, IProgrammingLanguageRepository programmingLanguageRepository , IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            Title = "Programming Languages";
            ProgrammingLanguages = new ObservableCollection<ProgrammingLanguageWrapper>();

            AddCommand = new DelegateCommand(OnAddLanguageExecute);
            RemoveCommand = new DelegateCommand(OnRemoveLanguageExecute, OnRemoveLanguageCanExecute);
        }

        public ObservableCollection<ProgrammingLanguageWrapper> ProgrammingLanguages { get; set; }

        public ProgrammingLanguageWrapper SelectedProgrammingLanguage
        {
            get { return _selectedProgrammingLanguage; }
            set
            {
                _selectedProgrammingLanguage = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        protected override void OnDeleteExecute()
        {
            throw new NotImplementedException();
        }

        private bool OnRemoveLanguageCanExecute()
        {
            return SelectedProgrammingLanguage != null;
        }

        private async void OnRemoveLanguageExecute()
        {
            if (await _programmingLanguageRepository.IsReferencedByFriendAsync(SelectedProgrammingLanguage.Id))
            {
                await _messageDialogService.ShowInfoDialog($"The language {SelectedProgrammingLanguage.Id} can't be referenced because it is referenced by at least one friend");
                return;
            }

            SelectedProgrammingLanguage.PropertyChanged -= Wrapper_PropertyChanged;
            _programmingLanguageRepository.Delete(SelectedProgrammingLanguage.Model);
            ProgrammingLanguages.Remove(SelectedProgrammingLanguage);
            SelectedProgrammingLanguage = null;
            HasChanges = _programmingLanguageRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void OnAddLanguageExecute()
        {
            var wrapper = new ProgrammingLanguageWrapper(new ProgrammingLanguage());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;
            ProgrammingLanguages.Add(wrapper);
            _programmingLanguageRepository.Add(wrapper.Model);
            wrapper.Name = "";
        }

        protected override bool OnSaveCanExecute() => HasChanges && ProgrammingLanguages.All(x => !x.HasErrors);

        protected override async void OnSaveExecute()
        {
            try
            {
                await _programmingLanguageRepository.SaveAsync();
                HasChanges = _programmingLanguageRepository.HasChanges();
                RaiseCollectionSavedEvent();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                    e = e.InnerException;

                await _messageDialogService.ShowInfoDialog("Error While saving entities. Data will be reloaded. Details: "+ e.Message);
                await LoadAsync(Id);
            }
        }

        public override async Task LoadAsync(int id)
        {
            Id = id;
            foreach (var programmingLanguageWrapper in ProgrammingLanguages)
            {
                programmingLanguageWrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }
            ProgrammingLanguages.Clear();

            var languages = await _programmingLanguageRepository.GetAllAsync();

            foreach (var programmingLanguage in languages)
            {
                var wrapper = new ProgrammingLanguageWrapper(programmingLanguage);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                ProgrammingLanguages.Add(wrapper);
            }

        }

        private void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges) HasChanges = _programmingLanguageRepository.HasChanges();

            if(e.PropertyName == nameof(ProgrammingLanguageWrapper.HasErrors)) ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
    }
}
