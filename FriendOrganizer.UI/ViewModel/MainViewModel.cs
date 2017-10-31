using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region fields
        //private readonly IFriendDataService _friendDataService;
        //private Friend _selectedFriend;
        public INavigationViewModel NavigationViewModel { get;}

        public IFriendDetailViewModel FriendDetailViewModel { get; }

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

        #endregion

        #region ctor
        //public MainViewModel(IFriendDataService friendDataService)
        //{
        //    _friendDataService = friendDataService;
        //}
        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
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

        //public async Task LoadFriendByIdAsync(int friendId)
        //{
        //    await FriendDetailViewModel.LoadAsync(friendId);
        //}

        #endregion

    }
}
