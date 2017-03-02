using SchoolExams.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.ViewModels
{
    public class ExamViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(15,MinimumLength =6)]
        public string ExamName { get; set; }
        public DateTime DateCreated { get; set; }

        public Questionary Questionary { get; set; }
    }
}
