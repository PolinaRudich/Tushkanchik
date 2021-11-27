using System;
using System.Collections.Generic;

namespace Tushkanchik
{
    public class DepositeWithWithdrawal:Deposite
    {

        public bool withdrawal { get; set; }

        public DepositeWithWithdrawal(User holder, decimal balance, string name, decimal percent, DateTime startDate, DateTime finishDate, bool replacement)
            : base(holder,  balance, name, percent, startDate, finishDate, replacement)

        {
            withdrawal = true;
        }
    }
}
