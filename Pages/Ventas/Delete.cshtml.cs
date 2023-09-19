using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lingzu.Data;
using Lingzu.Models;

namespace Lingzu.Pages.Ventas
{
    public class DeleteModel : PageModel
    {
        private readonly LingzuContext _context;

        public DeleteModel(LingzuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venta Venta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venta = await _context.Venta
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (Venta == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venta = await _context.Venta.FindAsync(id);

            if (Venta != null)
            {
                _context.Venta.Remove(Venta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
