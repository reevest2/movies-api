using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Models;

namespace MovieAPI.Models
{
    public class Movie : BaseResource
    {
        public string Name { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }


        public Movie() { }
        public Movie(MovieCreateRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Score = request.Score;
        }
    }
}
