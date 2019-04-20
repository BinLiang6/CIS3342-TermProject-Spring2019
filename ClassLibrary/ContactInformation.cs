using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    [Serializable()]
    public class ContactInformation
    {
        private String name;
        private String address;
        private String city;
        private String state;
        private String zipCode;
        private String email;
        private String phoneNumber;

        public ContactInformation()
        {

        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public String ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Phone
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
