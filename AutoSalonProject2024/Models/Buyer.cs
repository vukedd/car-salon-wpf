using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoSalonProject2024.Models
{
    public class Buyer : User
    {
        public string IdNumber { get; set; }
        public List<Transaction>? Purchases { get; set; }
    }
}
