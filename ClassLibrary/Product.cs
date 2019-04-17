using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Product : Merchant
    {
        private int product_id;
        private String title;
        private String desc;
        private double price;
        private int quantity;
        private String image;
        private int department_id;

        public Product()
        {
        }

        public int Product_ID
        {
            set { this.product_id = value; }
            get { return product_id; }
        }
        
        public String Title
        {
            get { return title; }
            set { title = value; }
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

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public String Image
        {
            set { this.image = value; }
            get { return image; }
        }

        public int Department_ID
        {
            set { department_id = value; }
            get { return department_id; }
        }
    }
}