using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Añade esta referencia

namespace Lingzu.Models
{
    public class Venta
    {
        // Propiedad que representa el identificador único de la venta.
        public int VentaId { get; set; }

        // Propiedad que representa la fecha de la venta con validaciones.
        [Display(Name = "Fecha")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Campo obligatorio.
        [DataType(DataType.Date)] // Tipo de datos para la fecha.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formato de visualización de la fecha.
        public DateTime Fecha { get; set; }

        // Propiedad que representa el número de factura de la venta con validaciones.
        [Display(Name = "Número de Factura")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Campo obligatorio.
        [StringLength(35, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")] // Longitud mínima y máxima permitida.
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")] // Expresión regular para validar que solo contiene dígitos.
        public string NumeroVenta { get; set; } = string.Empty;

        // Agregar propiedad de relación con Cliente
        public int ClienteId { get; set; } // Debe coincidir con el nombre de la columna en la tabla

        [ForeignKey("ClienteId")] // Indica la relación con la columna ClienteId
        public Cliente Cliente { get; set; }
    }
}