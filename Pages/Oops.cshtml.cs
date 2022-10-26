using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tarjimator.Pages;

#nullable disable

public class OopsModel : PageModel
{
    public string TheMessage { get; set; }
    public void OnGet() => TheMessage = "Oops! Seems like you've entered a wrong URL.";
}