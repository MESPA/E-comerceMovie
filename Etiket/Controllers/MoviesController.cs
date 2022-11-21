using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etiket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Etiket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _appContext;

        public MoviesController(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _appContext.Movies.Include(n => n.Cinema).ToListAsync();
            return View(allMovies);
        }
    }
}