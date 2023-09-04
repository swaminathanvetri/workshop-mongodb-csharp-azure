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

    [HttpGet]
    public async Task<List<Movie>> Get()
    {
        return Enumerable.Empty<Movie>().ToList();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        return Ok();
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