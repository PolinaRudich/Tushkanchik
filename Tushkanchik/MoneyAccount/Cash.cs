using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class Cash : CashAccount
    {
        public Cash(User holder, decimal balance, string name)
            :base(holder, balance, name)
        {
        
        }
    }
}
