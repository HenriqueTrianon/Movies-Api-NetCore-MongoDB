using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Services;

namespace Movies.Api.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService MovieService { get; }
        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        [HttpGet]
        /// <summary>
        /// Gets all the movies as json.
        /// </summary>     
        public async Task<ActionResult> Index()
        {
            return Json(await MovieService.GetAll());
        }

        /// <summary>
        /// Creates a Movie.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /Todo
        ///     {
        ///"name": "The Big Black Garden",
        ///"price": 92.377658347775050,
        ///"category": [
        ///"Movies",
        ///"Games",
        ///"Music"
        ///],
        ///"author": "Sylvester is Alone"
        ///     }
        /// </remarks>
        /// <param name="movie"></param>
        /// <returns>A newly created Movie</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>       
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody]MovieDto movie)
        {
            await MovieService.Insert(movie);
            return Ok();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromBody]MovieDto movieDto)
        {
            await MovieService.Update(movieDto);
            return Ok();
        }
        /// <summary>
        /// Delete a movie by the id.
        /// </summary>
        /// <param name="id">Identifier of the movie.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id) =>
                Ok(await MovieService.DeleteById(id));
    }
}