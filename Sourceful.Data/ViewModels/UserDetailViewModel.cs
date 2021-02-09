using Sourceful.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sourceful.Data.ViewModels
{
    public class UserDetailViewModel
    {
        public UserDetailViewModel()
        {
        }

        public UserDetailViewModel(User user, Address address, Info info)
        {
            Name = user.FirstName;
            LastName = user.LastName;
            Town = address.Town;
            StreetName = address.StreetName;
            Number = address.Number;
            ShortDesc = info.ShortDesc;
            LongDesc = info.LongDesc;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
    }
}
