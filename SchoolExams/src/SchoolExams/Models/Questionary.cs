using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolExams.Models
{
    public class Questionary
    {
        public int id { get; set; }
        public string QuestName { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public  Subject Subject { get; set; }
        public DateTime DateCreated { get; set; }
    }
}