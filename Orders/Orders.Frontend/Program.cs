using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Orders.Frontend;
using Orders.Frontend.Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CurrieTechnologies.Razor.SweetAlert2;

namespace Orders.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            // Configura HttpClient apuntando al backend (ajusta el puerto si es necesario)
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7201/") });

            // Inyecta el repositorio para consumir la API
            builder.Services.AddScoped<IRepository, Repository>();

            // Agrega SweetAlert2 para alertas
            builder.Services.AddSweetAlert2();

            await builder.Build().RunAsync();
        }
    }
}
