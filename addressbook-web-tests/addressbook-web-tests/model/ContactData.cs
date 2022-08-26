using System;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    { 
        private string year = "2000";

        public ContactData(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
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

        public string HomeTelephone { get; set; }

        public string MobileTelephone { get; set; }

        public string WorkTelephone { get; set; }

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

        public string Year { get => year; set => year = value; }

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