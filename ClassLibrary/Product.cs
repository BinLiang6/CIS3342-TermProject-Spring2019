using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Product
    {
        private int product_id;
        private String desc;
        private double price;
        private String image;
        private int department_id;
        private String apikey;

        public Product()
        {
        }

        public int Product_ID
        {
            set { this.product_id = value; }
            get { return product_id; }
        }

        public String Desc
        {
            set { this.desc = value; }
            get { return desc; }
        }

        public double Price
        {
            set { this.price = value; }
            get { return price; }
        }

        public String Image
        {
            set { this.image = value; }
            get { return image; }
        }
    }
}