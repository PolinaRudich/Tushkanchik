using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik.Transaction.Categories
{
    public class ExpenseCategory
    {
        public string Name { get; set; }

        public ExpenseCategory(string name)
        {
            Name = name;
        }
    }
}
