using Tarjimator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<TarjimationEngine>();

var app = builder.Build();

app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapFallbackToPage("/oops");

app.Run();