using Microsoft.EntityFrameworkCore;
using Sourceful.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sourceful.Data
{
    public class UserContext : DbContext, IContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Info> Informations { get; set; }
    }
}
