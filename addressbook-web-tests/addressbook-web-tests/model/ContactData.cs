using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    { 
        private string allPhones;
        private string allEmails;
        private string allData;

        public ContactData(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    if (HomePhone != "" && MobilePhone != "" && WorkPhone != "" && Email != "" && Email2 != "" && Email3 != "" && Address != "")
                    {
                        return (FirstName + CleanUp(LastName) + "\r\n" + CleanUp(Address) + "\r\n"
                        + "H:" + CleanUp(HomePhone) + "M:" + CleanUp(MobilePhone) + "W:" + CleanUp(WorkPhone) + "\r\n"
                        + CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)
                        ).Trim();
                    }
                    else
                    {
                        return (FirstName + CleanUp(LastName)).Trim();
                    }
                }
            }
            set
            {
                allData = value;
            }
        }

        public string AllEmails 
        {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones 
        {
            get
            {
                if(allPhones != null) 
                { 
                    return allPhones; 
                }
                else 
                { 
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim(); 
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Group { get; set; }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryHome { get; set; }

        public string SecondaryNotes { get; set; }

        public string Year { get; set; }

        public bool Equals(ContactData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other)) 
            {
                return true;
            }
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("FirstName:{0}, LastName:{1}", FirstName, LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return 0;
            }
            int i = FirstName.CompareTo(other.FirstName);
            if(i != 0) return i;

            return other.LastName.CompareTo(LastName);
        }
    }
}