using apl_Piscinas_lib_JQ.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace pre_Piscinas_asp_JQ.Pages
{
    public class ConsultarModel : PageModel
    {
        public Piscina? Piscina { get; set; }

        public async Task OnGet(int id)
        {
            using var http = new HttpClient();
            var json = await http.GetStringAsync(
                $"http://localhost:5252/Piscina/ConsultarId?id={id}");

            Piscina = JsonSerializer.Deserialize<Piscina>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}