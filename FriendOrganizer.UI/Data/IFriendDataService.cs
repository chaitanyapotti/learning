using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        IEnumerable<Friend> GetAll();

        Task<List<Friend>> GetAllAsync();

        Task<Friend> GetFriendByIdAsync(int friendId);

        Task SaveAsync(Friend friend);
    }
}