using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BootstrapBreadcrumbs.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BootstrapBreadcrumbs.Core.Attributes
{
    public class BreadcrumbsAttribute : ActionFilterAttribute
    {
        private readonly string propName;

        /// <summary>
        /// Text to display at breadcrumbs
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Controller for generating a link
        /// </summary>
        public string ActionController { get; set; }

        /// <summary>
        /// Action for generating a link
        /// </summary>
        public string ActionMethod { get; set; }

        /// <summary>
        /// Area for generating a link
        /// </summary>
        public string ActionArea { get; set; }


        public BreadcrumbsAttribute([CallerMemberName] string propertyName = null)
        {
            this.propName = propertyName;
        }



        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;

            if (propName == null)
            {
                controller.ViewBag.BreadcrumbsController = new BreadcrumbsItem
                {
                    Area = this.ActionArea,
                    Controller = this.ActionController,
                    Action = this.ActionMethod,
                    Title = this.Title
                };
            }
            else
            {
                controller.ViewBag.BreadcrumbsAction = new BreadcrumbsItem
                {
                    Area = this.ActionArea,
                    Controller = this.ActionController,
                    Action = this.ActionMethod,
                    Title = (this.Title == "ViewBag") ? controller.ViewBag.BreadcrumbsTitle : this.Title
                };

            }

            base.OnActionExecuted(context);
        }


    }
}
