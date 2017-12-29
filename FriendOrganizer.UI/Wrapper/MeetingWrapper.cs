using System;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Wrapper
{
    public class MeetingWrapper : ModelWrapper<Meeting>
    {
        public MeetingWrapper(Meeting model) : base(model)
        {
        }

        public int Id => Model.Id;

        public DateTime DateFrom
        {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
                if (DateTo < DateFrom) DateTo = DateFrom;
            }
        }

        public DateTime DateTo {
            get { return GetValue<DateTime>(); }
            set
            {
                SetValue(value);
                if (DateTo < DateFrom) DateFrom = DateTo;
            }
        }

        public string Title {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }


    }
}
