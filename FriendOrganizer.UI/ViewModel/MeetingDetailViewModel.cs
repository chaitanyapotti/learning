using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Service;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class MeetingDetailViewModel : DetailViewModelBase, IMeetingDetailViewModel
    {
        private IMeetingRepository _meetingRepository;
        private MeetingWrapper _meeting;
        private Friend _selectedAddedFriend;
        private Friend _selectedAvailableFriend;
        private List<Friend> _allFriends = new List<Friend>();


        public MeetingDetailViewModel(IMessageDialogService messageDialogService, IMeetingRepository meetingRepository, IEventAggregator eventAggregator) : base(eventAggregator, messageDialogService)
        {
            _meetingRepository = meetingRepository;
            AddedFriends = new ObservableCollection<Friend>();
            AvailableFriends = new ObservableCollection<Friend>();

            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(AfterDetailSaved);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);

            AddFriendCommand = new DelegateCommand(OnAddFriendExecute, OnAddFriendCanExecute);
            RemoveFriendCommand = new DelegateCommand(OnRemoveFriendExecute, OnRemoveFriendCanExecute);

        }

        public MeetingWrapper Meeting
        {
            get { return _meeting; }
            set
            {
                _meeting = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Friend> AddedFriends { get; set; }

        public ObservableCollection<Friend> AvailableFriends { get; set; }

        public ICommand AddFriendCommand { get; set; }

        public ICommand RemoveFriendCommand { get; set; }

        public Friend SelectedAddedFriend
        {
            get { return _selectedAddedFriend; }
            set
            {
                _selectedAddedFriend = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveFriendCommand).RaiseCanExecuteChanged();

            }
        }

        public Friend SelectedAvailableFriend
        {
            get { return _selectedAvailableFriend; }
            set
            {
                _selectedAvailableFriend = value;
                OnPropertyChanged();
                ((DelegateCommand)AddFriendCommand).RaiseCanExecuteChanged();
            }
        }


        public override async Task LoadAsync(int meetingId)
        {
            var meeting = meetingId > 0 ? await _meetingRepository.GetByIdAsync(meetingId) : CreateNewMeeting();
            Id = meetingId;

            InitializeMeeting(meeting);
            _allFriends = await _meetingRepository.GetAllFriendsAsync();
            SetupPickList();

        }

        private void SetupPickList()
        {

            var meetingFriendIds = Meeting.Model.Friends.Select(x => x.Id).ToList();
            var addedFriends = _allFriends.Where(x => meetingFriendIds.Contains(x.Id)).OrderBy(x => x.FirstName).ToList();
            var availableFriends = _allFriends.Except(addedFriends).OrderBy(x => x.FirstName);

            AddedFriends.Clear();
            AvailableFriends.Clear();

            foreach (var friend in addedFriends)
            {
                AddedFriends.Add(friend);
            }

            foreach (var friend in availableFriends)
            {
                AvailableFriends.Add(friend);
            }
        }

        private void InitializeMeeting(Meeting meeting)
        {
            Meeting = new MeetingWrapper(meeting);
            Meeting.PropertyChanged += (s, e) =>
            {
                if (!HasChanges) HasChanges = _meetingRepository.HasChanges();

                if (e.PropertyName == nameof(Meeting.HasErrors)) { ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged(); }

                if (e.PropertyName == nameof(Meeting.Title))
                    SetTitle();

            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Meeting.Id == 0)
                Meeting.Title = "";

            SetTitle();

        }

        private void SetTitle()
        {
            Title = Meeting.Title;
        }

        private Meeting CreateNewMeeting()
        {
            var meeting = new Meeting() { DateTo = DateTime.Now, DateFrom = DateTime.Now };

            _meetingRepository.Add(meeting);
            return meeting;
        }

        protected override async void OnDeleteExecute()
        {
            var result = await _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the meeting {Meeting.Title}", "Question");
            if (result == MessageDialogResult.Ok)
            {
                _meetingRepository.Delete(Meeting.Model);
                await _meetingRepository.SaveAsync();
                RaiseDetailDeletedEvent(Meeting.Id);
            }
        }

        protected override bool OnSaveCanExecute() => Meeting != null && HasChanges && !Meeting.HasErrors;

        protected override async void OnSaveExecute()
        {
            await _meetingRepository.SaveAsync();
            HasChanges = _meetingRepository.HasChanges();
            Id = Meeting.Id;
            RaiseDetailSavedEvent(Meeting.Id, Meeting.Title);
        }

        private bool OnRemoveFriendCanExecute() => SelectedAddedFriend != null;

        private void OnRemoveFriendExecute()
        {
            var toAddFriend = SelectedAddedFriend;

            Meeting.Model.Friends.Remove(toAddFriend);
            AddedFriends.Remove(toAddFriend);
            AvailableFriends.Add(toAddFriend);
            HasChanges = _meetingRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private bool OnAddFriendCanExecute() => SelectedAvailableFriend != null;

        private void OnAddFriendExecute()
        {
            var toAddFriend = SelectedAvailableFriend;

            Meeting.Model.Friends.Add(toAddFriend);
            AddedFriends.Add(toAddFriend);
            AvailableFriends.Remove(toAddFriend);
            HasChanges = _meetingRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

        }

        private async void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            if (args.ViewModelName == nameof(FriendDetailViewModel))
            {
                await _meetingRepository.ReloadFriendAsync(args.Id);
                _allFriends = await _meetingRepository.GetAllFriendsAsync();
                SetupPickList();
            }
        }

        private async void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            if (args.ViewModelName == nameof(FriendDetailViewModel))
            {
                _allFriends = await _meetingRepository.GetAllFriendsAsync();
                SetupPickList();
            }
        }

    }
}
