using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Wrapper;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {

        void RemovePhoneNumber(FriendPhoneNumber friendPhoneNumber);

        Task<bool> HasMeetingsAsync(int friendId);
    }
}