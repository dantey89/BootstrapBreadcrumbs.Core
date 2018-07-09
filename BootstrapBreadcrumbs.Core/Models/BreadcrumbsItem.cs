using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapBreadcrumbs.Core.Models
{
    public class BreadcrumbsItem
    {
        public string Title { get; set; }

        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
        
    }
}
