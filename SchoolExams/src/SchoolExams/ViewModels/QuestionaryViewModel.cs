using SchoolExams.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.ViewModels
{
    public class QuestionaryViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(10,MinimumLength = 4)]
        public string QuestName { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public Subject Subject { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
