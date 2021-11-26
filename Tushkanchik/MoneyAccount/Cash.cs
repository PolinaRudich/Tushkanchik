using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class Cash : CashAccount
    {
        public Cash(List<User> Holders, decimal Balance, string Name)
            :base(Holders, Balance, Name)
        {
        
        }
    }
}
