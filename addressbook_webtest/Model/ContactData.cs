using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_webtest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname, string address, string mobile, string email)
        {

            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            MobilePhone = mobile;
            WorkPhone = WorkPhone;
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
        public ContactData(string name)
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
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string WorkPhone { get; internal set; }
        public string Id { get; set; }
        public string AllPhones


        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUp(Email.Trim()) + CleanUp(Email2.Trim()) + CleanUp(Email3.Trim());
                }
            }
            set
            {
                allEmails = value;
            }
        }
             private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}

     
 

