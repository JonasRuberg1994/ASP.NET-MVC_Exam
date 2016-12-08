using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMovieList.Models
{
    public class Movie
    {
        //ID - PRIMARY KEY 
        public int MovieId { get; set; }

        //Title
        [Required(ErrorMessage = "You must fill out the title name")]
        public string Title { get; set; }

        //Year
        [Required(ErrorMessage = "You must fill out the year")]
        public int Year { get; set; }

        //Director
        [Required(ErrorMessage = "You must fill out the director name")]
        public string Director { get; set; }

        //CategoryID
        public int? CategoryId { get; set; }

        //Foreign key to category table
        public virtual Category Category { get; set; }
    }
}