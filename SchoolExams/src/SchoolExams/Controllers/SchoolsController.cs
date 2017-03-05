using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        [Route("api/schools")]
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
        [Route("api/schools/new")]
        public async Task<IActionResult> Post([FromBody]SchoolViewModel school)
        {
            if (ModelState.IsValid)
            {
                // Save to the Database
                var newSchool = Mapper.Map<School>(school);

                newSchool.UserName = User.Identity.Name;

                _repository.AddSchool(newSchool);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/schools/{school.id}", Mapper.Map<SchoolViewModel>(school));
                }
            }

            return BadRequest("Failed to save the school");

        }


        [HttpGet("")]
        [Route("api/schools/{schoolid}")]
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
        [Route("api/schools/{schoolId}/subjects")]
        public async Task<IActionResult> AddSubjectBySchool([FromBody]SchoolViewModel school)
        {
            if (ModelState.IsValid)
            {
                var newSubjects = Mapper.Map<ICollection<Subject>>(school.Subjects);
                _repository.AddSubjectBySchool(school.SchoolName, school.UserName, newSubjects);
                if (await _repository.SaveChangesAsync())
                {

                    return Created($"api/schools/{school.id}/subjects", Mapper.Map<IEnumerable<SubjectViewModel>>(newSubjects));
                }



            }

            return BadRequest("Failed to add new school subjects");



        }
    }
}