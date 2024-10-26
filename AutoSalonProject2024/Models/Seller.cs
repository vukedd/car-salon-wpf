using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoSalonProject2024.Models
{
    public class Seller : User
    {
        public decimal Profit { get; set; } = (decimal)0.0;
        public List<Transaction>? Sales { get; set; }
        public List<Car>? Listings { get; set; }

    }
}
