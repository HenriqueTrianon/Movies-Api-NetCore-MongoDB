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
        // GET: Movies
        public async Task<ActionResult> Index()
        {
            return Json(await MovieService.GetAll());
        }
        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieDto movie)
        {
            await MovieService.Insert(movie);
            return Ok();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MovieDto movieDto)
        {
            await MovieService.Update(movieDto);
            return Ok();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id) =>
                Ok(await MovieService.DeleteById(id));
    }
}