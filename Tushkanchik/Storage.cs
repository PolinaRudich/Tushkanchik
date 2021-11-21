using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public sealed class Storage
    {
        public List<Card> Cards { get; set; }
        public List<User> Users { get; set; }
       //cохрание категорий
        
        private static Storage _storage;

        private Storage() { }

        public static Storage GetInstance()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }
    }
}
