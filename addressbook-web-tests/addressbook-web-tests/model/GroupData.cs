﻿using System;

namespace WebAddressbookTests
{
    public class GroupData: IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(){}

        public GroupData(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
     
        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return 0;
            }
            return other.Name.CompareTo(Name);
        }
    }
}
