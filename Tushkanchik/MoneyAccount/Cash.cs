namespace Tushkanchik.MoneyAccount
{
    class Cash : CashAccount
    {
        public Cash(User holder, decimal balance, string name)
            : base(holder, balance, name)
        {

        }
    }
}
