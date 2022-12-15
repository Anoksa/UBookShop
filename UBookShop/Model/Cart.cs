using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBookShop.Model
{
    public class Cart
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public string Author { get; set; }
        public string Publish { get; set; }
        public int PublYear { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Cart() { }

        public Cart(int id, string title, string categories, string author, string publish, int publYear, float price, int quantity)
        {
            this.ID = id;
            this.Title = title;
            this.Categories = categories;
            this.Author = author;
            this.Publish = publish;
            this.PublYear = publYear;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
