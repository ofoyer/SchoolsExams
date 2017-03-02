using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolExams.Models;
using SchoolExams.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExams.Controllers
{
    public class QuestionaryController:Controller
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
                _logger.LogError($"Failed to get All Subject: {ex}");

                return BadRequest("Error occurred");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]QuestionaryViewModel questionary)
        {

            if (ModelState.IsValid)
            {
                // Save to the Database
                var newQuestionary = Mapper.Map<Questionary>(questionary);

                _repository.AddQuestionary(newQuestionary);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/questionaries/{questionary.QuestName}", Mapper.Map<QuestionaryViewModel>(questionary));
                }

            }

            return BadRequest("Failed to save the city");


        }
    }
}
