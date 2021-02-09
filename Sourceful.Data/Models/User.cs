using System;
using System.Collections.Generic;
using System.Text;

namespace Sourceful.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int InfoId { get; set; }
        public Info Info { get; set; }
    }
}
