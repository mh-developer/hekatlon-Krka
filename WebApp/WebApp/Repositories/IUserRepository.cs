using System;
using WebApp.Models;
using WebApp.Models.Shared;

namespace WebApp.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
