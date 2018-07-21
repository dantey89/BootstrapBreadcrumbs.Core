using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using BootstrapBreadcrumbs.Core.Manager;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BootstrapBreadcrumbs.Core
{
    public class BreadcrumbsAttribute : ActionFilterAttribute
    {
        private readonly string _propName;

        /// <summary>
        /// Localization source file. Use Title to set key.
        /// </summary>
        public Type TitleSource { get; set; }

        /// <summary>
        /// Text to display at breadcrumbs. If TitleSource defined, it will search for this key.
        /// </summary>
        public string Title
        {
            get => (TitleSource == null) ? _title : new ResourceManager(TitleSource).GetString(_title);
            set { _title = value; }
        }
        private string _title;

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
