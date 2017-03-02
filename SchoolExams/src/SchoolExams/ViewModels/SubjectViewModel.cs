using SchoolExams.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.ViewModels
{
    public class SubjectViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(15,MinimumLength = 4)]
        public string SubjectName { get; set; }
        public ICollection<Questionary> Questionaries { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
