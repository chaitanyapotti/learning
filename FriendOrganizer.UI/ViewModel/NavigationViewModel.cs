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
        private readonly IMeetingLookupDataService _meetingLookupDataService;
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IMeetingLookupDataService meetingLookupDataService,  IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _meetingLookupDataService = meetingLookupDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(OnDetailSaved);

            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe((args) =>
                {
                    switch (args.ViewModelName)
                    {
                        case nameof(FriendDetailViewModel):
                            RemoveDetail(Friends, args);
                            break;
                        case nameof(MeetingDetailViewModel):
                            RemoveDetail(Meetings, args);
                            break;
                    }
                   
                });
        }

        private void RemoveDetail(ObservableCollection<NavigationItemViewModel> items, AfterDetailDeletedEventArgs args)
        {
            var deletedFriend = items.SingleOrDefault(x => x.Id == args.Id);
            items.Remove(deletedFriend);
        }

        private void OnDetailSaved(AfterDetailSavedEventArgs args)
        {
            switch (args.ViewModelName)
            {
                case nameof(FriendDetailViewModel):
                    AfterDetailSaved(Friends, args);
                    break;
                case nameof(MeetingDetailViewModel):
                    AfterDetailSaved(Meetings, args);
                    break;

            }
        }

        private void AfterDetailSaved(ObservableCollection<NavigationItemViewModel> items,  AfterDetailSavedEventArgs args)
        {
            var lookupItem = items.SingleOrDefault(x => x.Id == args.Id);
            if (lookupItem != null)
                lookupItem.DisplayMember = args.DisplayMember;
            else
            {
                items.Add(new NavigationItemViewModel(args.Id, args.DisplayMember, args.ViewModelName, _eventAggregator));
            }
        }

        public async Task LoadDataAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var lookupItem in lookup)
            {
                Friends.Add(new NavigationItemViewModel(lookupItem.Id, lookupItem.DisplayMember, nameof(FriendDetailViewModel), _eventAggregator));
            }

            var lookupMeetings = await _meetingLookupDataService.GetMeetingLookupAsync();
            Meetings.Clear();
            foreach (var lookupItem in lookupMeetings)
            {
                Meetings.Add(new NavigationItemViewModel(lookupItem.Id, lookupItem.DisplayMember, nameof(MeetingDetailViewModel), _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; } = new ObservableCollection<NavigationItemViewModel>();
        public ObservableCollection<NavigationItemViewModel> Meetings { get; } = new ObservableCollection<NavigationItemViewModel>();


    }
}
