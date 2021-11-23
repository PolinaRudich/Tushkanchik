using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
     public class Card
    {
        
        public List<User> Holders { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public Card(List<User> holders, decimal balance, string name)
        {
            Holders = holders;
            Balance = balance;
            Name = name;
        }
        public bool IfHoldersContainsUser(User user)

        {
            foreach (User holder in Holders)
            {
                if (holder.Name ==  user.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
