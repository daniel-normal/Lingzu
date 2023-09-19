using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lingzu.Data;
using Lingzu.Models;

namespace Lingzu.Pages.Ventas
{
    public class DetailsModel : PageModel
    {
        private readonly LingzuContext _context;

        public DetailsModel(LingzuContext context)
        {
            _context = context;
        }

        public Venta Venta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venta = await _context.Venta
                .Include(v => v.Cliente) // Cargar la relación del cliente
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (Venta == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}