using System;
using System.Collections.Generic;
using Tushkanchik.Transactions;

namespace Tushkanchik
{
    public abstract class CashAccount
    {
        public List<User> Holders { get; set; }
        public User Holder { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }

        public CashAccount(User holder, List<User> holders, decimal balance, string name)
        {
            Holders = holders;
            Holder = holder;
            Balance = balance;
            Name = name;
        }
        public bool IfHoldersContainsUser(User user)

        {
            foreach (User holder in Holders)
            {
                if (holder.Name == user.Name)
                {
                    return true;
                }
            }
            return false;
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
