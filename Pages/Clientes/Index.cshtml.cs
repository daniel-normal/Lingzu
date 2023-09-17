using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            IQueryable<Cliente> clientIQ = from s in _context.Cliente
                                           select s;

            // Ajusta el valor de pageSize para mostrar solo 5 registros por página
            var pageSize = 3;
            ClienteP = await PaginatedList<Cliente>.CreateAsync(
                clientIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            if (_context.Cliente != null)
            {
                Cliente = await _context.Cliente.ToListAsync();
            }
        }
    }
}