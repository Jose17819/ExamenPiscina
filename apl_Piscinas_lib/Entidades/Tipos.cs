using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Entidades
{
    public class Tipos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad_Min { get; set; }
        public decimal Temperatura { get; set; }
        public int Profundidad { get; set; }


    }

}
