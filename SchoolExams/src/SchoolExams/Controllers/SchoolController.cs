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

    [Route("api/schools")]
    [Authorize]
    public class SchoolController : Controller
    {
        private ILogger<SchoolController> _logger;
        private ISchoolsRepository _repository;

        public SchoolController(ISchoolsRepository repository, ILogger<SchoolController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("")]
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
                    return Created($"api/schools/{school.SchoolName}", Mapper.Map<SchoolViewModel>(school));
                }
            }

            return BadRequest("Failed to save the school");

        }
    }
}