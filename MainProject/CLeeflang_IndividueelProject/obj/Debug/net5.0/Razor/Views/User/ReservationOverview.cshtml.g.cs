#pragma checksum "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c41197ada3b717f2a3e2474397f9e782dc455f96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ReservationOverview), @"mvc.1.0.view", @"/Views/User/ReservationOverview.cshtml")]
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
#line 1 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\_ViewImports.cshtml"
using CLeeflang_IndividueelProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\_ViewImports.cshtml"
using CLeeflang_IndividueelProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c41197ada3b717f2a3e2474397f9e782dc455f96", @"/Views/User/ReservationOverview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb40989e4767632aca5c35689df71cd86f2f766", @"/Views/_ViewImports.cshtml")]
    public class Views_User_ReservationOverview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CLeeflang_IndividueelProject.Models.Reservation.ReservationOverviewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"tabContent\">\r\n        <table style=\"width:100%;\">\r\n            <tr>\r\n                <th>Date:</th>\r\n                <th>Business:</th>\r\n                <th>Start Time:</th>\r\n                <th>End Time:</th>\r\n            </tr>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
             foreach (var reservation in Model)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 16 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
                   Write(reservation.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
                   Write(reservation.BusinessName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
                   Write(reservation.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
                   Write(reservation.EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 21 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\User\ReservationOverview.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CLeeflang_IndividueelProject.Models.Reservation.ReservationOverviewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
