using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest.Model
{
    public class ContactData
    {
        private string lastname;
        private string firstname;
        private string address;
        private string mobile;
        private string email;

        public ContactData(string firstname, string lastname, string address, string mobile, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.mobile = mobile;
            this.email = email;

        }


        public ContactData(string name)
        {
            this.firstname = name;

        }
        public string FirstName
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

        public string LastName
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
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public static implicit operator ContactData(string v)
        {
            throw new NotImplementedException();
        }
    }
}