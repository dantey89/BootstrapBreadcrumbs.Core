using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BootstrapBreadcrumbs.Core.Extentions
{
    public static class DependencyInjectionExtention
    {
        public static void AddBreadcrumbs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBreadcrumbsManager>();
        }
    }
}
