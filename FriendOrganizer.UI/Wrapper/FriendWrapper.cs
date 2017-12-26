using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
            Model = model;
        }

        public int Id => Model.Id;

        public string FirstName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                //ValidateProperty(nameof(FirstName));
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid friends";
                    }
                    break;
            }
        }


        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);
        //    switch (propertyName)
        //    {
        //        case nameof(FirstName):
        //            if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
        //            {
        //                AddError(propertyName, "Robots are not valid friends");
        //            }
        //            break;
        //    }
        //}

        public string LastName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public int? FavoriteLanguageId
        {
            get { return GetValue<int?>(); }
            set
            {
                SetValue(value);
            }
        }


    }
}
