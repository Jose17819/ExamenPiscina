using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pre_Piscinas_lib_JQ;

namespace pre_Piscinas_asp_JQ.Pages
{
    public class EditarModel : PageModel
    {
        public List<Tipos>? Tipos { get; set; }

        [BindProperty] public Piscina? Entidad { get; set; }

        private string UrlBase = "http://localhost:5252";

        public void OnGet(int id)
        {
            CargarTipos();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Piscina/Consultar";

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<List<Piscina>>(datos)!;
            task.Wait();

            Entidad = task.Result.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPostEditar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Piscina/Editar";
            datos["Entidad"] = Entidad!;
            datos["EsEditar"] = true;

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<Piscina>(datos)!;
            task.Wait();

            // Registrar historico
            var historico = new Historicos
            {
                Descripcion = $"Se editó la piscina {Entidad!.Nombre}",
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