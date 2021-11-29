using System;
using Tushkanchik.Transactions;

namespace Tushkanchik.MoneyAccount
{
    public class CashAccount
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
        public void IncreaseBalance(Income income, Storage storage)
        {
            Balance += income.Amount;
            storage.Income.Add(income);
        }

        public void DecreaseBalance(Expense expense, Storage storage)
        {
            if (expense.Amount < Balance)
            {
                Balance -= expense.Amount;
                storage.Expense.Add(expense);
            }
            else
            {
                throw new Exception("Недостаточно средств ");
            }
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
