using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAll();

        Task<List<Friend>> GetAllAsync();

        Task<Friend> GetFriendByIdAsync(int friendId);

        Task SaveAsync();

        bool HasChanges();
    }
}