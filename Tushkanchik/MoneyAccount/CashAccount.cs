using System.Collections.Generic;

namespace Tushkanchik
{
    public abstract class CashAccount
    {
        public User Holder { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }

        public CashAccount(User holder, decimal balance, string name)
        {
            Holder = holder;
            Balance = balance;
            Name = name;
        }
    }
}
