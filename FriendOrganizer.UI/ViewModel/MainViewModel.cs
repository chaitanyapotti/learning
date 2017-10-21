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
        private readonly IFriendDataService _friendDataService;
        private Friend _selectedFriend;
        #endregion

        #region props
        public ObservableCollection<Friend> Friends { get; set; } = new ObservableCollection<Friend>();


        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region ctor
        public MainViewModel(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
        }

        #endregion

        #region methods

        public void Load()
        {
            //var friends = _friendDataService.GetAll();
            var friends = _friendDataService.GetAll();

            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        public async Task LoadAsync()
        {
            //var friends = _friendDataService.GetAll();
            var friends = await _friendDataService.GetAllAsync();

            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        #endregion

    }
}
