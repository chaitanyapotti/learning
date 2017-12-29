using Prism.Events;

namespace FriendOrganizer.UI.Event
{
    //int will be the friend id
    public class OpenDetailViewEvent : PubSubEvent<OpenDetailViewEventArgs>
    {

    }

    public class OpenDetailViewEventArgs
    {
        public int Id { get; set; }

        public string ViewModelName { get; set; }
    }
}
