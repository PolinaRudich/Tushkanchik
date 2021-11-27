using System;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transactions
{
    public  class Income : Transaction 
    {
        public IncomeCategory IncomeCategory { get; set; }

        public Income(decimal amount, User user, DateTime date,  string comment)
            : base( amount, user,  date,comment)
        {

        }
        

    }
}
