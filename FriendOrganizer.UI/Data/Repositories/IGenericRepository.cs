using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task SaveAsync();

        bool HasChanges();

        void Add(T model);

        void Delete(T model);
    }
}