using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pre_Piscinas_lib_JQ;

namespace pre_Piscinas_asp_JQ.Pages
{
    public class HistoricosModel : PageModel
    {
        public List<Historicos>? Historicos { get; set; }

        [BindProperty] public Historicos? Entidad { get; set; }

        private string UrlBase = "http://localhost:5252";

        public void OnGet()
        {
            CargarDatos();
        }

        public IActionResult OnPostGuardar()
        {
            Entidad!.Fecha = DateTime.Now;

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Historicos/Guardar";
            datos["Entidad"] = Entidad!;

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<Historicos>(datos)!;
            task.Wait();

            return RedirectToPage("Historicos");
        }

        private void CargarDatos()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Historicos/Consultar";

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<List<Historicos>>(datos)!;
            task.Wait();
            this.Historicos = task.Result;
        }


    }
}
