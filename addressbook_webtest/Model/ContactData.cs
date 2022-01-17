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
        private string middlename = "";
        private string lastname;
        internal string Middlename;
        internal string LastName;
        private string v;
        internal object Lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public ContactData(string v)
        {
            this.v = v;
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
            return Firstname == other.firstname && lastname == other.lastname;

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
            return lastname.CompareTo(other.lastname) & firstname.CompareTo(other.Firstname);
        }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

    }
}