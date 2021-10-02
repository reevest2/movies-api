﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class MovieCreateRequest
    {
        
        [Required]
        //MongoDB has this set to unique
        public string Name { get; set; }

        [Required]
        [Range(0, 10)]
        public int Score { get; set; }

        public string Review { get; set; }

        public bool MustWatch { get; set; }
    }
}
