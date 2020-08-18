using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.IRepository
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task Update(User user);
        Task Delete(int id);
    }
}

