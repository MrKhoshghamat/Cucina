using Cucina.Application.Interfaces.Base;
using Cucina.Core.Entities;

namespace Cucina.Application.Interfaces.Account;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsExistUserByEmail(string email);
}