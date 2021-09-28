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
        //MongoDB has this set to unique
        public string Name { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }

        public string Review { get; set; }

        public bool MustWatch { get; set; }


        public Movie() { }
        public Movie(MovieCreateRequest request)
        {
            Id = request.Id;
            Name = request.Name;
            Score = request.Score;
            Review = request.Review;
            MustWatch = request.MustWatch;
        }
    }
}
