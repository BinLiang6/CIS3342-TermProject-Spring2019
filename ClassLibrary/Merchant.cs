using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Merchant: Customer
    {
        private String apikey;
        private String seller_site;
        private String desc;
        private String url;
        private String password;

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

        public String Url
        {
            set { this.url = value; }
            get { return url; }
        }

        public String Password
        {
            set { this.password = value; }
            get { return password; }
        }

    }
}