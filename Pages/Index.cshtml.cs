using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarjimator.Services;

namespace Tarjimator.Pages;

public class IndexModel : PageModel
{
    private TarjimationEngine tarjimationEngine;

    [BindProperty] public string OriginalText { get; set; } = "";
    public string TarjimatedText { get; set; } = "Nothing here yet...";

    public IndexModel(TarjimationEngine engine) => tarjimationEngine = engine;

    public IActionResult OnGet() => Page();

    public IActionResult OnPost()
    {
        TarjimatedText = tarjimationEngine.Transliterate(OriginalText);
        return OnGet();
    }
}