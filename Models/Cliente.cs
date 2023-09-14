using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lingzu.Models
{
    public class Cliente
    {
        // Propiedad que representa el identificador único del cliente.
        public int ClienteId { get; set; }

        // Propiedad que representa el apellido paterno del cliente con validaciones.
        [Display(Name = "Apellido Paterno")] // Etiqueta para mostrar en la interfaz de usuario.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] // Expresión regular para validar el formato.
        [StringLength(35, MinimumLength = 1)] // Longitud mínima y máxima permitida.
        [Required] // Campo obligatorio.
        public string ApellidoP { get; set; } = string.Empty;

        // Propiedad que representa el apellido materno del cliente con validaciones.
        [Display(Name = "Apellido Materno")] // Etiqueta para mostrar en la interfaz de usuario.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] // Expresión regular para validar el formato.
        [StringLength(35, MinimumLength = 1)] // Longitud mínima y máxima permitida.
        public string ApellidoM { get; set; } = string.Empty;

        // Propiedad que representa el nombre del cliente con validaciones.
        [Display(Name = "Nombre")] // Etiqueta para mostrar en la interfaz de usuario.
        [Required] // Campo obligatorio.
        [StringLength(35, MinimumLength = 1)] // Longitud mínima y máxima permitida.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] // Expresión regular para validar el formato.
        public string Nombre { get; set; } = string.Empty;

        // Propiedad que representa el NIT (Número de Identificación Tributaria) del cliente con validaciones.
        [Display(Name = "NIT")] // Etiqueta para mostrar en la interfaz de usuario.
        [StringLength(35, MinimumLength = 4)] // Longitud mínima y máxima permitida.
        [RegularExpression(@"^\d+$")] // Expresión regular para validar que solo contiene dígitos.
        public string Nit { get; set; } = string.Empty;

        // Propiedad que representa una colección de ventas relacionadas con este cliente.
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
