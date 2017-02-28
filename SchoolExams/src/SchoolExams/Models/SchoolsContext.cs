using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.Models
{
    public class SchoolsContext: IdentityDbContext<SchoolUser>
    {
        private IConfigurationRoot _config;

        public SchoolsContext(IConfigurationRoot Config,DbContextOptions options):base(options)
        {
            _config = Config;
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Questionary> Questionaries { get; set; }
        public DbSet<Exam> Exams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["connectionStrings:SchoolExamsConnectionString"]);
        }
    }
}
