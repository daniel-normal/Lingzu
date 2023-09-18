﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lingzu.Models
{
    public class Producto
    {
        [BindProperty]
        public int ProductoId { get; set; }
        
        [BindProperty]
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        public string NombreProducto { get; set; } = string.Empty;

        [BindProperty]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")]
        public int PrecioProducto { get; set; }

        [BindProperty]
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")]
        public int CantidadProducto { get; set; }
    }
}
