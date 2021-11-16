using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tushkanchik;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class Income: Transaction
    {
        private decimal _balance;
        private decimal _amount;
        private int? _card;
        private TransactionCategories _category;
        public Income()
        {
            _amount = 0;
            _card = null;
            _category = null;
            
        }
        public Income(int card, TransactionCategories category, decimal amount, decimal balance)
        {
            _balance = balance;
            _amount = amount;
            _card = card;
            _category = category;
        }
       public void AddBalance(decimal amount)
        {
            _balance += amount;
        }
        //public Income()
        //{
        //    _amount = 0;
        //    _percent = 0;
        //    _to = "";
        //    _from = "";
        //    _card = 0;
        //    _fixed = true;
            
        //}
        //public Income( decimal amount,double cashback, string to, string from, int card, Income category, CashAccount account )
        //{
        //    _amount = amount;
        //    _percent = cashback;
        //    _to = to;
        //    _from = from;
        //    _card = card;
           
        //    account.AddBalance(amount);

        //}
      

    }
}
