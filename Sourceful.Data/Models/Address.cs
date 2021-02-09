using System;
using System.Collections.Generic;
using System.Text;

namespace Sourceful.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
    }
}
