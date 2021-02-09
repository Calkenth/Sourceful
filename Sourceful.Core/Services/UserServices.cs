using Microsoft.EntityFrameworkCore;
using Sourceful.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Sourceful.Data.Models;

namespace Sourceful.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserContext userContext;

        public UserServices(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public IQueryable<User> GetAllUsers()
        {
            return userContext.Users.AsQueryable();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await GetAllUsers().ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await GetAllUsers()
                .Include(u => u.Address)
                .Include(u => u.Info)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            if(user.Id > 0)
            {
                return 0;
            }
            userContext.Add(user);
            await userContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            userContext.Remove(user);
            return await userContext.SaveChangesAsync();
        }
    }
}
