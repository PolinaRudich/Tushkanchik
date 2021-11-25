using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tushkanchik.Transactions;

namespace Tushkanchik
{

    public abstract class CashAccount
    {

        private List<User> _holders { get; set; }
        private decimal Balance { get; set; }
        private string Name { get; set; }

        //public double _cashback { get; set; }

        public CashAccount(User holder, decimal balance, string name)
        {
            List<User> _holders = new List<User>();
            _holders.Add(holder);
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


        public void AddHolder(User user)
        {
            _holders.Add(user);
        }
        public void DeleteHolder(User user)
        {
            _holders.Remove(user);
        }
    }
}
