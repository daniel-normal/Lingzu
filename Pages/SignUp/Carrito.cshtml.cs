using Lingzu.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Lingzu.Pages.SignUp
{
    public class CarritoModel : PageModel
    {
        private readonly Lingzu.Data.LingzuContext _context;

        public CarritoModel(Lingzu.Data.LingzuContext context)
        {
            _context = context;
        }

        public class ProductoViewModel
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public int PrecioProducto { get; set; }
        }

        public List<ProductoViewModel> Productos { get; set; } // Lista de productos

        // Definir la propiedad IdClienteRegistrado
        public int IdClienteRegistrado { get; set; }

        public IActionResult OnGet(int? idClienteRegistrado)
        {
            if (idClienteRegistrado == null)
            {
                return NotFound();
            }
            IdClienteRegistrado = idClienteRegistrado.Value;

            Productos = _context.Producto.Select(p => new ProductoViewModel
            {
                Value = p.ProductoId.ToString(),
                Text = p.NombreProducto,
                PrecioProducto = (int)p.PrecioProducto // Convertir el precio a entero
            }).ToList();

            return Page();
        }

        [BindProperty]
        public int ProductoIdSeleccionado { get; set; } // Propiedad para almacenar el ID del producto seleccionado.

        [BindProperty]
        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Producto == null || Producto == null)
            {
                return Page();
            }

            _context.Producto.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./DetalleFactura", new { idClienteRegistrado = IdClienteRegistrado });
        }
    }
}