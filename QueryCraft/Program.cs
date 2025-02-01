using QueryCraft;
using QueryCraft.Data;
using QueryCraft.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTelerikBlazor();
builder.Services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("AppInMemoryDb"); }, ServiceLifetime.Singleton);
builder.Services.AddSingleton<IDatasetService, DatasetService>();
builder.Services.AddSingleton<IUtilities, Utilities>();
builder.Services.AddSingleton<ITransformationService, TransformationService>();

await builder.Build().RunAsync();