using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarjimator.Services;
using System.Text.RegularExpressions;

namespace Tarjimator.Pages;

public class HintModel : PageModel
{
    private TarjimationEngine tarjimationEngine;

    public HintModel(TarjimationEngine engine) => tarjimationEngine = engine;

    public Dictionary<string, string> Lookups { get; set; } = new();

    public void OnGet() => Lookups = new Dictionary<string, string>(
        tarjimationEngine.GetLookup()
        .Where(kv => Regex.IsMatch(kv.Key, @"^([a-z]+|[:*])"))
        .OrderBy(kv => kv.Value));
}