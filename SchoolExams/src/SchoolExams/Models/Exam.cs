using System;

namespace SchoolExams.Models
{
    public class Exam
    {
        public int id { get; set; }
        public string ExamName { get; set; }
        public DateTime DateCreated { get; set; }

        public Questionary Questionary { get; set; }
    }
}