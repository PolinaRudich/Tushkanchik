using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public class Card : CashAccount
    {
       
        public float percentOfCashBack { get; set; }

        public Card( User holder, decimal balance, string name, float PercentOfCashBack)
            :base (holder, balance, name)
        {
            percentOfCashBack = PercentOfCashBack;
        }
     }
}
