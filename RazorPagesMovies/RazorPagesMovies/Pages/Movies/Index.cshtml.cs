using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        // The new 'Search' approach
        public async Task OnGetAsync(string searchString)
        {
            var movies = from m in _context.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            Movies = await movies.ToListAsync();
        }

        // The inital approach                
        //public async Task OnGetAsync()
        //{
        //    Movies = await _context.Movies.ToListAsync();
        //}
    }
}
