using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik.Transaction
{
    public abstract class Transaction
    {
        private decimal _amount;
        private DateTime  _date;
        private int _card;
        private string _category;
        // Если надо вводить старую транзакцию,
        // вынести создание _date из конструктора
        // и добавить его в параметры метода
        public Transaction(decimal amount, int card, string category)
        {
            _amount = amount;
            _date = new DateTime();
            _card = card;
            _category = category;
        }
        public decimal GetAmount()
        {
            return _amount;
        }
        public int GetCard()
        {
            return _card;
        }
        public string GetCategory()
        {
            return _category;
        }
        public DateTime GetDate()
        {
            return _date;
        }

    }
}
