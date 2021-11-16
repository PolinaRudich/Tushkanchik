using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
     public class User
    {
        private int? _index;
        private string _name;
        public User()
        {
            _index = null;
            _name = "";
        }
        public User(int idx, string name)
        {
            _index = idx;
            _name = name;
        }
        //AddUser DeleteUser при создании 2 юзера всплывает сообщение учитывать его в оьщей
        //статистики ил нет если да то создается аккаунт юзерфемели(фемели создается 1 раз)
     

    }
}
