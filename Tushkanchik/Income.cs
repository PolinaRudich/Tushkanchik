using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tushkanchik;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class Income
    {
        private double _amount;
        private double _percent;
        private string _to;
        private string _from;
        private int _card;
        private bool _fixed;
        private Income _category;
        public Income()
        {
            _amount = 0;
            _percent = 0;
            _to = "";
            _from = "";
            _card = 0;
            _fixed = true;
            _category = null;
        }
        public Income( double amount,double cashback, string to, string from, int card, Income category, Account account )
        {
            _amount = amount;
            _percent = cashback;
            _to = to;
            _from = from;
            _card = card;
            _category = category;
            account.AddBalance(amount);

        }
      

    }
}
