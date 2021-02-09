using Microsoft.EntityFrameworkCore;
using Sourceful.Data.Models;

namespace Sourceful.Data
{
    public interface IContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Info> Informations { get; set; }
    }
}