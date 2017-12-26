using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Service;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private Func<IFriendDetailViewModel> _friendDetailViewModelCreator;
        private IFriendDetailViewModel _friendDetailViewModel;

        #region fields
        //private readonly IFriendDataService _friendDataService;
        //private Friend _selectedFriend;
        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailViewModel FriendDetailViewModel
        {
            get { return _friendDetailViewModel; }
            private set
            {
                _friendDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region props
        //public ObservableCollection<Friend> Friends { get; set; } = new ObservableCollection<Friend>();


        //public Friend SelectedFriend
        //{
        //    get { return _selectedFriend; }
        //    set
        //    {
        //        _selectedFriend = value;
        //        OnPropertyChanged();
        //    }
        //}


        public ICommand CreateNewFriendCommand { get; set; }

        #endregion

        #region ctor
        //public MainViewModel(IFriendDataService friendDataService)
        //{
        //    _friendDataService = friendDataService;
        //}
        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendDetailViewModel> friendDetailViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            NavigationViewModel = navigationViewModel;
            _friendDetailViewModelCreator = friendDetailViewModelCreator;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
            _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Subscribe(AfterFriendDeleted);

            CreateNewFriendCommand = new DelegateCommand(OnCreateNewFriendExecute);

        }

        private void AfterFriendDeleted(int friendId)
        {
            FriendDetailViewModel = null;
        }

        private void OnCreateNewFriendExecute()
        {
            OnOpenFriendDetailView(null);
        }

        #endregion

        #region methods

        //public void Load()
        //{
        //    //var friends = _friendDataService.GetAll();
        //    var friends = _friendDataService.GetAll();

        //    Friends.Clear();
        //    foreach (var friend in friends)
        //    {
        //        Friends.Add(friend);
        //    }
        //}

        public async Task LoadAsync()
        {
            ////var friends = _friendDataService.GetAll();
            //var friends = await _friendDataService.GetAllAsync();

            //Friends.Clear();
            //foreach (var friend in friends)
            //{
            //    Friends.Add(friend);
            //}
            await NavigationViewModel.LoadDataAsync();
        }

        private async void OnOpenFriendDetailView(int? friendId)
        {
            if (FriendDetailViewModel != null && FriendDetailViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");
                if (result == MessageDialogResult.Cancel) return;

            }
            FriendDetailViewModel = _friendDetailViewModelCreator();
            await FriendDetailViewModel.LoadAsync(friendId);
        }

        //public async Task LoadFriendByIdAsync(int friendId)
        //{
        //    await FriendDetailViewModel.LoadAsync(friendId);
        //}

        #endregion

    }
}
