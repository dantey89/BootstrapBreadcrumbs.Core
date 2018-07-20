using BootstrapBreadcrumbs.Core;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Controllers
{
    [Breadcrumbs(Title = "About")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}