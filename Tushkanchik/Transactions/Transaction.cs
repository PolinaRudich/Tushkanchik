using System;
using Tushkanchik.MoneyAccount;

namespace Tushkanchik.Transactions
{

    public abstract class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Card Card { get; set; }

        public string Comment { get; set; }

        public Transaction(decimal amount, DateTime date, Card card, string comment)
        {
            Amount = amount;
            Date = date;
            Card = card;
            Comment = comment;
        }
    }
}
