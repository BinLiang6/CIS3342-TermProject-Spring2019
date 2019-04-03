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
        private int merchant_id;

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

        public int Department_ID
        {
            set { this.department_id = value; }
            get { return department_id; }
        }

        public int Merchant_ID
        {
            set { this.merchant_id = value; }
            get { return merchant_id; }
        }
    }
}