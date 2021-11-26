using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public abstract class CashAccount
    {
        public List<User> holders { get; set; }
        public decimal balance { get; set; }
        public string name { get; set; }

        public CashAccount(List<User> Holders, decimal Balance, string Name )
        {
            holders = Holders;
            balance = Balance;
            name = Name;
        }
    }
}
