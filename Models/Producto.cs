using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lingzu.Models
{
    public class Producto
    {
        // Propiedad que representa el identificador único del producto.
        public int ProductoId { get; set; }

        // Propiedad que representa el nombre o descripción del producto con validaciones.
        [Display(Name = "Descripción")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [StringLength(100, MinimumLength = 1)] // Longitud mínima y máxima permitida.
        public string NombreProducto { get; set; } = string.Empty;

        // Propiedad que representa el precio del producto con validaciones.
        [Display(Name = "Precio")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [RegularExpression(@"^\d+$")] // Expresión regular para validar que solo contiene dígitos.
        public decimal PrecioProducto { get; set; }

        // Propiedad que representa la cantidad disponible del producto con validaciones.
        [Display(Name = "Cantidad")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [RegularExpression(@"^\d+$")] // Expresión regular para validar que solo contiene dígitos.
        public int CantidadProducto { get; set; }


    }
}