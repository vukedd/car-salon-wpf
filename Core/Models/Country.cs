using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
