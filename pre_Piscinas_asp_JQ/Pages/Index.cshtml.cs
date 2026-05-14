using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pre_Piscinas_lib_JQ;

namespace pre_Piscinas_asp_JQ.Pages
{
    public class IndexModel : PageModel
    {
        public List<Piscina>? Piscina { get; set; }
        public List<Tipos>? Tipos { get; set; }

        [BindProperty] public Piscina? Entidad { get; set; }
        [BindProperty(SupportsGet = true)] public string? Buscar { get; set; }

        private string UrlBase = "http://localhost:5252";

        public void OnGet()
        {
            CargarDatos();

            if (!string.IsNullOrEmpty(Buscar))
                Piscina = Piscina!
                    .Where(p => p.Nombre!.ToLower()
                    .Contains(Buscar.ToLower()))
                    .ToList();
        }

        public void OnPostEliminar(int id)
        {
            CargarDatos();

            var piscinaEliminar = Piscina?.FirstOrDefault(p => p.Id == id);

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Piscina/Eliminar?id={id}";
            datos["EsEliminar"] = true;

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<object>(datos)!;
            task.Wait();

            var historico = new Historicos
            {
                Descripcion = $"Se eliminó la Piscina {piscinaEliminar?.Nombre ?? id.ToString()}",
                Fecha = DateTime.Now
            };

            var datosH = new Dictionary<string, object>();
            datosH["Url"] = $"{UrlBase}/Historicos/Guardar";
            datosH["Entidad"] = historico;

            var comunicaciones2 = new Comunicaciones();
            var task2 = comunicaciones2.Ejecutar<Historicos>(datosH)!;
            task2.Wait();

            CargarDatos();
        }

        private void CargarDatos()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{UrlBase}/Piscina/Consultar";

            var comunicaciones = new Comunicaciones();
            var task = comunicaciones.Ejecutar<List<Piscina>>(datos)!;
            task.Wait();
            this.Piscina = task.Result;

            var datosTipos = new Dictionary<string, object>();
            datosTipos["Url"] = $"{UrlBase}/Tipos/Consultar";

            var comunicaciones2 = new Comunicaciones();
            var task2 = comunicaciones2.Ejecutar<List<Tipos>>(datosTipos)!;
            task2.Wait();
            this.Tipos = task2.Result;
        }
    }
}