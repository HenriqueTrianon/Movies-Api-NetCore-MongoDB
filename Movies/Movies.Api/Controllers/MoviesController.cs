using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Services;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class MoviesController : Controller
    {
        private IMovieService MovieService { get; }

        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        /// <summary>
        /// Gets the top 10 movies.
        /// </summary>     
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Json(await MovieService.GetAll());
        }
        /// <summary>   
        /// Creates a Movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>A newly created Movie</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>       
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] MovieDto movie)
        {
            await MovieService.Insert(movie);
            return Ok();
        }

        /// <summary>
        /// Change a movie
        /// </summary>
        /// <param name="movieDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MovieDto movieDto)
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
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            return Ok(await MovieService.DeleteById(id));
        }
    }
}