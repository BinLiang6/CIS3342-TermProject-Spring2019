using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    [Serializable]
    public class Cart
    {
        private int customer_id;
        private String image;
        private String title;
        private String desc;
        private int quantity;
        private double price;
        private int product_id;

        public int Customer_ID
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public String Image
        {
            get { return image; }
            set { image = value; }
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

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Price
        {
            set { this.price = value; }
            get { return price; }
        }

        public int Product_ID
        {
            set { this.product_id = value; }
            get { return product_id; }
        }
    }
}