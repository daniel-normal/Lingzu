using Lingzu.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [BindProperty]
        public List<ProductoViewModel> Productos { get; set; } // Lista de productos

        // Definir la propiedad IdClienteRegistrado
        public int IdClienteRegistrado { get; set; }

        public IActionResult OnGet(int? ClienteId)
        {
            if (ClienteId == null)
            {
                return NotFound();
            }

            IdClienteRegistrado = ClienteId.Value;

            Productos = _context.Producto.Select(p => new ProductoViewModel
            {
                Value = p.ProductoId.ToString(),
                Text = p.NombreProducto,
                PrecioProducto = (int)p.PrecioProducto
            }).ToList();

            return Page();
        }


        [BindProperty]
        public int ProductoIdSeleccionado { get; set; } // Propiedad para almacenar el ID del producto seleccionado.

        [BindProperty]
        public Producto Producto { get; set; } = new Producto();

        public IActionResult OnPostAsync()
        {
            // Redirigir a la página "DetalleFactura" con valores en la URL
            return RedirectToPage("./DetalleFactura", new
            {
                idClienteRegistrado = IdClienteRegistrado,
                nombreProducto = Producto.NombreProducto,
                precioProducto = Producto.PrecioProducto,
                cantidadProducto = Producto.CantidadProducto
            });
        }
    }
}