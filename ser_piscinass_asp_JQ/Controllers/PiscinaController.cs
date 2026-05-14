
using apl_Piscinas_lib_JQ.Entidades;
using apl_Piscinas_lib_JQ.Implementaciones;
using apl_Piscinas_lib_JQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ser_piscinass_asp_JQ.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class PiscinaController : ControllerBase
    {

        private NotasAplicacion iPiscinasAplicacion;

        public PiscinaController()
        {
            this.iPiscinasAplicacion = new NotasAplicacion();
        }



        [HttpGet]
        public List<Piscina> Consultar()
        {
            if (this.iPiscinasAplicacion == null)
                throw new Exception("No implementado");
            return this.iPiscinasAplicacion!.Consultar();
        }


        [HttpPost]
        public Piscina Guardar(Piscina entidad)
        {
            if (this.iPiscinasAplicacion == null)
                throw new Exception("No implementado");
            return this.iPiscinasAplicacion!.Guardar(entidad);
        }



        [HttpPut]
        public Piscina Editar(Piscina entidad)
        {
            if (this.iPiscinasAplicacion == null)
                throw new Exception("No implementado");
            return this.iPiscinasAplicacion!.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iPiscinasAplicacion == null)
                throw new Exception("No implementado");
            this.iPiscinasAplicacion!.Eliminar(id);
        }


        [HttpGet]
        public bool ValidarCupo(int id)
        {
            return this.iPiscinasAplicacion!.ValidarCupo(id);
        }

        [HttpGet]
        public decimal CalcularDescuento(int edad, bool esFechaEspecial)
        {
            return this.iPiscinasAplicacion!.CalcularDescuento(edad, esFechaEspecial);
        }


        [HttpGet]
        [Route("ConsultarId")]
        public Piscina ConsultarId(int id)
        {
            return iPiscinasAplicacion.ConsultarId(id);
        }

    }

}
