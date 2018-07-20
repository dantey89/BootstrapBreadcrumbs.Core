using System.Runtime.CompilerServices;
using BootstrapBreadcrumbs.Core.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BootstrapBreadcrumbs.Core
{
    public class BreadcrumbsAttribute : ActionFilterAttribute
    {
        private readonly string _propName;

        /// <summary>
        /// Text to display at breadcrumbs
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Controller for generating a link
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action for generating a link
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Area for generating a link
        /// </summary>
        public string Area { get; set; }
         

        public BreadcrumbsAttribute([CallerMemberName] string propertyName = null)
        {
            this._propName = propertyName;
        }



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;

            //is action attribute?
            if (_propName == null)
            {
                controller.ViewData.SetControllerBreadcrumb(new BreadcrumbsItem
                {
                    Area = this.Area,
                    Controller = this.Controller,
                    Action = this.Action,
                    Title = this.Title
                });
            }
            else
            {
                controller.ViewData.SetActionBreadcrumb(new BreadcrumbsItem
                {
                    Area = this.Area,
                    Controller = this.Controller,
                    Action = this.Action,
                    Title = (this.Title == "ViewBag") ? controller.ViewBag.BreadcrumbsTitle : this.Title
                });

            }

            base.OnActionExecuting(context);
        }


    }
}
