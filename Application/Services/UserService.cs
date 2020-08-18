using Application.IServices;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Exceptions;
using Infra.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(UserCreateRequest request)
        {
            User user = new User(request.Name, request.Nick);

            user.Validate();

            await _repository.Create(user);
        }

        public async Task Delete(int id)
        {
            User user = await _repository.Get(id);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await _repository.Delete(id);
        }

        public async Task<UserResponse> Get(int id)
        {
            User user = await _repository.Get(id);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return new UserResponse(id, user.Name, user.Nick);
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            List<UserResponse> usersResponse = new List<UserResponse>();
            IEnumerable<User> users = await _repository.GetAll() ?? new List<User>();

            foreach (User user in users)
            {
                usersResponse.Add(new UserResponse(user.Id, user.Name, user.Nick));
            }

            return usersResponse;
        }

        public async Task Update(int id, UserUpdateRequest request)
        {
            User user = await _repository.Get(id);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            user.Validate();

            user.Update(request.Nick);

            await _repository.Update(user);
        }
    }
}
