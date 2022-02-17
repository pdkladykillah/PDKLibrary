#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDKLibrary.Data;
using PDKLibrary.Models;

namespace PDKLibrary.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly PDKLibrary.Data.PDKLibraryContext _context;

        public IndexModel(PDKLibrary.Data.PDKLibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Authors { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BookAuthor { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> authorQuery = from m in _context.Book
                                            orderby m.Author
                                            select m.Author;
            var books = from m in _context.Book
                         select m;
            //Search by Title
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }
            //Search by Author
            if (!string.IsNullOrEmpty(BookAuthor))
            {
                books = books.Where(x => x.Author == BookAuthor);
            }
            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
