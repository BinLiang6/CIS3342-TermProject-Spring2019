using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Customer : ContactInformation
    {
        private String customerID;
        private String username;
        private String password;
        private String sq1;
        private String sq2;
        private String sq3;
        
        public Customer()
        {

        }

        public String CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Sq1
        {
            get { return sq1; }
            set { sq1 = value; }
        }

        public String Sq2
        {
            get { return sq2; }
            set { sq2 = value; }
        }

        public String Sq3
        {
            get { return sq3; }
            set { sq3 = value; }
        }


    }
}
