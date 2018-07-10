using System;
using System.Collections.Generic;
using System.Text;
using BootstrapBreadcrumbs.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace BootstrapBreadcrumbs.Core
{
    public class BreadcrumbsManager : IBreadcrumbsManager
    {
        private readonly IControllerFactory _controllerFactory;
        private readonly ControllerContext _controllerContext;
        private readonly Controller _controller;

        //public BreadcrumbsManager(IControllerFactory controllerFactory)
        //{
        //    _controllerFactory = controllerFactory.CreateController(ControllerContext );
        //}

        //public BreadcrumbsManager(Controller controller)
        //{
        //    _controller = controller;
        //}

        public void SetControllerItem(BreadcrumbsItem breadcrumbsItem)
        {
            _controller.ViewBag.BreadcrumbsControllerItem = breadcrumbsItem;
        }

        public void SetActionItem(BreadcrumbsItem breadcrumbsItem)
        {
            _controller.ViewBag.BreadcrumbsActionItem = breadcrumbsItem;
        }

        public void SetSuffixItems(IEnumerable<BreadcrumbsItem> breadcrumbsItems)
        {
            _controller.ViewBag.BreadcrumbsSuffixItems = breadcrumbsItems;
        }

        public void SetPrefixItems(IEnumerable<BreadcrumbsItem> breadcrumbsItems)
        {
            _controller.ViewBag.BreadcrumbsPrefix = breadcrumbsItems;
        }
    }
}
