using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik.Transactions
{

    public abstract class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

       
       // public Card Card { get; set; }

        public string Comment { get; set; }
        public User User { get; set; }

        public Transaction(decimal amount, User user, DateTime date, string comment)
        {
            Amount = amount;
            User = user;
            Date = date;
            Comment = comment;
        }
    }
}
