using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "id")]
        public string Id { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Name:{0}", Name);
        }

        public int CompareTo(ProjectData other)
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

        public static List<ProjectData> GetAll()
        {
            using (BugtrackerDB db = new BugtrackerDB())
            {
                List<ProjectData> projects = new List<ProjectData>();
                projects = (from c in db.Projects select c).ToList();
                return projects;
            }
        }
    }
}
