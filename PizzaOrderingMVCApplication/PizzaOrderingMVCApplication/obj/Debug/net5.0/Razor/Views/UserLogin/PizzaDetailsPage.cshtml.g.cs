#pragma checksum "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "caa61ab373d90e4530a44162f586107b2581076f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserLogin_PizzaDetailsPage), @"mvc.1.0.view", @"/Views/UserLogin/PizzaDetailsPage.cshtml")]
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
#line 1 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\_ViewImports.cshtml"
using PizzaOrderingMVCApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\_ViewImports.cshtml"
using PizzaOrderingMVCApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caa61ab373d90e4530a44162f586107b2581076f", @"/Views/UserLogin/PizzaDetailsPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cec22e6b0aa61b9b79aad361178411bf729ba2fa", @"/Views/_ViewImports.cshtml")]
    public class Views_UserLogin_PizzaDetailsPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PizzaOrderingMVCApplication.Models.CustomerPizzaDetails>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
  
    ViewData["Title"] = "PizzaDetailsPage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>PizzaDetailsPage</h1>\r\n");
#nullable restore
#line 7 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
 using (Html.BeginForm("PizzaDetailsPage", "UserLogin", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table id=\"tblCustomer\">\r\n        <thead>\r\n            <tr>\r\n\r\n                <th>PizzaName   </th>\r\n                <th>Toppings    </th>\r\n                <th>Qty</th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
             for (int i = 0; i < Model.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
                   Write(Model[i].pizzaDetail.PizzaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        onion ");
#nullable restore
#line 27 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
                         Write(Html.CheckBoxFor(m => Model[i].onion));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        crispCapsicum ");
#nullable restore
#line 28 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
                                 Write(Html.CheckBoxFor(m => Model[i].crispCapsicum));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        GrilledMushroom ");
#nullable restore
#line 29 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
                                   Write(Html.CheckBoxFor(m => Model[i].GrilledMushroom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
                   Write(Html.TextBoxFor(d => Model[i].qty));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <input class=\"btn btn-primary\" type=\"submit\" value=\"Oder Now\" />\r\n");
#nullable restore
#line 38 "C:\Users\Administrator\Desktop\PizzaOrdingMVCApplication\PizzaOrderingMVCApplication\PizzaOrderingMVCApplication\Views\UserLogin\PizzaDetailsPage.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PizzaOrderingMVCApplication.Models.CustomerPizzaDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
