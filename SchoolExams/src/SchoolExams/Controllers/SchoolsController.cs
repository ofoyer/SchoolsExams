using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolExams.Filters;
using SchoolExams.Models;
using SchoolExams.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExams.Controllers
{

    
    [Authorize]
    [ValidateModel]
    public class SchoolsController : Controller
    {
        private ILogger<SchoolsController> _logger;
        private ISchoolsRepository _repository;

        public SchoolsController(ISchoolsRepository repository, ILogger<SchoolsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("")]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetSchoolsByUserName(User.Identity.Name);

                return Ok(Mapper.Map<IEnumerable<School>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Schools: {ex}");

                return BadRequest("Error occurred");
            }

        }

        [HttpPost("")]
        [Route("api/[controller]/new")]
        public async Task<IActionResult> Post([FromBody]SchoolViewModel school)
        {
            try
            {
                // Save to the Database
                _logger.LogInformation("Creating a new school");

                var newSchool = Mapper.Map<School>(school);

                newSchool.UserName = User.Identity.Name;

                _repository.AddSchool(newSchool);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/schools/{school.id}", Mapper.Map<SchoolViewModel>(school));
                }
                else
                {
                    _logger.LogWarning("Could not save school to the database");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Threw exception while saving school: {ex}");
            }

            return BadRequest("Failed to save the school");

        }


        [HttpGet("")]
        [Route("api/[controller]/{schoolid}")]
        public IActionResult GetSchoolById(int schoolid)
        { 

            try
            {
                var results = _repository.GetSchoolByID(schoolid);

                return Ok(Mapper.Map<School>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get school: {ex}");

                return BadRequest("Error occurred");
            }
        }

        [HttpPost("")]
        [Route("api/[controller]/{schoolid}/subjects")]
        public async Task<IActionResult> AddSubjectBySchool([FromBody]SchoolViewModel school)
        {
            try
            {
                var newSubjects = Mapper.Map<ICollection<Subject>>(school.Subjects);
                _repository.AddSubjectBySchool(school.SchoolName, school.UserName, newSubjects);
                if (await _repository.SaveChangesAsync())
                {

                    return Created($"api/schools/{school.id}/subjects", Mapper.Map<IEnumerable<SubjectViewModel>>(newSubjects));
                }
                else
                {
                    _logger.LogWarning("Could not save school's subjects to the database");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Threw exception while saving school's subjects: {ex}");
            }



            return BadRequest("Failed to add new school subjects");



        }
    }
}