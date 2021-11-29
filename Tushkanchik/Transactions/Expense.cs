using System;
using Tushkanchik.MoneyAccount;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transactions
{
    public class Expense : Transaction
    {
        public ExpenseCategory ExpenseCategory { get; set; }

        public Expense(decimal amount, DateTime date, Card card, string comment, ExpenseCategory expenseCategory)
            : base(amount, date, card, comment)
        {
            ExpenseCategory = expenseCategory;
        }
    }
}
