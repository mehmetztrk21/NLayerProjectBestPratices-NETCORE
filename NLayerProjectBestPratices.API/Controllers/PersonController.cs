using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProjectBestPratices.Core.Entity;
using NLayerProjectBestPratices.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericService<Person> _personService;

        public PersonController(IGenericService<Person> genericService)
        {
            _personService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var addPerson = await _personService.AddAsync(person);
            return Created(string.Empty, addPerson);
        }
        [HttpPut]
        public IActionResult Update(Person person)
        {
            var updatePerson = _personService.Update(person);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);
            return NoContent();
        }
    }
}
