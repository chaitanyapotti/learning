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
    public class FriendRepository : GenericRepository<Friend, FriendOrganizerDbContext>, IFriendRepository
    {
        public FriendRepository(FriendOrganizerDbContext context) : base(context)
        {

        }

        public override async Task<Friend> GetByIdAsync(int friendId)
        {
            return await Context.Friends.Include(x => x.PhoneNumbers).SingleAsync(f => f.Id == friendId);
        }

        public async Task<bool> HasMeetingsAsync(int friendId)
        {
            return await Context.Meetings.AsNoTracking().Include(m => m.Friends).AnyAsync(x => x.Friends.Any(y => y.Id == friendId));
        }

        public void RemovePhoneNumber(FriendPhoneNumber friendPhoneNumber)
        {
            Context.FriendPhoneNumbers.Remove(friendPhoneNumber);
        }
    }
}
