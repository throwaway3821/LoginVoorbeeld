using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginVoorbeeld.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "StudentOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
