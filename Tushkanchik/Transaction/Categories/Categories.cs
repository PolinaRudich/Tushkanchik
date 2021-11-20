using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik.Transaction.Categories
{
    public abstract class Categories
    {
        public  List<IncomeCategory> IncomeCategories  { get; set; }
        public  List<ExpenseCategory> ExpenseCategory { get; set; }

        public Categories()
        {
            IncomeCategories = new List<IncomeCategory>();
            ExpenseCategory = new List<ExpenseCategory>();
        }
       
    }
}
