using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovies.Models;

namespace RazorPagesMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMoviesContext _context;

        public IndexModel(RazorPagesMoviesContext context)
        {
            _context = context;
        }

        public IList<Models.Movies> Movies { get; set; }
        public SelectList Genres;
        public string MovieGenre { get; set; }

        // The new 'Search' approach
        public async Task OnGetAsync(string searchString)
        {
            IQueryable<string> genresQuery = from m in _context.Movies
                                             orderby m.Genre
                                             select m.Genre;

            var movies = from m in _context.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
                movies = movies.Where(m => m.Title.Contains(searchString));

            if (!String.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(m => m.Genre == MovieGenre);

            Genres = new SelectList(await genresQuery.Distinct().ToListAsync());
            Movies = await movies.ToListAsync();
        }

        // The inital approach                
        //public async Task OnGetAsync()
        //{
        //    Movies = await _context.Movies.ToListAsync();
        //}
    }
}
