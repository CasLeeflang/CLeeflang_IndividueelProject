#pragma checksum "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "565b6f94ceaedf12db5d6b8aae60cbf27b91a216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BusinessPage), @"mvc.1.0.view", @"/Views/Home/BusinessPage.cshtml")]
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
#nullable restore
#line 6 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
using Logic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"565b6f94ceaedf12db5d6b8aae60cbf27b91a216", @"/Views/Home/BusinessPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb40989e4767632aca5c35689df71cd86f2f766", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BusinessPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Logic.BusinessUser.BusinessUserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TimeSlotContainer.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/TimeSlot.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
  
    ViewData["Title"] = "BusinessPage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "565b6f94ceaedf12db5d6b8aae60cbf27b91a2165491", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "565b6f94ceaedf12db5d6b8aae60cbf27b91a2165753", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "565b6f94ceaedf12db5d6b8aae60cbf27b91a2166931", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<h1>BusinessPage</h1>\r\n\r\n<div>\r\n    <h4>BusinessUserModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.BusinessName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.Info));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayNameFor(model => model.Sector));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
       Write(Html.DisplayFor(model => model.Sector));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<div class=\"mb-5\">\r\n    ");
#nullable restore
#line 65 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "565b6f94ceaedf12db5d6b8aae60cbf27b91a21614431", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<div class=""row"">
    <div class=""container"">
        <div class=""tab"">
            <button class=""tablinks"" onclick=""openDay(event, 'Mon')"">Monday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Tue')"">Tuesday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Wed')"">Wednesday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Thu')"">Thursday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Fri')"">Friday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Sat')"">Saturday</button>
            <button class=""tablinks"" onclick=""openDay(event, 'Sun')"">Sunday</button>
        </div>
");
#nullable restore
#line 80 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
           TimeSlotCollection _timeSlotCollection = new TimeSlotCollection();
            IEnumerable<TimeSlotModel> timeSlots = _timeSlotCollection.GetTimeSlotByBusinessId(Model.Id).OrderBy(o => o.StartTime);

            List<string> DotW = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        <!-- Tab content -->\r\n        <div class=\"weekBox\">\r\n\r\n");
#nullable restore
#line 92 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
             foreach (var day in DotW)
            {
                if (day == "Mon")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("id", " id=\"", 3206, "\"", 3215, 1);
#nullable restore
#line 96 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
WriteAttributeValue("", 3211, day, 3211, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""tabcontent"" style=""display: block;"">
                        <div class=""TimeSlots"">
                            <table style=""width:100%"">
                                <tr>
                                    <th>Day</th>
                                    <th>Start Time</th>
                                    <th>End Time</th>
                                    <th>Spots</th>
                                    <th></th>

                                </tr>
");
#nullable restore
#line 107 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                 foreach (var timeSlot in timeSlots)
                                {
                                    if (timeSlot.DayOTWeek == day)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th>");
#nullable restore
#line 112 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.DayOTWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <td>");
#nullable restore
#line 113 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.StartTime.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 114 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.EndTime.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 115 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.NumberOfSpots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 117 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </table>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 122 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("id", " id=\"", 4586, "\"", 4595, 1);
#nullable restore
#line 125 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
WriteAttributeValue("", 4591, day, 4591, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""tabcontent"" style=""display: none;"">
                        <div class=""TimeSlots"">
                            <table style=""width:100%"">
                                <tr>
                                    <th>Day</th>
                                    <th>Start Time</th>
                                    <th>End Time</th>
                                    <th>Spots</th>
                                    <th></th>

                                </tr>
");
#nullable restore
#line 136 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                 foreach (var timeSlot in timeSlots)
                                {
                                    if (timeSlot.DayOTWeek == day)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th>");
#nullable restore
#line 141 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.DayOTWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <td>");
#nullable restore
#line 142 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.StartTime.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 143 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.EndTime.TimeOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 144 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                                           Write(timeSlot.NumberOfSpots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 147 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"

                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </table>\r\n\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 154 "C:\Users\casle\Documents\GitHub\CLeeflang_IndividueelProject\MainProject\CLeeflang_IndividueelProject\Views\Home\BusinessPage.cshtml"
                }

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Logic.BusinessUser.BusinessUserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
