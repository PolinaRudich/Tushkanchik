using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public abstract class Deposite : CashAccount
    {
        public bool replacement { get; set; }
        public decimal percent { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }

        public Deposite(  bool Replacement, decimal Percent, DateTime StartDate, DateTime FinishDate, List<User> Holder, decimal Balance, string Name)
            :base(Holder, Balance, Name)
        {
            replacement = Replacement;
            percent = Percent;
            startDate = StartDate;
            finishDate = FinishDate;
        }
    }
}
