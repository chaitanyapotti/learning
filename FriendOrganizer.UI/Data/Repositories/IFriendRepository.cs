using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Wrapper;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAll();

        Task<List<Friend>> GetAllAsync();

        Task<Friend> GetFriendByIdAsync(int friendId);

        Task SaveAsync();

        bool HasChanges();

        void Add(Friend friend);

        void Delete(Friend friend);

        void AddPhoneNumber(FriendPhoneNumber friendPhoneNumber);

        void RemovePhoneNumber(FriendPhoneNumber friendPhoneNumber);
    }
}