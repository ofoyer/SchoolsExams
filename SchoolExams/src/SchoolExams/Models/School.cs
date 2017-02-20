using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.Models
{
    public class School
    {
        public int id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public City SchoolCity { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
