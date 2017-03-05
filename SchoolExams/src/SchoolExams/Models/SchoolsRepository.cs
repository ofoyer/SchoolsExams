using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.Models
{
    public class SchoolsRepository : ISchoolsRepository
    {
        private SchoolsContext _context;
        private ILogger<SchoolsRepository> _logger;

        public SchoolsRepository(SchoolsContext context, ILogger<SchoolsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<School> GetAllSchools()
        {
            _logger.LogInformation("Getting All Schools From Database");

            return _context.Schools.ToList();
        }


        public School GetSchoolByName(string schoolName, string userName)
        {
            return _context.Schools
                .Include(t => t.Subjects)
                .Where(t => t.SchoolName == schoolName && t.UserName == userName)
                .FirstOrDefault();
        }

        public void AddSchool(School school)
        {
            _context.Add(school);
        }

        public void AddSubjectBySchool(string schoolName, string userName, IEnumerable<Subject> subjects)
        {
            var school = GetSchoolByName(schoolName, userName);
            if (school != null)
                school.Subjects.ToList().AddRange(subjects);
        }
        public Object GetSchoolById(int id)
        {
            return _context.Schools.FirstOrDefault(t => t.id == id);

        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }
        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public IEnumerable<Questionary> GetAllQuestionaries()
        {
            return _context.Questionaries.ToList();
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return _context.Exams.ToList();
        }

        public void AddCity(City city)
        {
            _context.Add(city);
        }

        public void AddQuestionary(Questionary questionary)
        {
            _context.Add(questionary);
        }

        public void AddExam(Exam exam)
        {
            _context.Add(exam);
        }

        public IEnumerable<Exam> GetExamsByQuestName(string questName)
        {
            var questionary = _context.Questionaries
                .Where(q => q.QuestName == questName)
                .FirstOrDefault();

            if (questionary != null)
                return questionary.Exams.ToList();
            else
                return new List<Exam>();

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Object GetSchoolsByUserName(string userName)
        {
            return null;
        }

    }
}
