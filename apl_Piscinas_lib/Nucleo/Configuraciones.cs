using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost;database=db_Piscinas;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
