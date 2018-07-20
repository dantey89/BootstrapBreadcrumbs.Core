using System.Collections.Generic;
using BootstrapBreadcrumbs.Core.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBreadcrumbs.Core
{
    public static class ControllerContextExtention
    {
        public static void SetBreadcrumbController(this Controller controller, BreadcrumbsItem item)
        {
            controller.ViewData.SetControllerBreadcrumb(item);
        }

        public static void SetBreadcrumbAction(this Controller controller, BreadcrumbsItem item)
        {
            controller.ViewData.SetActionBreadcrumb(item);
        }

        public static void SetBreadcrumbPrefixItems(this Controller controller, IEnumerable<BreadcrumbsItem> items)
        {
            controller.ViewData.SetPreffixItems(items);
        }

        public static void SetBreadcrumbSuffixItems(this Controller controller, IEnumerable<BreadcrumbsItem> items)
        {
            controller.ViewData.SetSuffixItems(items);
        }
    }
}
