using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tushkanchik.Transaction;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik
{
    public sealed class Storage
    {
        public List<Card> Cards { get; set; }
        public List<User> Users { get; set; }
        public List<DepositeWithoutWithdrawal> DepositeWithoutWithdrawal { get; set; }
        public List<DepositWithWithdrawal> DepositWithWithdrawal { get; set; }
        public List<Expense> Expense { get; set; }
        public List<Income> Income{ get; set; }
        public List<ExpenseCategory> ExpenseCategory { get; set; }
        public List<IncomeCategory> IncomeCategory { get; set; }
        //cохрание категорий

        private static Storage _storage;
        public  string UsersPath = Directory.GetCurrentDirectory() + "/json/users.txt";
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
            List<DepositeWithoutWithdrawal> DepositeWithoutWithdrawal = new List<DepositeWithoutWithdrawal>();
            string json = File.ReadAllText(DepositeWithoutWithdrawalPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                DepositeWithoutWithdrawal = new List<DepositeWithoutWithdrawal>();
            }
            else
            {
                DepositeWithoutWithdrawal = JsonSerializer.Deserialize<List<DepositeWithoutWithdrawal>>(json);
            }
            return DepositeWithoutWithdrawal;
        }
        public List<DepositWithWithdrawal> DepositWithWithdrawalFromJSON()
        {
            if (!File.Exists(DepositWithWithdrawalPath))
            {
                FileStream fs = File.Create(DepositWithWithdrawalPath);
                fs.Close();
                return new List<DepositWithWithdrawal>();
            }
            List<DepositWithWithdrawal> DepositWithWithdrawal = new List<DepositWithWithdrawal>();
            string json = File.ReadAllText(DepositWithWithdrawalPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                DepositWithWithdrawal = new List<DepositWithWithdrawal>();
            }
            else
            {
                DepositWithWithdrawal = JsonSerializer.Deserialize<List<DepositWithWithdrawal>>(json);
            }
            return DepositWithWithdrawal;
        }
        public List<Expense> ExpenseFromJSON()
        {
            if (!File.Exists(ExpensePath))
            {
                FileStream fs = File.Create(ExpensePath);
                fs.Close();
                return new List<Expense>();
            }
            List<Expense> Expense = new List<Expense>();
            string json = File.ReadAllText(ExpensePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Expense = new List<Expense>();
            }
            else
            {
                Expense = JsonSerializer.Deserialize<List<Expense>>(json);
            }
            return Expense;
        }
        public List<Income> IncomeFromJSON()
        {
            if (!File.Exists(ExpensePath))
            {
                FileStream fs = File.Create(IncomePath);
                fs.Close();
                return new List<Income>();
            }
            List<Income> Expense = new List<Income>();
            string json = File.ReadAllText(IncomePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Income = new List<Income>();
            }
            else
            {
                Income = JsonSerializer.Deserialize<List<Income>>(json);
            }
            return Income;
        }
        public List<ExpenseCategory> ExpenseCategoryFromJSON()
        {
            if (!File.Exists(ExpenseCategoryPath))
            {
                FileStream fs = File.Create(ExpenseCategoryPath);
                fs.Close();
                return new List<ExpenseCategory>();
            }
            List<ExpenseCategory> ExpenseCategory = new List<ExpenseCategory>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                ExpenseCategory = new List<ExpenseCategory>();
            }
            else
            {
                ExpenseCategory = JsonSerializer.Deserialize<List<ExpenseCategory>>(json);
            }
            return ExpenseCategory;
        }
        public List<IncomeCategory> IncomeCategoryFromJSON()
        {
            if (!File.Exists(IncomeCategoryPath))
            {
                FileStream fs = File.Create(IncomeCategoryPath);
                fs.Close();
                return new List<IncomeCategory>();
            }
            List<IncomeCategory> IncomeCategory = new List<IncomeCategory>();
            string json = File.ReadAllText(ExpenseCategoryPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                IncomeCategory = new List<IncomeCategory>();
            }
            else
            {
                IncomeCategory = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
            }
            return IncomeCategory;
        }
        private Storage() { }

        public static Storage GetInstance()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }
        public 
    }
}
