using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tushkanchik.Transactions;

namespace Tushkanchik
{
    public class Card : CashAccount
    {

        public decimal PercentOfCashBack { get; set; }

        public Card(User holder, decimal balance, string name, decimal percentOfCashBack)
            : base(holder, balance, name)
        {
            PercentOfCashBack = percentOfCashBack;
        }


        public void AddCashBackFromExpense(Expense expense, Storage storage)
        {
            if (PercentOfCashBack > 0)
            {
                decimal amount = expense.Amount * PercentOfCashBack;
                string comment = "cashback";
                DateTime now = new DateTime();
                Income income = new Income(amount, now, this, comment);
                Balance += income.Amount;
                storage.Income.Add(income);
            }
        }


    }
}
