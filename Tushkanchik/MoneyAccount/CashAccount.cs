using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public abstract class CashAccount
    {
        public List<User> holder { get; set; }
        public decimal balance { get; set; }
        public string name { get; set; }

        public CashAccount(List<User> Holder, decimal Balance, string Name )
        {
            List<User> holders = new List<User>();
            holders.Add(Holder);
            balance = Balance;
            name = Name;
        }
    }
}
