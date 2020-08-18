using Dapper;
using Dapper.Contrib.Extensions;
using Domain.Entities;
using Infra.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UserRepository : IUserRepository
    {

        private static readonly string _connectionString = @"ConnectionString";

        public async Task Create(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.InsertAsync<User>(user);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Id", id, DbType.Int32);

                    await connection.ExecuteAsync("DELETE Users WHERE Id = @Id", parameters);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<User> Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Id", id, DbType.Int32);

                    return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users where Id = @Id", parameters);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return await connection.GetAllAsync<User>();
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.UpdateAsync<User>(user);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
    }
}
