using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BootstrapBreadcrumbs.Core.Manager
{
    internal static class BreadcrumbsManager
    {
        private const string BreadcrumbsControllerItem = "BreadcrumbsControllerItem";
        private const string BreadcrumbsActionItem = "BreadcrumbsActionItem";
        private const string BreadcrumbsSuffixItems = "BreadcrumbsSuffixItems";
        private const string BreadcrumbsPrefixItems = "BreadcrumbsPrefixItems";


        internal static void SetControllerBreadcrumb(this ViewDataDictionary viewData, BreadcrumbsItem breadcrumbItem)
        {
            viewData[BreadcrumbsControllerItem] = breadcrumbItem;
        }

        internal static void SetActionBreadcrumb(this ViewDataDictionary viewData, BreadcrumbsItem breadcrumbItem)
        {
            viewData[BreadcrumbsActionItem] = breadcrumbItem;
        }

        internal static void SetPreffixItems(this ViewDataDictionary viewData,
            IEnumerable<BreadcrumbsItem> breadcrumbsItems)
        {
            viewData[BreadcrumbsPrefixItems] = breadcrumbsItems;
        }

        internal static void SetSuffixItems(this ViewDataDictionary viewData,
            IEnumerable<BreadcrumbsItem> breadcrumbsItems)
        {
            viewData[BreadcrumbsSuffixItems] = breadcrumbsItems;
        }


        internal static BreadcrumbsItem GetControllerBreadcrumb(this ViewDataDictionary viewDataDictionary)
        {
            return viewDataDictionary[BreadcrumbsControllerItem] as BreadcrumbsItem;
        }

        internal static BreadcrumbsItem GetActionBreadcrumb(this ViewDataDictionary viewDataDictionary)
        {
            return viewDataDictionary[BreadcrumbsActionItem] as BreadcrumbsItem;
        }

        internal static IEnumerable<BreadcrumbsItem> GetPrefixBreadcrumbs(this ViewDataDictionary viewDataDictionary)
        {
            return viewDataDictionary[BreadcrumbsPrefixItems] as IEnumerable<BreadcrumbsItem>;
        }

        internal static IEnumerable<BreadcrumbsItem> GetSuffixBreadcrumbs(this ViewDataDictionary viewDataDictionary)
        {
            return viewDataDictionary[BreadcrumbsSuffixItems] as IEnumerable<BreadcrumbsItem>;
        }
    }
}
