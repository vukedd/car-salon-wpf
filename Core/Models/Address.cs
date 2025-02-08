using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }

        public Address(int Id, string StreetName, string StreetNumber, string PostalCode)
        {
            this.Id = Id;
            this.StreetName = StreetName;
            this.StreetNumber = StreetNumber;
            this.PostalCode = PostalCode;
        }

        public Address() { }
    }
}
