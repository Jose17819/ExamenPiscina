using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pre_Piscinas_lib_JQ;

namespace pre_Piscinas_asp_JQ.Pages
{
    public class AgregarModel : PageModel
    {
        public List<Tipos>? Tipos { get; set; }

        [BindProperty] public Piscina? Entidad { get; set; }

        private string UrlBase = "http://localhost:5252";

        public void OnGet()
        {
            CargarTipos();
        }

        public IActionResult OnPostGuardar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Piscina/Guardar";
            datos["Entidad"] = Entidad!;

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<Piscina>(datos)!;
            task.Wait();

            // Registrar historico
            var historico = new Historicos
            {
                Descripcion = $"Se agregó la piscina {Entidad!.Nombre}",
                Fecha = DateTime.Now
            };

            var datosH = new Dictionary<string, object>();
            datosH["Url"] = $"{UrlBase}/Historicos/Guardar";
            datosH["Entidad"] = historico;

            var comunicaciones2 = new Comunicaciones();
            var task2 = comunicaciones2.Ejecutar<Historicos>(datosH)!;
            task2.Wait();

            return RedirectToPage("Index");
        }

        private void CargarTipos()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Tipos/Consultar";

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<List<Tipos>>(datos)!;
            task.Wait();
            this.Tipos = task.Result;
        }
    }
}
