using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMovieList.Models
{
    public class FavoriteIndex
    {
        public Favorite Favorite { get; set; }
        public string ReturnUrl { get; set; }
    }
}