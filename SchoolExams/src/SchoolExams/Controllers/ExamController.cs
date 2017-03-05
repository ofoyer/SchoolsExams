using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    [ValidateModel]
    public class ExamController:Controller
    {
        private ILogger<CityController> _logger;
        private ISchoolsRepository _repository;

        public ExamController(ISchoolsRepository repository, ILogger<CityController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllExams();

                return Ok(Mapper.Map<IEnumerable<ExamViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Exams: {ex}");

                return BadRequest("Error occurred");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExamViewModel exam)
        {


            // Save to the Database
            try
            {
                var newExam = Mapper.Map<Exam>(exam);

                _repository.AddExam(newExam);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/exams/{exam.ExamName}", Mapper.Map<ExamViewModel>(exam));
                }
                else
                {
                    _logger.LogWarning("Could not save exam to the database");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Threw exception while saving exam: {ex}");
            }

            

            return BadRequest("Failed to save the exam");


        }
    }
}
