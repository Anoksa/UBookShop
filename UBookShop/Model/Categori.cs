using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    public class Categori
    {
        public int ID { get; set; }
        public string CategoriName { get; set; }
        
        public Categori() { }

        public Categori(int id, string categoriy)
        {
            this.ID = id;
            this.CategoriName = categoriy;
        }
    }
}
