using System;

namespace Tushkanchik
{
    public class DepositeWithWithdrawal:Deposite
    {

        public bool withdrawal { get; set; }

        public DepositeWithWithdrawal(bool Withdrawal, bool RepLacement, decimal Percent, DateTime StartDate, DateTime FinishDate, User holder, decimal balance, string name) 
            : base(RepLacement, Percent, StartDate, FinishDate,holder,balance,name)

        {
            withdrawal = true;
        }
    }
}
