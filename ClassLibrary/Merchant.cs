using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Merchant
    {
        private String apikey;
        private String seller_site;
        private String desc;
        private String email;
        private String phone;

        public Merchant()
        {
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

        public String Desc
        {
            set { this.desc = value; }
            get { return desc; }
        }

        public String Email
        {
            set { this.email = value; }
            get { return email; }
        }

        public String Phone
        {
            set { this.phone = value; }
            get { return phone; }
        }
    }
}