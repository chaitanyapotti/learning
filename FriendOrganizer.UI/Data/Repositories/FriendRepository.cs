using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly FriendOrganizerDbContext _context;

        //private readonly Func<FriendOrganizerDbContext> _contextCreator;


        public FriendRepository(FriendOrganizerDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Friend> GetAll()
        {

            return _context.Friends.ToList();

            ////TODO: Get friends from Database
            //yield return new Friend() {FirstName = "Thomas", LastName = "Huber"};
            //yield return new Friend() {FirstName = "Andreas", LastName = "Boehler"};
            //yield return new Friend() { FirstName = "Julia", LastName = "Huber" };
            //yield return new Friend() { FirstName = "Chrissi", LastName = "Egin" };
        }
        //async
        public async Task<List<Friend>> GetAllAsync()
        {

            return await _context.Friends.ToListAsync();

            ////TODO: Get friends from Database
            //yield return new Friend() {FirstName = "Thomas", LastName = "Huber"};
            //yield return new Friend() {FirstName = "Andreas", LastName = "Boehler"};
            //yield return new Friend() { FirstName = "Julia", LastName = "Huber" };
            //yield return new Friend() { FirstName = "Chrissi", LastName = "Egin" };
        }

        public async Task<Friend> GetFriendByIdAsync(int friendId)
        {
            return await _context.Friends.Include(x => x.PhoneNumbers).SingleAsync(f => f.Id == friendId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Add(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        public void Delete(Friend friend)
        {
            _context.Friends.Remove(friend);
        }

        public void AddPhoneNumber(FriendPhoneNumber friendPhoneNumber)
        {
            _context.FriendPhoneNumbers.Add(friendPhoneNumber);
        }

        public void RemovePhoneNumber(FriendPhoneNumber friendPhoneNumber)
        {
            _context.FriendPhoneNumbers.Remove(friendPhoneNumber);
        }
    }
}
