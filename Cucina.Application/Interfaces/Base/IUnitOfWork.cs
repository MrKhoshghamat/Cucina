using Cucina.Application.Interfaces.Account;

namespace Cucina.Application.Interfaces.Base;

public interface IUnitOfWork
{
    IUserRepository Users { get;  }
}