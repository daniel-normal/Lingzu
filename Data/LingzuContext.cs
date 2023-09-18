﻿using System;  // Importa el espacio de nombres System para tipos fundamentales.
using System.Collections.Generic;  // Importa el espacio de nombres para colecciones genéricas.
using System.Linq;  // Importa el espacio de nombres para consultas LINQ.
using System.Threading.Tasks;  // Importa el espacio de nombres para trabajar con tareas asincrónicas.
using Microsoft.EntityFrameworkCore;  // Importa el espacio de nombres de Entity Framework Core.
using Lingzu.Models;  // Importa el espacio de nombres que contiene los modelos.

namespace Lingzu.Data
{
    // Define la clase LingzuContext que hereda de DbContext para interactuar con la base de datos.
    public class LingzuContext : DbContext
    {
        // Constructor que recibe opciones de configuración para el contexto.
        public LingzuContext(DbContextOptions<LingzuContext> options)
            : base(options)
        {
        }

        // DbSet para la entidad Cliente que será mapeada a una tabla en la base de datoss.
        public DbSet<Lingzu.Models.Cliente> Cliente { get; set; } = default!;

        // DbSet para la entidad Producto que será mapeada a una tabla en la base de datos.
        // El signo '?' indica que este DbSet puede ser nulo.
        public DbSet<Lingzu.Models.Producto>? Producto { get; set; }

        // DbSet para la entidad Venta que será mapeada a una tabla en la base de datos.
        // El signo '?' indica que este DbSet puede ser nulo.
        public DbSet<Lingzu.Models.Venta>? Venta { get; set; }
    }
}
