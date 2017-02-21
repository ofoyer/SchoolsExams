using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolExams.Models
{
    public class SchoolUser: IdentityUser
    {
        public string Gender { get; set; }

    }
}