#pragma checksum "c:\Users\karn_\Documents\Last semester\Web application\test\Views\Results\multiple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf7deee3c8ed8c04f72c015cb30e6f9a918cb05b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Results_multiple), @"mvc.1.0.view", @"/Views/Results/multiple.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Results/multiple.cshtml", typeof(AspNetCore.Views_Results_multiple))]
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
#line 1 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\_ViewImports.cshtml"
using test;

#line default
#line hidden
#line 2 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\_ViewImports.cshtml"
using test.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7deee3c8ed8c04f72c015cb30e6f9a918cb05b", @"/Views/Results/multiple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04aae2d41d7a1f2a1b7badf4f453e10febdd2915", @"/Views/_ViewImports.cshtml")]
    public class Views_Results_multiple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<test.Models.CheckView>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 371, true);
            WriteLiteral(@"


    <h1>cars has checked-in multiple time per day </h1> 
    
    <table class=""table"">
        <thead>
            <tr>
                <th>
                   checkoutLicensePlate
                </th>
                <th>
                    count
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 20 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\Results\multiple.cshtml"
     foreach (var item in Model) {

#line default
#line hidden
            BeginContext(450, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(511, 47, false);
#line 23 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\Results\multiple.cshtml"
               Write(Html.DisplayFor(modelItem => item.licensePlate));

#line default
#line hidden
            EndContext();
            BeginContext(558, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(626, 40, false);
#line 26 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\Results\multiple.cshtml"
               Write(Html.DisplayFor(modelItem => item.count));

#line default
#line hidden
            EndContext();
            BeginContext(666, 62, true);
            WriteLiteral("\r\n                </td>\r\n                \r\n            </tr>\r\n");
            EndContext();
#line 30 "c:\Users\karn_\Documents\Last semester\Web application\test\Views\Results\multiple.cshtml"
    }

#line default
#line hidden
            BeginContext(735, 42, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n    \r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<test.Models.CheckView>> Html { get; private set; }
    }
}
#pragma warning restore 1591