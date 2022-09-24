using Tarjimator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<TarjimationEngine>();

var app = builder.Build();

app.MapRazorPages();

app.Run();