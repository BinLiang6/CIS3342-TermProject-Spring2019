using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary
{
    public class Department
    {
        private int department_id;
        private String name;

        public Department()
        {
        }

        public int Department_ID
        {
            set { this.department_id = value; }
            get { return department_id; }
        }

        public String Name
        {
            set { this.name = value; }
            get { return name; }
        }
    }
}