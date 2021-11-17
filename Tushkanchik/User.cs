using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
     public class User
    {

        public string _name;
       
        public User()
        {
           
            _name = "";
        }
        public User( string name)
        {
           
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        //AddUser DeleteUser при создании 2 юзера всплывает сообщение учитывать его в оьщей
        //статистики ил нет если да то создается аккаунт юзерфемели(фемели создается 1 раз)
     
        public bool IsIn(List<User> users)
        {
            foreach(User user in users)
            {
                if ( user._name == this._name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
