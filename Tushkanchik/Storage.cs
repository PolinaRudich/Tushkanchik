using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tushkanchik.Transaction;
using Tushkanchik.Transaction.Categories;
using Tushkanchik.Transactions;

namespace Tushkanchik
{
    public sealed class Storage
    {
        public List<Card> Cards { get; set; }
        public List<User> Users { get; set; }
        public List<DepositeWithoutWithdrawal> DepositeWithoutWithdrawal { get; set; }
        public List<DepositeWithWithdrawal> DepositWithWithdrawal { get; set; }
        public List<Expense> Expense { get; set; }
        public List<Income> Income { get; set; }
        public List<ExpenseCategory> ExpenseCategory { get; set; }
        public List<IncomeCategory> IncomeCategory { get; set; }
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
        public ObservableCollection<CardForView> GetCardsForViewByUser(User user)
        {
            ObservableCollection<CardForView> cards = new ObservableCollection<CardForView>();


            foreach (Card card in _storage.Cards)
            {
                if (card.IfHoldersContainsUser(user))
                {
                    CardForView cardForView = new CardForView() { Card = card, NamePlusBalance = card.Name + " " + card.Balance };
                    cards.Add(cardForView);
                }
            }
            return cards;
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
        public List<DepositeWithWithdrawal> DepositWithWithdrawalFromJSON()
        {
            if (!File.Exists(DepositWithWithdrawalPath))
            {
                FileStream fs = File.Create(DepositWithWithdrawalPath);
                fs.Close();
                return new List<DepositeWithWithdrawal>();
            }
            List<DepositeWithWithdrawal> depositWithWithdrawal = new List<DepositeWithWithdrawal>();
            string json = File.ReadAllText(DepositWithWithdrawalPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                depositWithWithdrawal = new List<DepositeWithWithdrawal>();
            }
            else
            {
                depositWithWithdrawal = JsonSerializer.Deserialize<List<DepositeWithWithdrawal>>(json);
            }
            DepositWithWithdrawal = depositWithWithdrawal;
            return depositWithWithdrawal;
        }
        public List<Expense> ExpenseFromJSON()
        {
            if (!File.Exists(ExpensePath))
            {
                FileStream fs = File.Create(ExpensePath);
                fs.Close();
                return new List<Expense>();
            }
            List<Expense> expense = new List<Expense>();
            string json = File.ReadAllText(ExpensePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                expense = new List<Expense>();
            }
            else
            {
                expense = JsonSerializer.Deserialize<List<Expense>>(json);
            }
            Expense = expense;
            return expense;
        }
        public List<Income> IncomeFromJSON()
        {
            if (!File.Exists(IncomePath))
            {
                FileStream fs = File.Create(IncomePath);
                fs.Close();
                return new List<Income>();
            }
            List<Income> income = new List<Income>();
            string json = File.ReadAllText(IncomePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                income = new List<Income>();
            }
            else
            {
                income = JsonSerializer.Deserialize<List<Income>>(json);
            }
            Income = income;
            return income;
        }
        public List<ExpenseCategory> ExpenseCategoryFromJSON()
        {
            if (!File.Exists(ExpenseCategoryPath))
            {
                FileStream fs = File.Create(ExpenseCategoryPath);
                fs.Close();
                return new List<ExpenseCategory>();
            }
            List<ExpenseCategory> expenseCategory = new List<ExpenseCategory>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                expenseCategory = new List<ExpenseCategory>();
            }
            else
            {
                expenseCategory = JsonSerializer.Deserialize<List<ExpenseCategory>>(json);
            }
            ExpenseCategory = expenseCategory;
            return expenseCategory;
        }
        public List<IncomeCategory> IncomeCategoryFromJSON()
        {
            if (!File.Exists(IncomeCategoryPath))
            {
                FileStream fs = File.Create(IncomeCategoryPath);
                fs.Close();
                return new List<IncomeCategory>();
            }
            List<IncomeCategory> incomeCategory = new List<IncomeCategory>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                incomeCategory = new List<IncomeCategory>();
            }
            else
            {
                incomeCategory = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
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
       
    }

}