using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transaction
{
    class Expense : Transaction
    {
        public ExpenseCategory ExpenseCategory { get; set; }

        public Expense(decimal amount, DateTime date, int card)
            : base(amount, date, card)
        {

        }



    }
}
