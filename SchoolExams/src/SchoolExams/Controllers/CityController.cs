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
using System.Threading.Tasks;

namespace SchoolExams.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class CityController:Controller
    {
        private ILogger<CityController> _logger;
        private ISchoolsRepository _repository;

        public CityController(ISchoolsRepository repository, ILogger<CityController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Try to get all cities");
                var results = _repository.GetAllCities();

                return Ok(Mapper.Map<IEnumerable<CityViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Cities: {ex}");

                return BadRequest("Error occurred");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CityViewModel city)
        {

            // Save to the Database
            try
            {
                var newCity = Mapper.Map<City>(city);

                _repository.AddCity(newCity);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/cities/{city.CityName}", Mapper.Map<CityViewModel>(city));
                }
                else
                {

                    _logger.LogWarning("Could not save city to the database");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Threw exception while saving city: {ex}");
            }


            return BadRequest("Failed to save the city");


        }
    }
}
