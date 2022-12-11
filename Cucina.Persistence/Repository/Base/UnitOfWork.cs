using Cucina.Application.Interfaces.Account;
using Cucina.Application.Interfaces.Base;

namespace Cucina.Persistence.Repository.Base;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository)
    {
        Users = userRepository;
    }
    
    public IUserRepository Users { get; }
}