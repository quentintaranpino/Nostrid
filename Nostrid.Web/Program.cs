using Ganss.Xss;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Nostrid.Data;
using Nostrid.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<FeedService>();
builder.Services.AddSingleton(new EventDatabase(new MemoryStream()));
builder.Services.AddSingleton<RelayService>();
builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<HtmlSanitizer>();
builder.Services.AddSingleton<NoteProcessor>();

await builder.Build().RunAsync();