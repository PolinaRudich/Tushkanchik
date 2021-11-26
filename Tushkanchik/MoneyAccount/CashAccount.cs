using System.Collections.Generic;

namespace Tushkanchik
{
    public abstract class CashAccount
    {
        public List<User> _holders { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }

        public CashAccount(User holder, decimal balance, string name)
        {
            List<User> _holders = new List<User>();
            _holders.Add(holder);
            Balance = balance;
            Name = name;
        }
    }
}
