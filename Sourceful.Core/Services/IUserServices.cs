using Sourceful.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sourceful.Core.Services
{
    public interface IUserServices
    {
        IQueryable<User> GetAllUsers();

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<int> CreateUserAsync(User user);

        Task<int> DeleteUserAsync(User user);
    }
}
