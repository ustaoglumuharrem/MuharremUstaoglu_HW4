using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MuharremUstaoglu_HW2.Data;
using MuharremUstaoglu_HW2.Models;
using MuharremUstaoglu_HW2.ViewModel;
using Microsoft.EntityFrameworkCore;



namespace MuharremUstaoglu_HW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger ,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Search()
        {
            ViewData["CategoryId"] =  new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {
            IQueryable<Book> books = _context.Books.AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if (searchModel.SearchInDescription)
                {
                    books = books.Where(b => b.Title.Contains(searchModel.SearchText) || b.Description.Contains(searchModel.SearchText));
                }
                else
                {
                    books = books.Where(b => b.Title.Contains(searchModel.SearchText));
                }
            }

            if (searchModel.CategoryId.HasValue)
            {
                books = books.Where(b => b.CategoryId == searchModel.CategoryId.Value);
            }
            if (searchModel.MinPrice.HasValue && searchModel.MaxPrice.HasValue)
            {
                books = books.Where(p => p.Price >= searchModel.MinPrice).Where(p => p.Price <= searchModel.MaxPrice);
            }
            else if (searchModel.MinPrice.HasValue)
            {
                books = books.Where(p => p.Price >= searchModel.MinPrice);
            }
            else if (searchModel.MaxPrice.HasValue)
            {
                books = books.Where(p => p.Price <= searchModel.MaxPrice);
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", searchModel.CategoryId);
            searchModel.Results = await books.ToListAsync();
            return View(searchModel);
        }

    }
}
