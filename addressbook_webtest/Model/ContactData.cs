using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        internal object Id;

        public ContactData(string firstname, string lastname, string address, string mobile, string email)
        {
            
         Firstname = firstname;
         Lastname = lastname;
         Address = address;
         Mobile = mobile;
         Email = email;
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
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Firstname.GetHashCode();
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
        public override string ToString()
        {
            return $"contact = {Lastname} {Firstname}";
        }
        public ContactData (string name)
        {
            Firstname = name;
        }
        public ContactData(string name, string lastname)
        {
            Firstname = name;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}

