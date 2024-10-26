using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalonProject2024.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public Car Car { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

    }
}
