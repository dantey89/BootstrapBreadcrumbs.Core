using BootstrapBreadcrumbs.Core;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Controllers
{
    [Breadcrumbs(Title = "Account menu", Action = "Index")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumbs(Title = "Edit Account")]
        public IActionResult Edit()
        {
            return View();
        }

        [Breadcrumbs(Title = "Account Details")]
        public IActionResult Details()
        {
            return View();
        }

        [Breadcrumbs(Title = "Additional Info")]
        public IActionResult AdditionalInfo()
        {
            this.SetBreadcrumbPrefixItems(new BreadcrumbsItem[]{ new BreadcrumbsItem
            {
                Title = "Account Info",
                Controller = "Account",
                Action = "Details"
            }});

            return View();
        }
    }
}