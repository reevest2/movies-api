using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class MovieCreateRequest
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }

    }
}
