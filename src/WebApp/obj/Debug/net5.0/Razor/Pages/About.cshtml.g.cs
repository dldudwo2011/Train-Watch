#pragma checksum "D:\back up - 20220428\Nait courses\done spring term - 2021\CPSC1517\Assignment\git repos\take-home-exercises-may-2021-skske1432\src\WebApp\Pages\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17f98bb0cf78b7bb2a86d7b84d015e7168db3ca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Pages_About), @"mvc.1.0.razor-page", @"/Pages/About.cshtml")]
namespace WebApp.Pages
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
#line 1 "D:\back up - 20220428\Nait courses\done spring term - 2021\CPSC1517\Assignment\git repos\take-home-exercises-may-2021-skske1432\src\WebApp\Pages\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17f98bb0cf78b7bb2a86d7b84d015e7168db3ca7", @"/Pages/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09d1db1c25558096e535f8fd24d0fe24129c968a", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_About : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<p>");
#nullable restore
#line 6 "D:\back up - 20220428\Nait courses\done spring term - 2021\CPSC1517\Assignment\git repos\take-home-exercises-may-2021-skske1432\src\WebApp\Pages\About.cshtml"
Write(Model.dbVersion.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Link to GitHub: <a href=\"https://github.com/CPSC-1517/take-home-exercises-may-2021-skske1432\">https://github.com/CPSC-1517/take-home-exercises-may-2021-skske1432 </a></p>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyApp.Namespace.AboutModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.AboutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.AboutModel>)PageContext?.ViewData;
        public MyApp.Namespace.AboutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
