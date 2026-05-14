using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_Piscinas_lib_JQ.Entidades
{
    public class Piscina
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Tamaño { get; set; }
        public int NumerMax { get; set; }
        public int Tipo { get; set; }

        [ForeignKey("Tipo")] public Tipos? _Tipo { get; set; }
    }

}
