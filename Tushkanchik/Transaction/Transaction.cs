using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public abstract class Transaction
    {
        private decimal _amount;
        private DateTime?  _date;
        private int? _card;
        private string _category;
        public Transaction()
        {
            _amount = 0;
            _date = null;
           
            _card = null;
            _category = null;
        }
        public Transaction(decimal amount, int date, int card, string category)
        {
            _amount = amount;
            _date = date;
           
            _card = card;
            _category = category;
        }

        
    }
}
