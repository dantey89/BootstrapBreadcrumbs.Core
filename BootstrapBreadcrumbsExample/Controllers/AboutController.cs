using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBreadcrumbs.Core.Attributes;
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