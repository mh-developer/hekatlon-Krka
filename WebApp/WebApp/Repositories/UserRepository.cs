using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await Context.Users.FromSqlRaw("SELECT * FROM UserView").ToListAsync();
        }

        public override async Task<List<User>> FilterAsync(Func<User, bool> predicate)
        {
            return await Context.Users.FromSqlRaw("SELECT * FROM UserView").ToListAsync()
                .ContinueWith(x => x.Result.Where(predicate).ToList());
        }

        public override User Get(Guid id)
        {
            return Context.Users.FromSqlRaw("SELECT * FROM UserView")
                .FirstOrDefault(x => x.Id == id);
        }

        public override async Task<User> GetAsync(Guid id)
        {
            return await Context.Users.FromSqlRaw("SELECT * FROM UserView")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}