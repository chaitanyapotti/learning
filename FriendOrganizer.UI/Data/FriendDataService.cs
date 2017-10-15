using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            //TODO: Get friends from Database
            yield return new Friend() {FirstName = "Thomas", LastName = "Huber"};
            yield return new Friend() {FirstName = "Andreas", LastName = "Boehler"};
            yield return new Friend() { FirstName = "Julia", LastName = "Huber" };
            yield return new Friend() { FirstName = "Chrissi", LastName = "Egin" };
        }
    }
}
