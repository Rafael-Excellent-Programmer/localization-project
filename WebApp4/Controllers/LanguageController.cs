using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp4.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult SetCulture(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(2) });
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
