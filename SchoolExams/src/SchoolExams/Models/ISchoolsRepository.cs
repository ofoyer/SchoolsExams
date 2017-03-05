using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.Models
{
    public interface ISchoolsRepository
    {
        IEnumerable<School> GetAllSchools();
        IEnumerable<Subject> GetAllSubjects();
        IEnumerable<City> GetAllCities();
        IEnumerable<Questionary> GetAllQuestionaries();
        IEnumerable<Exam> GetAllExams();
        School GetSchoolByName(string school, string userName);
        void AddSchool(School school);

        void AddSubjectBySchool(string schoolName, string userName, IEnumerable<Subject> subjects);

        Object GetSchoolByID(int id);
        void AddSubject(Subject subject);
        void AddCity(City city);
        void AddQuestionary(Questionary questionary);
        void AddExam(Exam exam);
        IEnumerable<Exam> GetExamsByQuestName(string questName);
        Task<bool> SaveChangesAsync();
        Object GetSchoolsByUserName(string userName);
    }
}
