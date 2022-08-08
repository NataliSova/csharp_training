﻿namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firsName="";
        private string middleName="";
        private string lastName = "";
        private string nickname = "";
        private string photo;
        private string title = "";
        private string company = "";
        private string address = "";
        private string homeTelephone = "";
        private string mobileTelephone = "";
        private string workTelephone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthday = "";
        private string anniversary = "";
        private string group = "";
        private string secondaryAddress = "";
        private string secondaryHome = "";
        private string secondaryNotes = "";
        private string year = "2000";

        public ContactData(string name, string surname)
        {
            this.firsName = name;
            this.middleName = surname;
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public string FirsName
        {
            get { return firsName; }
            set { firsName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string HomeTelephone
        {
            get { return homeTelephone; }
            set { homeTelephone = value; }
        }

        public string MobileTelephone
        {
            get { return mobileTelephone; }
            set { mobileTelephone = value; }
        }

        public string WorkTelephone
        {
            get { return workTelephone; }
            set { workTelephone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Anniversary
        {
            get { return anniversary; }
            set { anniversary = value; }
        }

        public string SecondaryAddress
        {
            get { return secondaryAddress; }
            set { secondaryAddress = value; }
        }

        public string SecondaryHome
        {
            get { return secondaryHome; }
            set { secondaryHome = value; }
        }

        public string SecondaryNotes
        {
            get { return secondaryNotes; }
            set { secondaryNotes = value; }
        }

        public string Year { get => year; set => year = value; }
    }
}
