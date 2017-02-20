using System;
using System.Collections.Generic;

namespace SchoolExams.Models
{
    public class Subject
    {
        public int id { get; set; }
        public string  SubjectName { get; set; }
        public ICollection<Questionary> Questionaries { get; set; }
        public DateTime DateCreated { get; set; }
    }
}