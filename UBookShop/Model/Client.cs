using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    class Client
    {
        public int ID { get; set; }

        public string LName { get; set; }
        public string FName { get; set; }

        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Flag { get; set; }

        public string Username { get; set; }


        public static Client client = new Client();
    }
}
