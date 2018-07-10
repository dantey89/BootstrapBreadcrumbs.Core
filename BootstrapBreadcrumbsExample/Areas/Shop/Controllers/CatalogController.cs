using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}