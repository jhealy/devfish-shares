#pragma checksum "C:\dev\POJSShell\Pages\FlexGridListOutput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "412397d80708a0ef2d8142ed7a7320ec25c4ceef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(POJSShell.Pages.Pages_FlexGridListOutput), @"mvc.1.0.razor-page", @"/Pages/FlexGridListOutput.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/FlexGridListOutput.cshtml", typeof(POJSShell.Pages.Pages_FlexGridListOutput), null)]
namespace POJSShell.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\dev\POJSShell\Pages\_ViewImports.cshtml"
using POJSShell;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"412397d80708a0ef2d8142ed7a7320ec25c4ceef", @"/Pages/FlexGridListOutput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4466fd8b71a108ba932ff08198a0ca9dbd4b309a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FlexGridListOutput : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\dev\POJSShell\Pages\FlexGridListOutput.cshtml"
  
    ViewData["Title"] = "FlexGridListOutput";
    Layout = "~/Pages/Shared/_LayoutListOutput.cshtml";

#line default
#line hidden
            BeginContext(166, 495, true);
            WriteLiteral(@"
<div style=""height: 50px; width:100%; margin:20px; border-style:inset; border-width:thick; border-color:black;"">button bar goes here</div>
<div class=""flex-container"" style=""height:60vh; margin:20px; border-style:inset; border-width:thick; border-color:black;"">
    <div class=""fixed-column"" style=""border-style:inset; border-width:thick; border-color:red;"">sideBar</div>
    <div class=""flex-column"" style=""border-style:inset; border-width:thick; border-color:green;"">content</div>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<POJSShell.Pages.FlexGridListOutputModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<POJSShell.Pages.FlexGridListOutputModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<POJSShell.Pages.FlexGridListOutputModel>)PageContext?.ViewData;
        public POJSShell.Pages.FlexGridListOutputModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591