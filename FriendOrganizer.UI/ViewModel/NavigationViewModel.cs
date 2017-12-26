using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IFriendLookupDataService _friendLookupDataService;
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe((args) =>
            {
                var lookupItem = Friends.SingleOrDefault(x => x.Id == args.Id);
                if (lookupItem != null) lookupItem.DisplayMember = args.DisplayMember;
                else
                {
                    lookupItem = new NavigationItemViewModel(args.Id, args.DisplayMember, _eventAggregator);
                }
            });

            _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Subscribe((args) =>
                {
                    var deletedFriend = Friends.SingleOrDefault(x => x.Id == args);
                    Friends.Remove(deletedFriend);
                });
        }

        public async Task LoadDataAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var lookupItem in lookup)
            {
                Friends.Add(new NavigationItemViewModel(lookupItem.Id, lookupItem.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; } = new ObservableCollection<NavigationItemViewModel>();

    }
}
