using Tushkanchik.Transactions;

namespace Tushkanchik.MoneyAccount
{
    public class Card : CashAccount
    {
        public decimal PercentOfCashBack { get; set; }
        public Card(User holder, decimal balance, string name, decimal percentOfCashBack)
            : base(holder, balance, name) => PercentOfCashBack = percentOfCashBack;
        public void AddCashBackFromExpense(Income income, Expense expense, Storage storage)
        {
            if (PercentOfCashBack <= 0)
            {
                return;
            }
            income.Amount = expense.Amount * PercentOfCashBack;
            Balance += income.Amount;
            storage.Income.Add(income);
        }
    }
}