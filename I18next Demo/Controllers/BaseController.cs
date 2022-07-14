using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace I18next_Demo.Controllers
{
    public class BaseController : Controller
    {
        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            var value = HttpContext.Session.GetString(key);
            return value;
        }

        public void RemoveSession(string key)
        {
            HttpContext.Session.Remove(key);
        }
    }
}
