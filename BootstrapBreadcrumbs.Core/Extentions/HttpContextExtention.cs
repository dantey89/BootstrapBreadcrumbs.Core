using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BootstrapBreadcrumbs.Core.Extentions
{
    public static class HttpContextExtention
    {
        public static IBreadcrumbsManager Breadcrumbs(this HttpContext context)
        {
            return context.RequestServices.GetService<IBreadcrumbsManager>();
        }
    }
}
