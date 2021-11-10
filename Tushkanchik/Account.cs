using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tushkanchik
{

    public class Account
    {
        private int _index;
        private double _balance;
        private string _name;
        private int _numberOfAccount;
        public Account()
        {
            _balance = 0;
            _name = "";
            _numberOfAccount = 0;
            _index = 0;

        }
        public Account(int index, double balance, string name, int numberOfAccount)
        {
            _index = index;
            _balance = balance;
            _name = name;
            _numberOfAccount = numberOfAccount;
        }
        public void ChangeName(string name)
        {
            _name = name;
        }
        public void ChangeBalance(string balance)
        {
            _balance = Convert.ToDouble(balance);
        }

    }
}
