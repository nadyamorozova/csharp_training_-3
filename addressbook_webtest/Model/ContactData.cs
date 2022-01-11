using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string lastname;
        private string firstname;
        private string middlename = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
           
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return firstname == other.firstname && lastname == other.lastname;

        }

        public override int GetHashCode()
        {
            return firstname.GetHashCode() & lastname.GetHashCode();

        }

        public override string ToString()
        {
            return $"contact = {lastname} {firstname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.firstname != other.firstname)
            {
                return firstname.CompareTo(other.firstname);
            }
            if (this.lastname != other.lastname)
            {
                return lastname.CompareTo(other.lastname);
            }
            return lastname.CompareTo(other.lastname) & firstname.CompareTo(other.firstname);
   
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
       
        public string Middlename 
         {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
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