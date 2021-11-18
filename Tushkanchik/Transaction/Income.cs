using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tushkanchik;
using System.Threading.Tasks;

namespace Tushkanchik.Transaction
{
    class Income: Transaction
    {
        public Income(decimal amount, int card, string category)
            : base (amount, card, category)
        {
        }
    }
}
