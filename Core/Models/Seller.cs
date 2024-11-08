using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoSalonProject2024.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JMBG { get; set; }
        public decimal Profit { get; set; } = (decimal)0.0;
        public List<Transaction>? Sales { get; set; }
    }
}
