using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    class Contact
    {
        private string lastname;
        private string firstname;

        public Contact(string lastname, string firstname)
        {
            this.lastname = lastname;
            this.firstname = firstname;
        }


        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }

        }
    }
}