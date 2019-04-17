using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Customer : ContactInformation
    {
        private String customer_id;
        private String username;
        
        public Customer()
        {

        }

        public String Customer_ID
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
