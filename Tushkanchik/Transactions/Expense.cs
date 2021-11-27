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

        public Expense(decimal amount, User user, DateTime date, string comment, ExpenseCategory expenseCategory)
            : base(amount, user, date, comment)
        {
            ExpenseCategory = expenseCategory;
        }
    }
}
