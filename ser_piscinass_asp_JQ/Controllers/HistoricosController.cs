
using apl_Piscinas_lib_JQ.Entidades;
using apl_Piscinas_lib_JQ.Implementaciones;
using apl_Piscinas_lib_JQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ser_piscinass_asp_JQ.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HistoricosController : ControllerBase
    {
        private IHistoricosAplicacion? iHistoricosAplicacion;

        public HistoricosController()
        {
            this.iHistoricosAplicacion = new HistoricosAplicacion();
        }

        [HttpGet]
        public List<Historicos> Consultar()
        {
            if (this.iHistoricosAplicacion == null)
                throw new Exception("No implementado");
            return this.iHistoricosAplicacion!.Consultar();
        }

        [HttpPost]
        public Historicos Guardar(Historicos entidad)
        {
            if (this.iHistoricosAplicacion == null)
                throw new Exception("No implementado");
            return this.iHistoricosAplicacion!.Guardar(entidad);
        }
    }
}
