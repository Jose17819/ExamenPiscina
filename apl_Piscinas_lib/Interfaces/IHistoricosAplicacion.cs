using apl_Piscinas_lib_JQ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Interfaces
{
    public interface IHistoricosAplicacion
    {
        List<Historicos> Consultar();
        Historicos Guardar(Historicos entidad);
    }
}
