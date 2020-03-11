using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorAppSegundoParcial.Models;

namespace BlazorAppSegundoParcial.Data
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite(@"Data Source = Database/BaseDeDatosSegundoParcial"));
        }

        public DbSet<Llamadas> Llamadas { get; set; }
    }
}
