using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Lingzu.Data;
using Lingzu.Models;

namespace Lingzu.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly LingzuContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(LingzuContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Cliente> ClienteP { get; set; }

        public IList<Cliente> Cliente { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var clients = from m in _context.Cliente
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s =>
                    s.ApellidoP.Contains(searchString) ||
                    s.ApellidoM.Contains(searchString) ||
                    s.Nombre.Contains(searchString) ||
                    s.Nit.Contains(searchString));
            }

            var pageSize = 5;
            ClienteP = await PaginatedList<Cliente>.CreateAsync(
                clients.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


    }
}