using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class CustomerInfo
    {
        private String name;
        private String address;
        private String email;
        private String phone;

        public CustomerInfo()
        {
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