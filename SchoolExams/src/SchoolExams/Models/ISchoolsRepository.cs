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
        School GetSchoolByName(string school, string userName);
        void AddSchool(School school);
        void AddSubject(string schoolName, string userName, Subject subject);
        void AddCity(City city);
        void AddQuestionary(Questionary questionary);
        void AddExam(Exam exam);
        IEnumerable<Exam> GetExamsByQuestName(string questName);
        Task<bool> SaveChangesAsync();
        Object GetSchoolsByUserName(string userName);
    }
}
