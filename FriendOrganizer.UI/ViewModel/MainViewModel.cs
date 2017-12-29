using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac.Features.Indexed;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Service;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IIndex<string, IDetailViewModel> _detailViewModelCreator;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private IDetailViewModel _selectedDetailViewModel;

        #region fields
        //private readonly IFriendDataService _friendDataService;
        //private Friend _selectedFriend;
        public INavigationViewModel NavigationViewModel { get; }

        public ObservableCollection<IDetailViewModel> DetailViewModels { get; }


        public IDetailViewModel SelectedDetailViewModel
        {
            get { return _selectedDetailViewModel; }
            set
            {
                _selectedDetailViewModel = value;
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


        public ICommand CreateNewDetailCommand { get;  }

        public ICommand OpenSingleDetailCommand { get;  }


        #endregion

        #region ctor
        //public MainViewModel(IFriendDataService friendDataService)
        //{
        //    _friendDataService = friendDataService;
        //}
        public MainViewModel(INavigationViewModel navigationViewModel, IIndex<string, IDetailViewModel> detailViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            NavigationViewModel = navigationViewModel;
            _detailViewModelCreator = detailViewModelCreator;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _eventAggregator.GetEvent<OpenDetailViewEvent>().Subscribe(OnOpenDetailView);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);
            _eventAggregator.GetEvent<AfterDetailViewClosedEvent>().Subscribe(AfterDetailClosed);

            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);
            OpenSingleDetailCommand = new DelegateCommand<Type>(OnOpenSingleDetailViewExecute);

            DetailViewModels = new ObservableCollection<IDetailViewModel>();

        }

       

        private void RemoveDetailDeleted(int id, string viewModelName)
        {
            var detailViewModel = DetailViewModels.SingleOrDefault(x => x.Id == id && x.GetType().Name ==viewModelName);
            if (detailViewModel != null) DetailViewModels.Remove(detailViewModel);
        }

        private void AfterDetailClosed(CloseDetailViewEventArgs args)
        {
            RemoveDetailDeleted(args.Id, args.ViewModelName);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            RemoveDetailDeleted(args.Id, args.ViewModelName);
            //SelectedDetailViewModel = null;
        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs() { Id = nextNewItemId--,  ViewModelName = viewModelType.Name });
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

        private int nextNewItemId = 0;

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            //if (SelectedDetailViewModel != null && SelectedDetailViewModel.HasChanges)
            //{
            //    var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");
            //    if (result == MessageDialogResult.Cancel) return;

            //}

            var detailViewModel = DetailViewModels.SingleOrDefault(x => x.Id == args.Id && x.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                detailViewModel = _detailViewModelCreator[args.ViewModelName];
                try
                {
                    await detailViewModel.LoadAsync(args.Id);
                }
                catch (Exception e)
                {
                    await _messageDialogService.ShowInfoDialog("Couldn't Load the entity. Maybe it was deleted in the meantime by another user. The navigation is refreshed for you.");
                    await NavigationViewModel.LoadDataAsync();
                    return;
                }
                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;
        }

        private void OnOpenSingleDetailViewExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs() { Id = -1, ViewModelName = viewModelType.Name });

        }

        //public async Task LoadFriendByIdAsync(int friendId)
        //{
        //    await FriendDetailViewModel.LoadAsync(friendId);
        //}

        #endregion

    }
}
