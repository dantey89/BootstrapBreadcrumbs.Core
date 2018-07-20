using BootstrapBreadcrumbs.Core;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Controllers
{
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            this.SetBreadcrumbController(new BreadcrumbsItem()
            {
                Title = "Account menu",
                Controller = "Account",
                Action = "Index"
            });

            this.SetBreadcrumbPrefixItems(new BreadcrumbsItem[]
            {
                new BreadcrumbsItem()
                {
                    Title = "Account Details",
                    Controller = "Account",
                    Action = "Details"
                },
                new BreadcrumbsItem()
                {
                    Title = "Account Balance",
                }
            });

            return View();
        }
    }
}