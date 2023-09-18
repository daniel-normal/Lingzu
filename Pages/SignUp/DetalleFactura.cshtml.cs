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

        // Definir la propiedad IdClienteRegistrado
        public int IdClienteRegistrado { get; set; }

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
        public Venta Venta { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Agrega un registro de depuración
            Console.WriteLine("OnPostAsync() ejecutado");

            if (!ModelState.IsValid || _context.Venta == null || Venta == null)
            {
                return Page();
            }

            _context.Venta.Add(Venta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public IActionResult OnPost()
        {
            // Agrega un registro de depuración
            Console.WriteLine("OnPost() ejecutado");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var venta = new Venta
            {
                Fecha = Venta.Fecha,
                NumeroVenta = Venta.NumeroVenta,
                ClienteId = IdClienteRegistrado
            };

            _context.Venta.Add(venta);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

    }
}
