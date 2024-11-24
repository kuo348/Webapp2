using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
namespace webapp2.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    [TempData]
    public string ErrorMessage { get; set; }
    public string ReturnUrl { get; set; }
    [BindProperty, Required]
    public string Username { get; set; }
    [BindProperty, DataType(DataType.Password)]
    public string Password { get; set; }

    public void OnGet(string returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }

        returnUrl = returnUrl ?? Url.Content("~/");

        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            var verificationResult = true; // TODO: Verify username and password

            if (verificationResult)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return Redirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}
