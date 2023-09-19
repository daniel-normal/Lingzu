using Lingzu.Data;
using Lingzu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Lingzu.Pages.SignUp
{
    public class DetalleFacturaModel : PageModel
    {
        private readonly LingzuContext _context;

        public DetalleFacturaModel(LingzuContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int IdClienteRegistrado { get; set; }

        #region Obtener detalles de Venta por URL
        [BindProperty(SupportsGet = true)]
        public int idClienteRegistrado { get; set; }
        [BindProperty(SupportsGet = true)]
        public string nombreProducto { get; set; }
        [BindProperty(SupportsGet = true)]
        public int precioProducto { get; set; }
        [BindProperty(SupportsGet = true)]
        public int cantidadProducto { get; set; }
        #endregion

        public IActionResult OnGet(int? idClienteRegistrado)
        {
            if (idClienteRegistrado == null)
            {
                return NotFound();
            }

            IdClienteRegistrado = idClienteRegistrado.Value;

            return Page();
        }

        [BindProperty]
        public Venta Venta { get; set; } = new Venta();

        public async Task<IActionResult> OnPostAsync()
        {
            // Crear un objeto de tipo Venta con los datos que deseas insertar
            var random = new Random();
            var numeroVenta = random.Next(100000, 999999); // Genera un número aleatorio de 6 dígitos
            var nuevaVenta = new Venta
            {
                Fecha = DateTime.Now,
                NumeroVenta = numeroVenta.ToString(),
                ClienteId = IdClienteRegistrado
            };

            _context.Venta.Add(nuevaVenta);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}