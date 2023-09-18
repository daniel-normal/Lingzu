using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lingzu.Data;
using Lingzu.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingzu.Pages.SignUp
{
    public class SignUpModel : PageModel
    {
        private readonly LingzuContext _context;

        public SignUpModel(LingzuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;
        public bool RegistrationSuccessful { get; set; } = false;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Cliente == null)
            {
                return Page();
            }

            _context.Cliente.Add(Cliente);
            await _context.SaveChangesAsync();

            RegistrationSuccessful = true;

            // Obtener el ClienteId después de guardar el cliente
            var clienteGuardado = await _context.Cliente.SingleOrDefaultAsync(c => c.Nit == Cliente.Nit);

            if (clienteGuardado != null)
            {
                // Redirigir a la página "Carrito" con el ClienteId como parámetro de consulta
                return RedirectToPage("./Carrito", new { ClienteId = clienteGuardado.ClienteId });
            }
            else
            {
                return Page();
            }
        }

    }
}