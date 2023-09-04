using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesListingDemoApp.Models;
using MoviesListingDemoApp.Settings;

namespace MoviesListingDemoApp.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Movie> _moviesCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _moviesCollection = database.GetCollection<Movie>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Movie>> GetAsync()
    {
        return null;
    }
    
    public async Task CreateAsync(Movie movie)
    {
        return;
    }

    public async Task AddToPlaylistAsync(string id, string movieId)
    {
        return;
    }
    
    public async Task DeleteAsync(string id)
    {
        return;
    }

}