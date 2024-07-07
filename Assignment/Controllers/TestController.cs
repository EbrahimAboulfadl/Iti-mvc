using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class TestController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("test","testoo");
            return Content("test added successfully to session Data");
        } public IActionResult GetSession()
        {
            string t=HttpContext.Session.GetString("test");

            return Content($"{t}");
        }
    }
}
