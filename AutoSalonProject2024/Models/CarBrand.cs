using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

    }
}
