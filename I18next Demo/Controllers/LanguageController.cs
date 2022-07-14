using System;
using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace I18next_Demo.Controllers
{
    public class LanguageController : BaseController
    {
        public IActionResult ChangeCultureInfo(string cultureName, string redirectUrl)
        {
            if (string.IsNullOrEmpty(cultureName))
            {
                return Redirect(redirectUrl);
            }

            var cookieOptions = new CookieOptions();
            cookieOptions.Path = "/";
            cookieOptions.HttpOnly = false;
            cookieOptions.IsEssential = true;
            cookieOptions.Expires = DateTime.Now.AddMonths(1);

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName)), cookieOptions);
            if (!string.IsNullOrEmpty(redirectUrl))
                return Redirect(redirectUrl);
            return Redirect("/");
        }

        public string GetCurrentLanguage()
        {
            var currentLang = CultureInfo.CurrentCulture.Name;
            return JsonSerializer.Serialize(currentLang);
        }



    }
}
