using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string address;
        private string mobile;
        private string email;
    
       public ContactData(string firstname, string lastname, string address, string mobile, string email)
        {
            
         this.firstname = firstname;
         this.lastname = lastname;
       }

        public ContactData(string v)
        {
            lastname = v;
        }

        public ContactData(string v, string v1) : this(v)
        {
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
            return firstname.GetHashCode() & firstname.GetHashCode();
        }

        public override string ToString()
        {
            return $"contact = " + firstname + " " +lastname;
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
       
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}

