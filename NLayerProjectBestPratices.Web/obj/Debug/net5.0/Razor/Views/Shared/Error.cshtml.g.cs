#pragma checksum "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "274a94544ceaec98d9cc7061bace8e43417c7bb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\_ViewImports.cshtml"
using NLayerProjectBestPratices.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\_ViewImports.cshtml"
using NLayerProjectBestPratices.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\_ViewImports.cshtml"
using NLayerProjectBestPratices.Web.DTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"274a94544ceaec98d9cc7061bace8e43417c7bb4", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b7cd0aba70b1a138ffe04f9061c615d0bf023a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Bir hata meydana geldi.</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\Shared\Error.cshtml"
 foreach (var item in Model.Errors)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 10 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\Shared\Error.cshtml"
  Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 11 "C:\Users\mehme\Desktop\Dosyalar\WebDeveloper\NLayerProjectBestPratices-Api-Web Haberleşmesi\NLayerProjectBestPratices.Web\Views\Shared\Error.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorDto> Html { get; private set; }
    }
}
#pragma warning restore 1591