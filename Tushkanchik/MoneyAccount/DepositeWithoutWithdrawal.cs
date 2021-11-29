using System;

namespace Tushkanchik.MoneyAccount
{
    public class DepositeWithoutWithdrawal : Deposite
    {
        public DepositeWithoutWithdrawal(User holder, decimal balance, string name, decimal percent, DateTime startDate, DateTime finishDate, bool replacement)
            : base(holder, balance, name, percent, startDate, finishDate, replacement)
        {
            replacement = false;

        }
    }
}
