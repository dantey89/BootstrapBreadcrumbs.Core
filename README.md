# Bootstrap 3 Breadcrumbs for Asp.Net Core 2

This liblary allows you easeily use Bootstrap 3 breadcrumbs at you project. It supports translations and areas as well. You can manage your breadcrumbs from actions and put addiotional items to breadcumbs chain as well.

Here is a structure of breadcrumbs:

[![Breadcrumbs structure](http://flat-cable.com.ua/images/Breadcrumbs_scheme.png "Breadcrumbs structure")](http://flat-cable.com.ua/images/Breadcrumbs_scheme.png "Breadcrumbs structure")

Each item in chain is the *BreadcrumbsItem* model which has these attributes:

*Title* - text ro display
*Area* - area for this link
*Controller* - controller for this link
*Action* - action for this link
*RouteValues* - additional parameters to be passed to link

###How to use:

1. To install the liblary use NuGet console 

 `$ Install-Package BootstrapBreadcrumbs.Core -Version 1.0.0`

2. Import taghelper to your **_ViewImports.cshtml ** file <pre>@addTagHelper *, BootstrapBreadcrumbs.Core</pre>
3.  Add taghelper to your layout 
```csharp
<breadcrumbs-nav home-action="Index" home-controller="Home" home-title="Root"></breadcrumbs-nav> 
```
All options can be setted using *home-*  attribute.

4. Add *[Breadcrumbs]* attribute to your controller to specify link for you controller breadcrumb item. You can set localization file with *TitleSource* property. In this case *Title* will be key for localization. You can manualy set controller breadcrumb using extention method for your controller like this

 `this.SetBreadcrumbController(breadcrumbItem)`

5. Add *[Breadcrumbs]* attribute to your action to specify action breadcrumb.  You can set localization file with *TitleSource* property. In this case *Title* will be key for localization. You can manualy set it using extention method

 `this.SetBreadcrumbAction(breadcrumbItem)`

6. If you additionaly need prefix and sufix items use extention methods:

 `this.SetBreadcrumbPrefixItems(arrayOfBreadcrumbItems)`
 `this.SetBreadcrumbSuffixItems(arrayOfBreadcrumbItems)`

7. Enjoy ;-)

You can download complexe sample [here](https://github.com/dantey89/BootstrapBreadcrumbs.Core/tree/master/BootstrapBreadcrumbsExample "here")
