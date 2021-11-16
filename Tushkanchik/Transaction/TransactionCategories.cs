using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    class TransactionCategories
    {
        private List<string> _incomeCategories { get; set; }
        private List<string> _dependenciesCategories { get; set; }
         public TransactionCategories()
        {
            _incomeCategories = new List<string>();
            _dependenciesCategories = new List<string>();
        }
        public bool CheckCategoryIncome(string category)
        {
           return _incomeCategories.Contains(category);
            
        }
        public bool CheckCategoryDependencies(string category)
        {
            return _dependenciesCategories.Contains(category);

        }
       
        public void AddIncomeCategory(string category)
        {
            if (CheckCategoryIncome(category) == false)
            {
                _incomeCategories.Add(category);
            }
            else
            {
                throw new Exception("такая категория существует");
            }
        }
        public void AddDependenciesCategory(string category)
        {
            if (CheckCategoryDependencies(category) == false)
            {
                _dependenciesCategories.Add(category);
            }
            else
            {
                throw new Exception("такая категория существует");
            }
        }
        public void DeleteIncomeCategory(string category)
        {
            if (CheckCategoryIncome(category) == true)
            {
                _incomeCategories.Remove(category);
            }
            else
            {
                throw new Exception("такой категории нет");
            }
        }
        public void DeleteDependenciesCategory(string category)
        {
            if (CheckCategoryIncome(category) == true)
            {
                _dependenciesCategories.Remove(category);
            }
            else
            {
                throw new Exception("такой категории нет");
            }
        }
    }
}
