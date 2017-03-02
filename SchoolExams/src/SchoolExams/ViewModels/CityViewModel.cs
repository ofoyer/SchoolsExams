using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.ViewModels
{
    public class CityViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(10,MinimumLength = 4)]
        public string CityName { get; set; }
    }
}
