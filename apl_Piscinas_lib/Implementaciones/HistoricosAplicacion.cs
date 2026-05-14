using apl_Piscinas_lib_JQ.Entidades;
using apl_Piscinas_lib_JQ.Interfaces;
using apl_Piscinas_lib_JQ.Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Implementaciones
{
    public class HistoricosAplicacion : IHistoricosAplicacion
    {
        private IConexion? iConexion;

        public List<Historicos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            return this.iConexion.Historicos!.ToList();
        }

        public Historicos Guardar(Historicos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Historicos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }


    }
}
