using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tushkanchik
{

    public  abstract class CashAccount
    {
        private  int? _index { get;   set; }
        private List<User> _holders { get; set; }
        private decimal _balance { get; set; }
        private string _name { get;set; }
        private bool _percent { get;  set; }
        private bool _withdrawal { get; set; }
        private bool _replacement { get; set; }
        //public double _cashback { get; set; }
        public CashAccount()
        {
            _index = null;
            _balance = 0;
            _name = "";
            _holders = new List<User>();
            _percent =false;
            _withdrawal = false;
            _replacement = false;
           
        }
        public CashAccount(int idx,string name,User holder,bool percent,bool withdrawal,bool replacement)
        {
            _index = idx;
            _balance = 0;
            _name = name;
            _holders.Add(holder);
            _percent = percent;
            _withdrawal = withdrawal;
            _replacement = replacement;
         
        }
        public void ChangeName(string name)
        {
            _name = name;
        }
        public void AddBalance(decimal diff)
        {

            _balance += diff;
        }
        public void RemoveBalance(decimal diff)
        {
            _balance -= diff;
        }

        public void AddHolder(User user)
        {
            _holders.Add(user);
        }
        public void DeleteHolder(User user)
        {
            _holders.Remove(user);
        }
    }
}
