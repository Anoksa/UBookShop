using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BDate { get; set; }

        public Author() { }

        public Author(int id, string name, DateTime bDate)
        {
            this.ID = id;
            this.Name = name;
            this.BDate = bDate;
        }

    }
}
