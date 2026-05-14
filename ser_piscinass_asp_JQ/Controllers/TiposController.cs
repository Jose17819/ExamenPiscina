using apl_Piscinas_lib_JQ.Entidades;
using apl_Piscinas_lib_JQ.Implementaciones;
using apl_Piscinas_lib_JQ.Interfaces;
using apl_Piscinas_lib_JQ.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace ser_piscinass_asp_JQ.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiposController : ControllerBase
    {
        private IConexion? iConexion;

        public TiposController()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
        }

        [HttpGet]
        public List<Tipos> Consultar()
        {
            return this.iConexion!.Tipos!.ToList();
        }
    }
}
