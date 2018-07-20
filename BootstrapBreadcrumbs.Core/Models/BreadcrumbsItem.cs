namespace BootstrapBreadcrumbs.Core
{
    public class BreadcrumbsItem
    {
        public string Title { get; set; }

        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public object RouteValues { get; set; }

    }
}
