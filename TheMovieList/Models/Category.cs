using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMovieList.Models
{
    public class Category
    {
        //ID - PRIMARY KEY
        public int CategoryId { get; set; }

        //Name 
        [Required(ErrorMessage = "You must fill out the name of the category")]
        public string Name { get; set; }

        //virtual for lazy loading
        public virtual ICollection<Movie> Movies { get; set; }

    }
}