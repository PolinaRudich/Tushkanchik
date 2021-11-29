using System;
using Tushkanchik.MoneyAccount;
using Tushkanchik.Transactions;

namespace Tushkanchik
{
    public class IncomeForView
    {
        public decimal amount { get; set; }
        public string cardName { get; set; }
        public Card Card { get; set; }
        public Income income { get; set; }
        public DateTime date { get; set; }
        public string comment { get; set; }
        public string incomeCategoryName { get; set; }

    }
}
