using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tushkanchik.Transactions;
using Tushkanchik.Transactions.Categories;

namespace Tushkanchik
{
    public sealed class Storage
    {
        public List<Card> Cards { get; set; }
        public List<User> Users { get; set; }
        public List<DepositeWithoutWithdrawal> DepositeWithoutWithdrawal { get; set; }
        public List<DepositWithWithdrawal> DepositWithWithdrawal { get; set; }
        public List<Transaction> Expense { get; set; }
        public List<Transaction> Income { get; set; }
        public List<Category> ExpenseCategory { get; set; }
        public List<Category> IncomeCategory { get; set; }
        //cохрание категорий

        private static Storage _storage;
        public string UsersPath = Directory.GetCurrentDirectory() + "/json/users.txt";
        public string CardsPath = Directory.GetCurrentDirectory() + "/json/cards.txt";
        public string DepositeWithoutWithdrawalPath = Directory.GetCurrentDirectory() + "/json/depositeWithoutWithdrawal.txt";
        public string DepositWithWithdrawalPath = Directory.GetCurrentDirectory() + "/json/depositWithWithdrawal.txt";
        public string ExpensePath = Directory.GetCurrentDirectory() + "/json/expense.txt";
        public string IncomePath = Directory.GetCurrentDirectory() + "/json/income.txt";
        public string ExpenseCategoryPath = Directory.GetCurrentDirectory() + "/json/expenseCategory.txt";
        public string IncomeCategoryPath = Directory.GetCurrentDirectory() + "/json/incomeCategory.txt";

       
        public List<User> GetUsersFromJSON()
        {
            if (!File.Exists(UsersPath))
            {
                FileStream fs = File.Create(UsersPath);
                fs.Close();
                return new List<User>();
            }
            List<User> users = new List<User>();
            string json = File.ReadAllText(UsersPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                users = new List<User>();
            }
            if (users is null)
            {
                users = new List<User>();
            }
            else
            {
                users = JsonSerializer.Deserialize<List<User>>(json);
            }
            Users = users;
            return users;
        }
        public List<Card> GetCardsFromJSON()
        {
            if (!File.Exists(CardsPath))
            {
                FileStream fs = File.Create(CardsPath);
                fs.Close();
                return new List<Card>();
            }
            List<Card> cards = new List<Card>();
            string json = File.ReadAllText(CardsPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                cards = new List<Card>();
            }
            else
            {
                cards = JsonSerializer.Deserialize<List<Card>>(json);
            }
            Cards = cards;
            return cards;
        }
        public List<DepositeWithoutWithdrawal> GetDepositeWithoutWithdrawalFromJSON()
        {
            if (!File.Exists(DepositeWithoutWithdrawalPath))
            {
                FileStream fs = File.Create(DepositeWithoutWithdrawalPath);
                fs.Close();
                return new List<DepositeWithoutWithdrawal>();
            }
            List<DepositeWithoutWithdrawal> depositeWithoutWithdrawal = new List<DepositeWithoutWithdrawal>();
            string json = File.ReadAllText(DepositeWithoutWithdrawalPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                depositeWithoutWithdrawal = new List<DepositeWithoutWithdrawal>();
            }
            else
            {
                depositeWithoutWithdrawal = JsonSerializer.Deserialize<List<DepositeWithoutWithdrawal>>(json);
            }
            DepositeWithoutWithdrawal = depositeWithoutWithdrawal;
            return depositeWithoutWithdrawal;
        }
        public List<DepositWithWithdrawal> DepositWithWithdrawalFromJSON()
        {
            if (!File.Exists(DepositWithWithdrawalPath))
            {
                FileStream fs = File.Create(DepositWithWithdrawalPath);
                fs.Close();
                return new List<DepositWithWithdrawal>();
            }
            List<DepositWithWithdrawal> depositWithWithdrawal = new List<DepositWithWithdrawal>();
            string json = File.ReadAllText(DepositWithWithdrawalPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                depositWithWithdrawal = new List<DepositWithWithdrawal>();
            }
            else
            {
                depositWithWithdrawal = JsonSerializer.Deserialize<List<DepositWithWithdrawal>>(json);
            }
            DepositWithWithdrawal = depositWithWithdrawal;
            return depositWithWithdrawal;
        }
        public List<Transaction> ExpenseFromJSON()
        {
            if (!File.Exists(ExpensePath))
            {
                FileStream fs = File.Create(ExpensePath);
                fs.Close();
                return new List<Transaction>();
            }
            List<Transaction> expense = new List<Transaction>();
            string json = File.ReadAllText(ExpensePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                expense = new List<Transaction>();
            }
            else
            {
                expense = JsonSerializer.Deserialize<List<Transaction>>(json);
            }
            Expense = expense;
            return expense;
        }
        public List<Transaction> IncomeFromJSON()
        {
            if (!File.Exists(IncomePath))
            {
                FileStream fs = File.Create(IncomePath);
                fs.Close();
                return new List<Transaction>();
            }
            List<Transaction> income = new List<Transaction>();
            string json = File.ReadAllText(IncomePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                income = new List<Transaction>();
            }
            else
            {
                income = JsonSerializer.Deserialize<List<Transaction>>(json);
            }
            Income = income;
            return income;
        }
        public List<Category> ExpenseCategoryFromJSON()
        {
            if (!File.Exists(ExpenseCategoryPath))
            {
                FileStream fs = File.Create(ExpenseCategoryPath);
                fs.Close();
                return new List<Category>();
            }
            List<Category> expenseCategory = new List<Category>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                expenseCategory = new List<Category>();
            }
            else
            {
                expenseCategory = JsonSerializer.Deserialize<List<Category>>(json);
            }
            ExpenseCategory = expenseCategory;
            return expenseCategory;
        }
        public List<Category> IncomeCategoryFromJSON()
        {
            if (!File.Exists(IncomeCategoryPath))
            {
                FileStream fs = File.Create(IncomeCategoryPath);
                fs.Close();
                return new List<Category>();
            }
            List<Category> incomeCategory = new List<Category>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                incomeCategory = new List<Category>();
            }
            else
            {
                incomeCategory = JsonSerializer.Deserialize<List<Category>>(json);
            }
            IncomeCategory = incomeCategory;
            return incomeCategory;
        }

        private Storage()
        {
            GetUsersFromJSON();
            GetCardsFromJSON();
            GetDepositeWithoutWithdrawalFromJSON();
            DepositWithWithdrawalFromJSON();
            ExpenseFromJSON();
            IncomeFromJSON();
            ExpenseCategoryFromJSON();
            IncomeCategoryFromJSON();
        }

        public static Storage GetInstance()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }
        public List<Card> GetCardsByUser(User user)
        {
            List<Card> cards = new List<Card>();
            foreach (Card card in _storage.Cards)
            {
                if (card.Holders.Contains(user))
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
        public ObservableCollection<CardForView> GetCardsForViewByUser(User user)
        {
            ObservableCollection<CardForView> cards = new ObservableCollection<CardForView>();


            foreach (Card card in _storage.Cards)
            {
                if (card.IfHoldersContainsUser( user))
                {
                    CardForView cardForView = new CardForView() { Card = card, NamePlusBalance = card.Name + " " + card.Balance };
                    cards.Add(cardForView);
                }
            }
            return cards;
        }
      

    }

}
