using Lingzu.Data;
using Lingzu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lingzu.Pages.SignUp
{
    public class CarritoModel : PageModel
    {
        private readonly LingzuContext _context;

        public CarritoModel(LingzuContext context)
        {
            _context = context;
        }

        public class ProductoViewModel
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public int PrecioProducto { get; set; }
        }

        #region Enviar propiedades por URL
        [BindProperty]
        public List<ProductoViewModel> Productos { get; set; } // Lista de productos
        [BindProperty(SupportsGet = true)]
        public int IdClienteRegistrado { get; set; }
        [BindProperty]
        public int ProductoIdSeleccionado { get; set; } // Propiedad para almacenar el ID del producto seleccionado.
        #endregion

        [BindProperty]
        public Producto Producto { get; set; } = new Producto();

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

        public IActionResult OnPostAsync()
        {
            // Redirigir a la página "DetalleFactura" con valores en la URL
            return RedirectToPage("./DetalleFactura", new
            {
                idClienteRegistrado = IdClienteRegistrado, // Utiliza idClienteRegistrado en minúscula
                nombreProducto = Producto.NombreProducto,
                precioProducto = Producto.PrecioProducto,
                cantidadProducto = Producto.CantidadProducto
            });
        }
    }
}