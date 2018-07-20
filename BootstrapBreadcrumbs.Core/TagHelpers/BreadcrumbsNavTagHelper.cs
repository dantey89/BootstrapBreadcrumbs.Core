using System.Collections.Generic;
using System.Linq;
using BootstrapBreadcrumbs.Core.Manager;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapBreadcrumbs.Core.TagHelpers
{

#warning Add route object support

    public class BreadcrumbsNavTagHelper : TagHelper
    {

        private readonly IHtmlGenerator _generator;


        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }


        public string HomeArea { get; set; }

        public string HomeController { get; set; }

        public string HomeAction { get; set; }

        public string HomeTitle { get; set; }

        private BreadcrumbsItem ControllerItem => ViewContext.ViewData.GetControllerBreadcrumb();

        private BreadcrumbsItem ActionItem => ViewContext.ViewData.GetActionBreadcrumb();

        private IEnumerable<BreadcrumbsItem> SuffixItems => ViewContext.ViewData.GetSuffixBreadcrumbs();

        private IEnumerable<BreadcrumbsItem> PrefixItems => ViewContext.ViewData.GetPrefixBreadcrumbs();



        public BreadcrumbsNavTagHelper(IHtmlGenerator generator)
        {
            this._generator = generator;
        }





        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ol";
            output.Attributes.Add("class", "breadcrumb");

            var homeLink = GenerateHomeLink();
            var controlleLink = GenerateControllerLink();
            var suffixLinks = GenerateSufixItemsLinks();
            var prefixLinks = GeneratePrefixItemsLinks();
            var actionLink = GenerateActionLink();

            output.Content.AppendHtml(homeLink);

            if (controlleLink != null)
                output.Content.AppendHtml(controlleLink);

            if (prefixLinks != null)
                prefixLinks.ForEach(x => output.Content.AppendHtml(x));

            if (actionLink != null)
                output.Content.AppendHtml(actionLink);

            if (suffixLinks != null)
                suffixLinks.ForEach(x => output.Content.AppendHtml(x));

        }



        private IHtmlContent GenerateHomeLink()
        {
            TagBuilder homeLi = new TagBuilder("li");
            homeLi.Attributes.Add("class", "breadcrumb-item");

            TagBuilder homeHref = null;
            string homeTitle = HomeTitle ?? "Home";


            if (string.IsNullOrEmpty(HomeAction))
            {
                homeHref = new TagBuilder("a");
                homeHref.Attributes.Add("href", "/");
                homeHref.InnerHtml.Append(homeTitle);
            }
            else
            {
                homeHref = _generator.GenerateActionLink(ViewContext, homeTitle, HomeAction, HomeController, null, null, null, new { Area = HomeArea }, null);
            }

            homeLi.InnerHtml.AppendHtml(homeHref);


            return homeLi;
        }


        private IHtmlContent GenerateControllerLink()
        {
            if (ControllerItem == null)
                return null;

            TagBuilder controllerLiTag = new TagBuilder("li");
            controllerLiTag.Attributes.Add("class", "breadcrumb-item");

            //Controller item the only one. Make it active and quit
            if (PrefixItems == null && ActionItem == null && SuffixItems == null)
            {
                controllerLiTag.Attributes["class"] = $"{controllerLiTag.Attributes["class"]} active";
                controllerLiTag.InnerHtml.AppendHtml(ControllerItem.Title);
                return controllerLiTag;
            }
            else
            {
                var controllerHref = _generator.GenerateActionLink(ViewContext, ControllerItem.Title, ControllerItem.Action, ControllerItem.Controller, null, null, null, new { Area = ControllerItem.Area }, null);
                controllerLiTag.InnerHtml.AppendHtml(controllerHref);
            }

            return controllerLiTag;
        }


        private List<IHtmlContent> GeneratePrefixItemsLinks()
        {
            if (PrefixItems == null)
                return null;

            List<IHtmlContent> resultLiTags = new List<IHtmlContent>();
            bool lastInChain = (ActionItem == null && SuffixItems == null);
            List<BreadcrumbsItem> items = PrefixItems.ToList();

            for (var i = 0; i < items.Count; i++)
            {
                TagBuilder prefixLiTag = new TagBuilder("li");
                prefixLiTag.Attributes.Add("class", "breadcrumb-item");

                if (i + 1 == items.Count && lastInChain)
                {
                    prefixLiTag.Attributes["class"] = $"{prefixLiTag.Attributes["class"]} active";
                    prefixLiTag.InnerHtml.AppendHtml(items[i].Title);
                }
                else
                {
                    TagBuilder prefixItemHref = _generator.GenerateActionLink(ViewContext, items[i].Title, items[i].Action, items[i].Controller, null, null, null, new { Area = items[i].Area }, null);
                    prefixLiTag.InnerHtml.AppendHtml(prefixItemHref);
                }

                resultLiTags.Add(prefixLiTag);
            }

            return resultLiTags;
        }


        private IHtmlContent GenerateActionLink()
        {
            if (ActionItem == null)
                return null;

            TagBuilder actionLiTag = new TagBuilder("li");
            actionLiTag.Attributes.Add("class", "breadcrumb-item");

            if (SuffixItems == null)
            {
                actionLiTag.Attributes["class"] = $"{actionLiTag.Attributes["class"]} active"; 
                actionLiTag.InnerHtml.AppendHtml(ActionItem.Title);
            }
            else
            {
                TagBuilder actionLink = _generator.GenerateActionLink(ViewContext, ActionItem.Title, ActionItem.Action, ActionItem.Controller, null, null, null, new { Area = ActionItem.Area }, null);
                actionLiTag.InnerHtml.AppendHtml(actionLink);
            }

            return actionLiTag;
        }


        private List<IHtmlContent> GenerateSufixItemsLinks()
        {
            if (SuffixItems == null)
                return null;

            List<IHtmlContent> resultLiTags = new List<IHtmlContent>();
            List<BreadcrumbsItem> items = SuffixItems.ToList();

            for (var i = 0; i < items.Count; i++)
            {
                TagBuilder liTag = new TagBuilder("li");
                liTag.Attributes.Add("class", "breadcrumb-item");

                if (i + 1 == items.Count)
                {
                    liTag.Attributes["class"] = $"{liTag.Attributes["class"]} active";
                    liTag.InnerHtml.AppendHtml(items[i].Title);
                }
                else
                {
                    TagBuilder suffixItemHref = _generator.GenerateActionLink(ViewContext, items[i].Title, items[i].Action, items[i].Controller, null, null, null, new { Area = items[i].Area }, null);
                    liTag.InnerHtml.AppendHtml(suffixItemHref);
                }

                resultLiTags.Add(liTag);
            }

            return resultLiTags;
        }


        //private void ValidateBreadcrumbsItem(BreadcrumbsItem breadcrumbsItem)
        //{

        //}
    }
}
