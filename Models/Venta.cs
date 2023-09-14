using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lingzu.Models
{
    public class Venta
    {
        // Propiedad que representa el identificador único de la venta.
        public int VentaId { get; set; }

        // Propiedad que representa la fecha de la venta con validaciones.
        [Display(Name = "Fecha")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [DataType(DataType.Date)] // Tipo de datos para la fecha.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formato de visualización de la fecha.
        public DateTime Fecha { get; set; }

        // Propiedad que representa el número de factura de la venta con validaciones.
        [Display(Name = "Número de Factura")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [StringLength(35, MinimumLength = 1)] // Longitud mínima y máxima permitida.
        [RegularExpression(@"^\d+$")] // Expresión regular para validar que solo contiene dígitos.
        public string NumeroVenta { get; set; } = string.Empty;

        // Propiedad que representa la relación con un cliente. El signo de interrogación indica que puede ser nulo.
        public Cliente? Clientes { get; set; }
    }
}