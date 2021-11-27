using System.Collections.Generic;

namespace Tushkanchik
{
    class Cash : CashAccount
    {
        public Cash(User holder, List<User> holders, decimal balance, string name)
            :base(holder,holders, balance, name)
        {
        
        }
    }
}
