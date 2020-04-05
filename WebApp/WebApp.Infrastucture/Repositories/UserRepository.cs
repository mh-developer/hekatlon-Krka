using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Domain.Repositories;

namespace WebApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await Context.Users.ToListAsync();
        }

        public override async Task<List<User>> FilterAsync(Func<User, bool> predicate)
        {
            return await Context.Users.ToListAsync()
                .ContinueWith(x => x.Result.Where(predicate).ToList());
        }

        public override User Get(Guid id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public override async Task<User> GetAsync(Guid id)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}