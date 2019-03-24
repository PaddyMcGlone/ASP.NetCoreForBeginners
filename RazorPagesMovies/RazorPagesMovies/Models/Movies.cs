using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovies.Models
{
    public class Movies
    {
        #region Properties

        public int ID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public Decimal Price { get; set; }

        #endregion
    }
}
