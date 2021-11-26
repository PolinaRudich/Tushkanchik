using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class Cash : CashAccount
    {
        public Cash(List<User> Holder, decimal Balance, string Name)
            :base(Holder, Balance, Name)
        {
        
        }
    }
}
