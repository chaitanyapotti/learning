using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly Func<FriendOrganizerDbContext> _contextCreator;

        //private readonly Func<FriendOrganizerDbContext> _contextCreator;


        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public IEnumerable<Friend> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return ctx.Friends.AsNoTracking().ToList();
            }
            ////TODO: Get friends from Database
            //yield return new Friend() {FirstName = "Thomas", LastName = "Huber"};
            //yield return new Friend() {FirstName = "Andreas", LastName = "Boehler"};
            //yield return new Friend() { FirstName = "Julia", LastName = "Huber" };
            //yield return new Friend() { FirstName = "Chrissi", LastName = "Egin" };
        }
        //async
        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
            ////TODO: Get friends from Database
            //yield return new Friend() {FirstName = "Thomas", LastName = "Huber"};
            //yield return new Friend() {FirstName = "Andreas", LastName = "Boehler"};
            //yield return new Friend() { FirstName = "Julia", LastName = "Huber" };
            //yield return new Friend() { FirstName = "Chrissi", LastName = "Egin" };
        }
    }
}
