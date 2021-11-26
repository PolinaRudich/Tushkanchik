using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public class DepositeWithoutWithdrawal: Deposite
    {
        public DepositeWithoutWithdrawal(bool RepLacement, decimal Percent, DateTime StartDate, DateTime FinishDate, List<User> Holder, decimal Balance, string Name)
            :base(RepLacement, Percent, StartDate, FinishDate,Holder,Balance, Name)
        {
            replacement = true;
            percent = percent;
            startDate = startDate;
            finishDate = finishDate;
        }
    }
}
