using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MovieAPI.Models;
using MovieAPI.Repositories;

namespace MovieAPI.Repositories
{
    public class MovieRepository
    {
        private readonly IMongoClient _mongoClient;

        public MovieRepository(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;

        }

        public async Task<IList<Movie>> GetAll()
        {
            List<Movie> movieCollection = await GetCollection().AsQueryable()
               .ToListAsync();
            return movieCollection;
        }

        public async Task<Movie> GetById(string id)
        {
            var movie = await GetCollection().AsQueryable()
                .FirstOrDefaultAsync(m => m.Id == id);
                return movie;
            
            //throw new NotImplementedException();
        }

        public Task<Movie> GetByMovieName(string movieName)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByMovieScore(string movieScore)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            movie.Id = Guid.NewGuid().ToString();
            await GetCollection().InsertOneAsync(movie);
            return movie;
        }

        public async Task Delete(string id)
        {
            await GetCollection().DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Movie> Update(string id, Movie data)
        {
            await GetCollection().UpdateOneAsync<Movie>(x => x.Id == id,
                Builders<Movie>.Update.Set(x => x.Name, data.Name).Set(x => x.Score, data.Score));

            return await GetCollection().AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        }

        private IMongoCollection<Movie> GetCollection()
        {
            IMongoDatabase database = _mongoClient.GetDatabase("MovieDB");
            IMongoCollection<Movie> collection = database.GetCollection<Movie>("MovieCollection");
            return collection;
        }


    }
}
