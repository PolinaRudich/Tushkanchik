using System;
using System.Collections.Generic;

namespace Tushkanchik
{
    public abstract class Deposite : CashAccount
    {
        public bool Replacement { get; set; }
        public decimal Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public Deposite(User holder, decimal balance, string name, decimal percent, DateTime startDate, DateTime finishDate, bool replacement)
            :base(holder, balance, name)
        {
            Replacement = replacement;
            Percent = percent;
            StartDate = startDate;
            FinishDate = finishDate;
        }
    }
}
