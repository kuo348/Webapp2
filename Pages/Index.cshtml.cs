using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public ActionResult HandleButtonOn(string ButtonOn)
    {
        try
        {
            return Redirect("Privacy");
        }
        catch (Exception e)
        {
            Console.WriteLine("failed to connect...");
            //goto connection;
        }

       return Redirect("Login");
    }
}
