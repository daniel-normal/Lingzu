﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lingzu.Models
{
    public class Venta
    {
        public int VentaId { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Número de Factura")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe contener solo números.")]
        public string NumeroVenta { get; set; } = string.Empty;

        // Agregar propiedad de relación
        public Cliente? Clientes { get; set; }
    }
}