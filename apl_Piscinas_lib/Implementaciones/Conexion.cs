using apl_Piscinas_lib_JQ.Entidades;
using apl_Piscinas_lib_JQ.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Piscina>? Piscina { get; set; }
        public DbSet<Historicos>? Historicos { get; set; }
        public DbSet<Tipos>? Tipos { get; set; }


    }
}
