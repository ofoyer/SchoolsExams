using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using SchoolExams.Filters;
using SchoolExams.Models;
using SchoolExams.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ValidateModel]
    public class SubjectsController : Controller
    {
        private ILogger<SubjectsController> _logger;
        private ISchoolsRepository _repository;

        public SubjectsController(ISchoolsRepository repository, ILogger<SubjectsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllSubjects();

                return Ok(Mapper.Map<IEnumerable<SubjectViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Subject: {ex}");

                return BadRequest("Error occurred");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                // Save to the Database
                var newSubject = Mapper.Map<Subject>(subject);

                _repository.AddSubject(newSubject);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/subjects/{subject.SubjectName}", Mapper.Map<SubjectViewModel>(subject));
                }

            }

            return BadRequest("Failed to save the subject");

        }

        
    }
}
