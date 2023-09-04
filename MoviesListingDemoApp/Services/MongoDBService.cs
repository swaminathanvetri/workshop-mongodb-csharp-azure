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
    /// Find all movies document in the collection
    /// </summary>
    /// <returns></returns>
    public async Task<List<Movie>> GetAsync()
    {
        return await _moviesCollection.Find(new BsonDocument()).ToListAsync();
    }
    

    /// <summary>
    /// Create a movie document in the collection
    /// </summary>
    /// <param name="movie"></param>
    public async Task CreateAsync(Movie movie)
    {
        await _moviesCollection.InsertOneAsync(movie);
        return;
    }

    /// <summary>
    /// Update an existing document in the collection
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    public async Task UpdateGenre(string id, string genre)
    {
        FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq("Id", id);
        UpdateDefinition<Movie> update = Builders<Movie>.Update.AddToSet<string>("genres", genre);
        await _moviesCollection.UpdateOneAsync(filter, update);
        return;
    }
    
    /// <summary>
    /// Delete an existing document in the collection
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteAsync(string id)
    {
        return;
    }

}