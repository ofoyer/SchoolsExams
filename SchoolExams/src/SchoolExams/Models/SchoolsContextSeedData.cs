using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.Models
{
    public class SchoolsContextSeedData
    {
        private SchoolsContext _context;
        private UserManager<SchoolUser> _schoolUser;

        public SchoolsContextSeedData(SchoolsContext context, UserManager<SchoolUser> schoolUser)
        {
            _context = context;
            _schoolUser = schoolUser;
        }

        public async Task EnsureSeedData()
        {
            if (await _schoolUser.FindByEmailAsync("foyero@gmail.com") == null)
            {
                var user = new SchoolUser()
                {
                    UserName = "foyero",
                    Email = "foyero@gmail.com"
                };

                await _schoolUser.CreateAsync(user, "P@ssw0rd!");
            }

            if (!_context.Cities.Any())
            {
                var cities = new List<City>()
               {
                   new City {CityName = "תל אביב" },
                   new City {CityName = "חיפה" },
                   new City {CityName = "ירושלים" },
                   new City {CityName = "נתניה" },
                   new City {CityName = "הרצליה" },
                   new City {CityName = "אשדוד" },
                   new City {CityName = "כפר-סבא" },
                   new City {CityName = "רעננה" },
                   new City {CityName = "הוד השרון" },
                   new City {CityName = "חדרה" },
                   new City {CityName = "נהריה" },
                   new City {CityName = "אשקלון" },
                   new City {CityName = "רמת-גן" }

               };

                _context.Cities.AddRange(cities);

                var school = new School()
                {
                    DateCreated = DateTime.Now,
                    SchoolCity = new City() { CityName = "לוד" },
                    SchoolName = "חורב-בנים",
                    SchoolCode = "203283",
                    Subjects = new List<Subject>()
                    {
                       new Subject() {
                           DateCreated = DateTime.Now,
                           SubjectName ="English",
                           Questionaries = new List<Questionary>()
                           {
                               new Questionary() {QuestName = "016207-2017S1",
                                   Exams = new  List<Exam>() {
                                      new Exam() {ExamName = "0162017-2017S1-A1",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S1-A2",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S1-A3",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S1-A4",DateCreated = DateTime.Now }
                                      }
                               },
                               new Questionary() { QuestName = "016207-2017S2",
                                   Exams = new  List<Exam>() {
                                      new Exam() {ExamName = "0162017-2017S2-A1",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S2-A2",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S2-A3",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "0162017-2017S2-A4",DateCreated = DateTime.Now }
                                      }
                               }

                           }


                       },
                       new Subject() {
                           DateCreated = DateTime.Now,
                           SubjectName ="Matemathic",
                           Questionaries = new List<Questionary>()
                           {
                               new Questionary() {QuestName = "217054-2017S1",
                                   Exams = new  List<Exam>() {
                                      new Exam() {ExamName = "217054-2017S1-A1",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S1-A2",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S1-A3",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S1-A4",DateCreated = DateTime.Now }
                                      }
                               },
                               new Questionary() { QuestName = "217054-2017S2",
                                   Exams = new  List<Exam>() {
                                      new Exam() {ExamName = "217054-2017S2-A1",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S2-A2",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S2-A3",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017S2-A4",DateCreated = DateTime.Now }
                                      }
                               },
                              new Questionary() { QuestName = "217054-2017W",
                                   Exams = new  List<Exam>() {
                                      new Exam() {ExamName = "217054-2017W-A1",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017W-A2",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017W-A3",DateCreated = DateTime.Now },
                                      new Exam() {ExamName = "217054-2017W-A4",DateCreated = DateTime.Now }
                                      }
                               }

                           }


                       }

                    }


                };

                _context.Schools.Add(school);

                _context.Cities.Add(school.SchoolCity);

                _context.Subjects.AddRange(school.Subjects);

               // _context.Questionaries.AddRange(school.Subjects.)
                await _context.SaveChangesAsync();

            }
        }
    }
}
