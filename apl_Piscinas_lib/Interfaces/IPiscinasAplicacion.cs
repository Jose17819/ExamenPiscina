using apl_Piscinas_lib_JQ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Interfaces
{
    public interface IPiscinasAplicacion
    {


        List<Piscina> Consultar();
        Piscina ConsultarId(int id);
        Piscina Guardar(Piscina entidad);
        Piscina Editar(Piscina entidad);
        void Eliminar(int id);


        bool ValidarCupo(int piscinaId);
        decimal CalcularDescuento(int edad, bool esFechaEspecial);
    }
}
