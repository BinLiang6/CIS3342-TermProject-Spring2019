using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Order
    {
        private int quantity;
        private int product_id;
        private String apikey;
        private String seller_site;
        private int customer_id;
        private String name;
        private String address;
        private String email;
        private String phone;

        public Order()
        {
        }

        public int Quantity
        {
            set { this.quantity = value; }
            get { return quantity; }
        }

        public int Product_ID
        {
            set { this.product_id = value; }
            get { return product_id; }
        }

        public String Apikey
        {
            set { this.apikey = value; }
            get { return apikey; }
        }

        public String Seller_site
        {
            set { this.seller_site = value; }
            get { return seller_site; }
        }

        public int Customer_ID
        {
            set { this.customer_id = value; }
            get { return customer_id; }
        }

        public String Name
        {
            set { this.name = value; }
            get { return name; }
        }

        public String Address
        {
            set { this.address = value; }
            get { return address; }
        }

        public String Phone
        {
            set { this.phone = value; }
            get { return phone; }
        }

        public String Email
        {
            set { this.email = value; }
            get { return email; }
        }
    }
}