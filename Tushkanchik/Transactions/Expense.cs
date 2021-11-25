using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transactions
{
    public class Expense : Transaction
    {
        public ExpenseCategory ExpenseCategory { get; set; }

        public Expense(decimal amount, DateTime date, Card card, string comment)
            : base(amount, date, card,comment)
        {

        }



    }
}
