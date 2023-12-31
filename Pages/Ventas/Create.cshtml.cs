﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lingzu.Data;
using Lingzu.Models;

namespace Lingzu.Pages.Ventas
{
    public class CreateModel : PageModel
    {
        private readonly Lingzu.Data.LingzuContext _context;

        public CreateModel(Lingzu.Data.LingzuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ApellidoM");
            return Page();
        }

        [BindProperty]
        public Venta Venta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Venta.Add(Venta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
