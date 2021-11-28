using System;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transactions
{
    public  class Income : Transaction 
    {
        public IncomeCategory IncomeCategory { get; set; }

        public Income(decimal amount, DateTime date, Card card, string comment, IncomeCategory incomeCategory)
            : base( amount,  date,  card,comment)
        {
            IncomeCategory = incomeCategory; 
        }
        

    }
}
