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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovies.Models.RazorPagesMoviesContext _context;

        public DetailsModel(RazorPagesMovies.Models.RazorPagesMoviesContext context)
        {
            _context = context;
        }

        public RazorPagesMovies.Models.Movies Movies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movies = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);

            if (Movies == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
