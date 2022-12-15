using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PName { get; set; }

        public Publisher() { }

        public Publisher(int id, string pName)
        {
            this.ID = id;
            this.PName = pName;
        }
    }
}
