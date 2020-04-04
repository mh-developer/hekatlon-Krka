using System;
using WebApp.Domain.Models;

namespace WebApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
