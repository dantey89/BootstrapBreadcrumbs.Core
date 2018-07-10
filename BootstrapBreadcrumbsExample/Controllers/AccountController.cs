using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBreadcrumbs.Core.Attributes;
using BootstrapBreadcrumbs.Core.Extentions;
using BootstrapBreadcrumbs.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Controllers
{
    [Breadcrumbs(Title = "Account menu", ActionMethod = "Index")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Breadcrumbs().SetActionItem(new BreadcrumbsItem()
            {
                Title = "Index"
            });

            return View();
        }

        [Breadcrumbs(Title = "Edit Account")]
        public IActionResult Edit()
        {
            return View();
        }

        [Breadcrumbs(Title = "Account Info")]
        public IActionResult Details()
        {
            return View();
        }

        [Breadcrumbs(Title = "Additional Info")]
        public IActionResult AdditionalInfo()
        {
            return View();
        }
    }
}