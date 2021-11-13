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

    }
}
