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

                await _context.SaveChangesAsync();

            }
        }
    }
}
