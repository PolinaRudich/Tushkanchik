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
    class IncomeCategoryLogic
    {
        private Storage _storage = Storage.GetInstance();
        public void CreateCategory(string name)
        {
            IncomeCategory category = new IncomeCategory { Name = name };
            var categories = _storage.IncomeCategoryFromJSON();
            if (categories.Contains(category))
            {
                MessageBox.Show("Такая категория уже существует");
                return;
            }


            categories.Add(category);

            string converted = JsonSerializer.Serialize(categories);
            File.WriteAllText(_storage.IncomeCategoryPath, converted);
        }
    }
}
