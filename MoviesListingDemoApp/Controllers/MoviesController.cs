using Microsoft.AspNetCore.Mvc;
using MoviesListingDemoApp.Models;
using MoviesListingDemoApp.Services;

namespace MoviesListingDemoApp.Controllers;

[Controller]
[Route("movies")]
public class MoviesController : Controller
{
    private readonly MongoDBService _mongoDBService;
    
    public MoviesController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    /// <summary>
    /// Get all movies document
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<Movie>> Get()
    {
        var movies = await _mongoDBService.GetAsync();
        return movies;
    }

    /// <summary>
    /// Create a Movie document
    /// </summary>
    /// <param name="movie"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        if (movie != null)
        {
            await _mongoDBService.CreateAsync(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }
        return BadRequest("No movie given");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok();
    }

}