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
    public class SignUpModel : PageModel
    {
        private readonly LingzuContext _context;

        public int IdClienteRegistrado { get; set; }

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

            RegistrationSuccessful = true; // Establecer como exitoso

            // Después de guardar el cliente, obtén su ID desde la base de datos
            IdClienteRegistrado = Cliente.ClienteId; // Suponiendo que 'ClienteId' es la propiedad que almacena el ID del cliente

            return RedirectToPage("./Carrito", new { idClienteRegistrado = IdClienteRegistrado });
        }
    }
}