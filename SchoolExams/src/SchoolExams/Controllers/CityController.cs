using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/cities")]
    [Authorize]
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
                var results = _repository.GetAllCities();

                return Ok(Mapper.Map<IEnumerable<CityViewModel>>(results));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Subject: {ex}");

                return BadRequest("Error occurred");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CityViewModel city)
        {

            if (ModelState.IsValid)
            {
                // Save to the Database
                var newCity = Mapper.Map<City>(city);

                _repository.AddCity(newCity);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/cities/{city.CityName}", Mapper.Map<CityViewModel>(city));
                }

            }

            return BadRequest("Failed to save the city");


        }
    }
}
