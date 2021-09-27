using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Controllers;
using MovieAPI.Models;
using MovieAPI.Repositories;


namespace MovieAPI.Services
{
    public class MovieService
    {
        private readonly MovieRepository _repository;
        
        public MovieService(MovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Movie> GetById(string id)
        {
            var movie = await _repository.GetById(id);

            if (movie == null)
                throw new NotImplementedException(id);

            return movie;

        }

        public async Task<IList<Movie>> GetAll()
        {
            return await _repository.GetAll();

        }

        public async Task<Movie> Create(MovieCreateRequest request)
        {
            var movie = new Movie(request);
            movie = await _repository.CreateAsync(movie);
            return movie;
            
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id.ToString());
        }

        public async Task<Movie> Update(Guid id, MovieUpdateRequest request)
        {
            var movie = await _repository.GetById(id.ToString());
            return await _repository.Update(id.ToString(), movie);
        }


    }
}
