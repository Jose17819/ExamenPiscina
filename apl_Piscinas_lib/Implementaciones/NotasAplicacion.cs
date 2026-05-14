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
    public class NotasAplicacion : IPiscinasAplicacion
    {
        private IConexion? iConexion;

        public List<Piscina> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = this.iConexion.Piscina!.ToList();

            foreach (var planeta in lista.ToList())
                planeta._Tipo = this.iConexion.Tipos!
                    .Where(x => x.Id == planeta.Tipo).FirstOrDefault();

            return lista;
        }

        public Piscina Guardar(Piscina entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Piscina!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }


        public Piscina Editar(Piscina entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El planeta no existe");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Piscina!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entidad = this.iConexion.Piscina!
                .Where(x => x.Id == id).FirstOrDefault();

            if (entidad == null)
                throw new Exception("La piscina no existe");

            this.iConexion.Piscina!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




        public bool ValidarCupo(int piscinaId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var piscina = this.iConexion.Piscina!
                .Where(x => x.Id == piscinaId).FirstOrDefault();

            if (piscina == null)
                throw new Exception("Piscina no existe");

            return piscina.NumerMax > 0;
        }


        public decimal CalcularDescuento(int edad, bool esFechaEspecial)
        {
            if (esFechaEspecial)
                return 7.5m;

            if (edad < 18)
                return 20m;
            else if (edad >= 65)
                return 15m;
            else
                return 5.2m;
        }


    }
}
