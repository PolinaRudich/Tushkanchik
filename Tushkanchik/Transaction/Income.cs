using System;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transaction
{
    public  class Income : Transaction 
    {
        public IncomeCategory IncomeCategory { get; set; }

        public Income(decimal amount, DateTime date, int card)
            : base( amount,  date,  card)
        {

        }
        

    }
}
