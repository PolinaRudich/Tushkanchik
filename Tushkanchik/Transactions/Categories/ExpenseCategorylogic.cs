using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Tushkanchik.Transaction.Categories;

namespace Tushkanchik.Transactions.Categories
{
    class ExpenseCategorylogic
    {
        private Storage _storage = Storage.GetInstance();
        public void Create(string name)
        {
            ExpenseCategory category = new ExpenseCategory { Name = name };
            List<ExpenseCategory> categories = _storage.ExpenseCategoryFromJSON();
            if (categories.Contains(category))
            {
                MessageBox.Show("Такая категория уже существует");
                return;
            }
            categories.Add(category);

            string converted = JsonSerializer.Serialize(categories);
            File.WriteAllText(_storage.ExpenseCategoryPath, converted);
        }
    }
}