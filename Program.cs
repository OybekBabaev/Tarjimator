using Tarjimator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<TarjimationEngine>();

var app = builder.Build();

app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
// app.MapFallback(async ctx => await ctx.Response
//         .WriteAsync("Oops! Seems like you\'ve just requested a non-existent page."));
app.MapFallbackToPage("/oops");

app.Run();