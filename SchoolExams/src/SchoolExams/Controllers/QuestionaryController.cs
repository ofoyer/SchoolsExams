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
    public class QuestionaryController : Controller
    {
        private ILogger<QuestionaryController> _logger;
        private ISchoolsRepository _repository;

        public QuestionaryController(ISchoolsRepository repository, ILogger<QuestionaryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllCities();

                return Ok(Mapper.Map<IEnumerable<QuestionaryViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Questionaries: {ex}");

                return BadRequest("Error occurred");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuestionaryViewModel questionary)
        {


            // Save to the Database
            try
            {
                var newQuestionary = Mapper.Map<Questionary>(questionary);

                _repository.AddQuestionary(newQuestionary);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/questionaries/{questionary.QuestName}", Mapper.Map<QuestionaryViewModel>(questionary));
                }
                else
                {
                    _logger.LogWarning("Could not save questionary to the database");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Threw exception while saving questionary: {ex}");
            }



            return BadRequest("Failed to save the questionary");


        }
    }
}
