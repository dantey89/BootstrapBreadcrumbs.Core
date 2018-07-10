using System.Collections.Generic;
using BootstrapBreadcrumbs.Core.Models;

namespace BootstrapBreadcrumbs.Core
{
    public interface IBreadcrumbsManager
    {
        void SetControllerItem(BreadcrumbsItem breadcrumbsItem);
        void SetActionItem(BreadcrumbsItem breadcrumbsItem);
        void SetSuffixItems(IEnumerable<BreadcrumbsItem> breadcrumbsItems);
        void SetPrefixItems(IEnumerable<BreadcrumbsItem> breadcrumbsItems);
    }
}