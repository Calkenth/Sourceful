using Sourceful.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sourceful.Data
{
    public class DataSeeder
    {
        public static void SeedData(UserContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User()
                    {
                        FirstName = "Adam",
                        LastName = "Jaki",
                        Address =new Address()
                        { 
                            Town = "Glilwice",
                            StreetName = "Wolna",
                            Number = 12 
                        },
                        Info = new Info()
                        {
                            ShortDesc = "short desc",
                            LongDesc = "long description"
                        }
                    },
                    new User()
                    {
                        FirstName = "Tomasz",
                        LastName = "Inny",
                        Address =new Address()
                        {
                            Town = "Glilwice",
                            StreetName = "Wolna",
                            Number = 12
                        },
                        Info = new Info()
                        {
                            ShortDesc = "short desc",
                            LongDesc = "long description"
                        }
                    },
                    new User()
                    {
                        FirstName = "Andrzej",
                        LastName = "Taki",
                        Address =new Address()
                        {
                            Town = "Glilwice",
                            StreetName = "Wolna",
                            Number = 12
                        },
                        Info = new Info()
                        {
                            ShortDesc = "short desc",
                            LongDesc = "long description"
                        }
                    }
                };
                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}