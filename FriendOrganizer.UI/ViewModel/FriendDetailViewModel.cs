using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Service;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IProgrammingLanguageLookupDataService _programmingLanguageLookupDataService;
        private FriendWrapper _friend;

        public FriendDetailViewModel(IFriendRepository friendRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService,
            IProgrammingLanguageLookupDataService programmingLanguageLookupDataService)
        {
            _friendRepository = friendRepository;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _programmingLanguageLookupDataService = programmingLanguageLookupDataService;
            PhoneNumbers = new ObservableCollection<FriendPhoneNumberWrapper>();
            ProgrammingLanguages = new ObservableCollection<LookupItem>();
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);

            AddPhoneNumberCommand = new DelegateCommand(OnAddPhoneNumberExecute);
            RemovePhoneNumberCommand = new DelegateCommand(OnRemovePhoneNumberExecute, OnRemovePhoneNumberCanExecute);
        }

        private void OnRemovePhoneNumberExecute()
        {
            SelectedPhoneNumber.PropertyChanged -= FriendPhoneNumberOnPropertyChanged;
            PhoneNumbers.Remove(SelectedPhoneNumber);
            _friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            SelectedPhoneNumber = null;
            HasChanges = _friendRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private bool OnRemovePhoneNumberCanExecute() => SelectedPhoneNumber != null;

        private void OnAddPhoneNumberExecute()
        {
            var newNumber =  new FriendPhoneNumberWrapper(new FriendPhoneNumber());
            newNumber.PropertyChanged += FriendPhoneNumberOnPropertyChanged;

            PhoneNumbers.Add(newNumber);
            _friendRepository.AddPhoneNumber(newNumber.Model);
            newNumber.Number = "";
        }

        public ObservableCollection<LookupItem> ProgrammingLanguages { get; }

        public ObservableCollection<FriendPhoneNumberWrapper> PhoneNumbers { get; }

        private FriendPhoneNumberWrapper _selectedPhoneNumber;

        public FriendPhoneNumberWrapper SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value;
                OnPropertyChanged();
                ((DelegateCommand)RemovePhoneNumberCommand).RaiseCanExecuteChanged();
            }
        }



        private async void OnDeleteExecute()
        {
            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete {Friend.FirstName} {Friend.LastName} ?", "Question");
            if (result == MessageDialogResult.Ok)
            {
                _friendRepository.Delete(Friend.Model);
                await _friendRepository.SaveAsync();

                _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Publish(Friend.Id);
            }
        }

        public async Task LoadAsync(int? friendId)
        {
            var friend = friendId.HasValue ? await _friendRepository.GetFriendByIdAsync(friendId.Value) : CreateNewFriend();
            InitializeFriend(friend);

            IntializeFriendPhoneNumbers(friend.PhoneNumbers);

            await LoadProgrammingLanguagesLookupAsync();
        }

        private void IntializeFriendPhoneNumbers(ICollection<FriendPhoneNumber> friendPhoneNumbers)
        {
            foreach (var friendPhoneNumber in PhoneNumbers)
            {
                friendPhoneNumber.PropertyChanged -= FriendPhoneNumberOnPropertyChanged;
            }
            PhoneNumbers.Clear();

            foreach (var friendPhoneNumber in friendPhoneNumbers)
            {
                var wrapper = new FriendPhoneNumberWrapper(friendPhoneNumber);
                PhoneNumbers.Add(wrapper);
                wrapper.PropertyChanged += FriendPhoneNumberOnPropertyChanged;

            }
        }

        private void FriendPhoneNumberOnPropertyChanged(object o, PropertyChangedEventArgs e)
        {
            if (!HasChanges) HasChanges = _friendRepository.HasChanges();
            if(e.PropertyName.Equals(nameof(FriendPhoneNumberWrapper.HasErrors))) ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void InitializeFriend(Friend friend)
        {
            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += (sender, args) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _friendRepository.HasChanges();
                }
                if (args.PropertyName == nameof(Friend.HasErrors)) ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Friend.Id == 0)
            {
                Friend.FirstName = "";
            }
        }

        private async Task LoadProgrammingLanguagesLookupAsync()
        {
            ProgrammingLanguages.Clear();
            ProgrammingLanguages.Add(new NullLookupItem() { DisplayMember = "-" });
            var lookup = await _programmingLanguageLookupDataService.GetProgrammingLanguageLookupAsync();
            foreach (var lookupItem in lookup)
            {
                ProgrammingLanguages.Add(lookupItem);
            }
        }

        private Friend CreateNewFriend()
        {
            var friend = new Friend();
            _friendRepository.Add(friend);
            return friend;
        }

        public FriendWrapper Friend
        {
            get => _friend;
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        private bool _hasChanges;

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


        public ICommand SaveCommand { get; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddPhoneNumberCommand { get; set; }

        public ICommand RemovePhoneNumberCommand { get; set; }



        private bool OnSaveCanExecute()
        {
            return Friend != null && !Friend.HasErrors && HasChanges && PhoneNumbers.All(x => !x.HasErrors);
        }

        private async void OnSaveExecute()
        {
            await _friendRepository.SaveAsync();
            HasChanges = _friendRepository.HasChanges();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(new AfterFriendSavedEventArgs() { Id = Friend.Id, DisplayMember = Friend.FirstName + " " + Friend.LastName });
        }




    }
}
