using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public class DepositeWithoutWithdrawal: Deposite
    {
        public DepositeWithoutWithdrawal(User holder, List<User> holders, decimal balance, string name, decimal percent, DateTime startDate, DateTime finishDate, bool replacement)
            :base(holder, holders, balance, name, percent, startDate, finishDate, replacement)
        {
            replacement = false;
           
        }
    }
}
