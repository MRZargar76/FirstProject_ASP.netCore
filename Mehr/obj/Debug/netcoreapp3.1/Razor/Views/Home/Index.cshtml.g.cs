#pragma checksum "D:\__________M.R.Zargar\Mehr - Razieh\Mehr\Mehr\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c891c629708f1a45c7e9bef6745213b83c60f28a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\__________M.R.Zargar\Mehr - Razieh\Mehr\Mehr\Views\_ViewImports.cshtml"
using Mehr;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\__________M.R.Zargar\Mehr - Razieh\Mehr\Mehr\Views\_ViewImports.cshtml"
using Mehr.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c891c629708f1a45c7e9bef6745213b83c60f28a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1337110ded55148aacbf7f8085ffd2d44a678d41", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\__________M.R.Zargar\Mehr - Razieh\Mehr\Mehr\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "_ChartLayout";
    ViewBag.ChartData = "[125, 200, 125, 225, 125, 200, 125, 225, 175, 275, 220]";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""basic-buttons"">
    <div class=""row"">
        <div class=""col-lg-12 col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h4 class=""card-title"">Basic Buttons </h4>
                </div>
                <div class=""card-content collapse show"">
                    <div class=""card-body"">
                        <p class=""card-subtitle"">Bootstrap includes six predefined button styles, each serving its own semantic purpose.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
