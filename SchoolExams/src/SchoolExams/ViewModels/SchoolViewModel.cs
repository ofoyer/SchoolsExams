using SchoolExams.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.ViewModels
{
    public class SchoolViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 4)]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string SchoolCode { get; set; }

        //[Required]
        //[StringLength(4, MinimumLength = 10)]
        public string UserName { get; set; }

        public Models.City SchoolCity { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
