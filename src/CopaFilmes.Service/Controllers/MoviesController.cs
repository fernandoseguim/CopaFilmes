using System;
using System.Collections.Generic;
using CopaFilmes.Api.Domain.Commands;
using CopaFilmes.Api.Domain.Queries;
using CopaFilmes.Api.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Service.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
	{
		private readonly IMoviesRepository moviesRepository;
	    public MoviesController(IMoviesRepository moviesRepository) 
		    => this.moviesRepository = moviesRepository;

		// GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieQueryResult>> Get()
        {
	        var movies = this.moviesRepository.GetMovies();
	        try
	        {
		        return Ok(movies);
			}
	        catch (Exception)
	        {
		        return StatusCode(500, "There was an error saving the user, please contact your system administrator.");
	        }
        }

		// POST api/movies/winners
		[HttpPost("/movies/winners")]
        public ActionResult<IEnumerable<MovieCommand>> Post([FromBody] MovieCommand movieCommand)
		{
			return Ok();
		}
    }
}
