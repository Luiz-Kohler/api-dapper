using Application.Models.Request;
using Application.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task Create(UserCreateRequest request);
        Task<UserResponse> Get(int id);
        Task<IEnumerable<UserResponse>> GetAll();
        Task Update(int id, UserUpdateRequest request);
        Task Delete(int id);
    }
}
