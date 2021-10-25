using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ajinomoto_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ajinomoto_app.Models.Producto> DataProductos { get; set; }

        public DbSet<ajinomoto_app.Models.Proforma> DataProforma {get; set; }

        public DbSet<ajinomoto_app.Models.Pago> DataPago {get; set; }
    }
}
