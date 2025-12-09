using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Food : BaseEntity
    {
        private string name;
        private float price;
        private string image;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public Food()
        {

        }
        public Food(string name, float price, string image)
        {
            this.name = name;
            this.price = price;
            this.image = image;
        }
    }
}
