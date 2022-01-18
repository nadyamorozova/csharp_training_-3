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
            
          Firstname = firstname;
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
            return Firstname == other.Firstname;  
            return Lastname == other.Lastname;

        }

        public override int GetHashCode()
        {
        return Firstname.GetHashCode();
        return Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return $"contact = " + Firstname + " " +Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Firstname != other.Firstname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Lastname.CompareTo(other.Lastname) & Firstname.CompareTo(other.Firstname);
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
         public string Mobile { get; set; }
        public string Email { get; set; }

    }
}

