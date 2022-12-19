using System.Data;
using Cucina.Application.Interfaces.Account;
using Cucina.Core.Entities;
using Cucina.SQL.Queries.Account;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cucina.Persistence.Repository.Account;

public class UserRepository : IUserRepository
{
    #region ===[ Private Members ]=============================================================

    private readonly IConfiguration _configuration;

    #endregion

    #region ===[ Constructor ]=================================================================

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #endregion

    #region ===[ IUserRepository Methods ]=====================================================

    public async Task<IReadOnlyList<User>> GetAllAsync(Guid? id)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = await connection.QueryAsync<User>(UserQueries.AllUsers, new { Id = id});
            return result.ToList();
        }
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<User>(UserQueries.UserById, new { Id = id });
            return result;
        }
    }

    public async Task<string> AddAsync(User entity)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(UserQueries.AddUser, entity);
            return result.ToString();
        }
    }

    public async Task<string> UpdateAsync(User entity)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(UserQueries.UpdateUser, entity);
            return result.ToString();
        }
    }

    public async Task<string> DeleteAsync(Guid id)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(UserQueries.DeleteUser, new { Id = id });
            return result.ToString();
        }
    }

    public async Task<bool> IsExistUserByEmail(string email)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("CucinaConnection")))
        {
            connection.Open();
            var result = connection.ExecuteScalar<bool>(UserQueries.IsExistUserByEmail, new { Email = email });
            return result;
        }
    }

    #endregion
}