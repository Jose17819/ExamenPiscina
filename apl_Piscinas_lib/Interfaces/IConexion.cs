using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

        DbSet<Piscina>? Piscina { get; set; }
        DbSet<Historicos>? Historicos { get; set; }
        DbSet<Tipos>? Tipos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
