using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lingzu.Data;
using Lingzu.Models;

namespace Lingzu.Pages.SignUp
{
    public class DetalleFacturaModel : PageModel
    {
        private readonly Lingzu.Data.LingzuContext _context;

        public DetalleFacturaModel(Lingzu.Data.LingzuContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int idClienteRegistrado { get; set; }

        [BindProperty(SupportsGet = true)]
        public string nombreProducto { get; set; }

        [BindProperty(SupportsGet = true)]
        public int precioProducto { get; set; }

        [BindProperty(SupportsGet = true)]
        public int cantidadProducto { get; set; }


        public IActionResult OnGet()
        {
            // Resto de tu código
            return Page();
        }

        [BindProperty]
        public Venta Venta { get; set; } = new Venta();

        public async Task<IActionResult> OnPostAsync()
        {
            // Aquí puedes guardar la venta en tu base de datos, utilizando la propiedad Venta

            _context.Venta.Add(Venta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
