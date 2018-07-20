using BootstrapBreadcrumbs.Core;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbsExample.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Breadcrumbs(Title = "Root category", Controller = "Catalog", Action = "Index", Area = "Shop")]
    public class CatalogController : Controller
    {
        public IActionResult Index(string category)
        {
            if (!string.IsNullOrEmpty(category))
                this.SetBreadcrumbAction(new BreadcrumbsItem()
                {
                    Title = category
                });

            return View(model: category);
        }


        public IActionResult Details(string category, string product)
        {
            this.SetBreadcrumbPrefixItems(new BreadcrumbsItem[]{ new BreadcrumbsItem()
            {
                Title = category,
                Action = "Index",
                Controller = "Catalog"
            }});

            this.SetBreadcrumbAction(new BreadcrumbsItem
            {
                Title = product
            });
            return View();
        }
    }
}