using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lingzu.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "Apellido Paterno")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "El campo {0} debe contener solo letras y comenzar con mayúscula.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ApellidoP { get; set; } = string.Empty;

        [Display(Name = "Apellido Materno")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "El campo {0} debe contener solo letras y comenzar con mayúscula.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ApellidoM { get; set; } = string.Empty;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "El campo {0} debe contener solo letras y comenzar con mayúscula.")]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "NIT")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nit { get; set; } = string.Empty;

        // Agregar una colección de ventas relacionadas
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
