using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    { 
        private string allPhones;
        private string allEmails;
        private string allData;

        public ContactData() {}

        public ContactData(string name = "", string surname = "")
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
                    string name = "";
                    if (FirstName != "" && LastName == "")
                    {
                        name = FirstName + "\r\n";
                    }
                    if (FirstName == "" && LastName != "")
                    {
                        name = LastName + "\r\n";
                    }
                    if (FirstName != "" && LastName != "")
                    {
                        name = FirstName + " " + LastName;
                    }
                    if (Address != "")
                    {
                        name = name + "\r\n" + Address;
                    }
                    if (HomePhone != "" || MobilePhone != "" || WorkPhone != "")
                    {
                        name = name + "\r\n\r\n";
                    }
                    if (HomePhone != "")
                    {
                        name = name + "H: " + HomePhone;
                    }
                    if (MobilePhone != "" && HomePhone != "")
                    {
                        name = name + "\r\n" + "M: " + MobilePhone;
                    }
                    else if(MobilePhone != "" && HomePhone == "")
                    {
                        name = name + "M: " + MobilePhone;
                    }
                    if (WorkPhone != "" && (HomePhone != "" || MobilePhone != ""))
                    {
                        name = name + "\r\n" + "W: " + WorkPhone;
                    }
                    else if (WorkPhone != "" && HomePhone == "" && MobilePhone == "")
                    {
                        name = name + "W: " + WorkPhone;
                    }
                    if (Email != "" || Email2 != "" || Email3 != "")
                    {
                        name = name + "\r\n\r\n";
                    }
                    if (Email != "")
                    {
                        name = name + Email;
                    }
                    if (Email2 != "" && Email != "")
                    {
                        name = name + "\r\n" + Email2;
                    }
                    if (Email2 != "" && Email == "")
                    {
                        name = name + Email2;
                    }
                    if (Email3 != "" && (Email != "" || Email2 != ""))
                    {
                        name = name + "\r\n" + Email3;
                    }
                    if (Email3 != "" && Email == "" && Email2 == "")
                    {
                        name = name + Email3;
                    }
                    return name;

                }
            }
            set
            {
                allData = value;
            }
        }

        public string Return_String(List<string> list_string)
        {
            string str = "";

            for (int i = 0; i < list_string.Count; i++)
            {
                if (i != list_string.Count - 1)
                    str += list_string[i] + "\r\n";
                else
                    str += list_string[i] + "\r\n\r\n";
            }
            return str;
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

        //private string AddBr(string element)
        //{
            //string name = (element != "") ? element + "\r\n" : "";

            //return name;
        //}


        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, @"[ -()]", "") + "\r\n";
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