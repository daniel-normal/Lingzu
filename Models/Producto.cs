using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lingzu.Models
{
    public class Producto
    {
        // Propiedad que representa el identificador único del producto.
        [BindProperty]
        public int ProductoId { get; set; }
        
        [BindProperty]
        // Propiedad que representa el nombre o descripción del producto con validaciones.
        [Display(Name = "Descripción")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")] // Longitud mínima y máxima permitida.
        public string NombreProducto { get; set; } = string.Empty;

        [BindProperty]
        // Propiedad que representa el precio del producto con validaciones.
        [Display(Name = "Precio")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Campo obligatorio.
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")] // Expresión regular para validar que solo contiene dígitos.
        public int PrecioProducto { get; set; }

        [BindProperty]
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")]
        public int CantidadProducto { get; set; }
    }
}
