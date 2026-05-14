using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;


namespace pre_Piscinas_asp_JQ.Pages
{
    public class ReservarModel : PageModel
    {

        [BindProperty]
        public int PiscinaId { get; set; }

        [BindProperty]
        public int Edad { get; set; }

        [BindProperty]
        public bool EsFechaEspecial { get; set; }

        public string? Mensaje { get; set; }

        public async Task OnPost()
        {
            using var http = new HttpClient();

            // validar cupo
            var cupo =
                await http.GetStringAsync(
                $"http://localhost:5252/Piscina/ValidarCupo?id={PiscinaId}");

            bool hayCupo = bool.Parse(cupo);

            if (!hayCupo)
            {
                Mensaje = "La piscina no tiene cupos disponibles";
                return;
            }

            // calcular descuento
            var descuento =
                await http.GetStringAsync(
                $"http://localhost:5252/Piscina/CalcularDescuento?edad={Edad}&esFechaEspecial={EsFechaEspecial}");

            // guardar en histórico
            var historico = new
            {
                Descripcion = $"Se realizó una reserva para la piscina {PiscinaId} con descuento de {descuento}%",
                Fecha = DateTime.Now
            };

            var contenido =
                new StringContent(
                    JsonSerializer.Serialize(historico),
                    Encoding.UTF8,
                    "application/json");

            await http.PostAsync(
                "http://localhost:5252/Historicos/Guardar",
                contenido);


            Mensaje =
                $"Reserva válida. Descuento aplicado: {descuento}%";
        }
    }
}