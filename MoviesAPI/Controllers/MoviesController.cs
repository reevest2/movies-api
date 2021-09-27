using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Controllers;
using MovieAPI.Repositories;
using MovieAPI.Services;


namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _service.GetAll();
            return Ok(movies);

        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateRequest request)
        {
            var movie = await _service.Create(request);
            return Created($"/movies/{movie.Id}", movie);
             
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, MovieUpdateRequest request)
        {
            var resource = await _service.Update(id, request);
            return Ok(resource);
        }

    }
}
