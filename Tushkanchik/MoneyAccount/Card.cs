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

        public Card( User holder,  decimal balance, string name, decimal percentOfCashBack)
            :base (holder, balance, name)
        {
            PercentOfCashBack = percentOfCashBack;
        }

       

       
        public void AddCashBackFromExpense (Income income, Expense expense, Storage storage)
        {
            if ( PercentOfCashBack > 0 )
            {
                income.Amount = expense.Amount * PercentOfCashBack;
                Balance += income.Amount;
                storage.Income.Add(income);
            }
        }


    }
}
