using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MoviesListingDemoApp.Models;
using MoviesListingDemoApp.Settings;

namespace MoviesListingDemoApp.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Movie> _moviesCollection;

    
    /// <summary>
    /// Initialize MongoClient for the given connection string, database and collection name
    /// </summary>
    /// <param name="mongoDBSettings"></param>
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _moviesCollection = database.GetCollection<Movie>(mongoDBSettings.Value.CollectionName);
    }

    /// <summary>
    /// Get all movies document
    /// </summary>
    /// <returns></returns>
    public async Task<List<Movie>> GetAsync()
    {
        var movies = await _moviesCollection.Find(new BsonDocument()).ToListAsync();
        return movies;
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