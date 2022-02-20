#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScriptureJournal.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public IndexModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Scripture> Scripture { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NoteKeyword { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Scripture> scriptures = from s in _context.Scripture
                                               select s;

            //Filter
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NoteKeyword))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(NoteKeyword));
            }

            //Sort
            switch (sortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderBy(s => s.AddDate);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.AddDate);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }



            Scripture = await scriptures.AsNoTracking().ToListAsync();
        }
    }
}
