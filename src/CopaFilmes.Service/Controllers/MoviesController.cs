using System;
using System.Collections.Generic;
using CopaFilmes.Service.Domain.Commands;
using CopaFilmes.Service.Domain.Handlers;
using CopaFilmes.Service.Domain.Queries;
using CopaFilmes.Service.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Service.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
	{
		private readonly IMoviesRepository repository;
		private readonly IMoviesHandler handler;

		public MoviesController(IMoviesRepository repository, IMoviesHandler handler)
		{
			this.repository = repository;
			this.handler = handler;
		}

		// GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieQueryResult>> Get()
        {
	        var movies = this.repository.GetMovies();
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
		[HttpPost("winners")]
        public ActionResult<IEnumerable<MovieCommand>> Post([FromBody] MoviesCommand moviesCommand)
		{
			var result = this.handler.Handle(moviesCommand);
			return this.StatusCode((int)result.StatusCode, result);
		}
    }
}
