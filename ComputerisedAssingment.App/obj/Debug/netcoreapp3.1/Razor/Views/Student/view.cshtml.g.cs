#pragma checksum "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2c25a0a6075ea996e094940eaade2e423ba8858"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_view), @"mvc.1.0.view", @"/Views/Student/view.cshtml")]
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
#line 1 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\_ViewImports.cshtml"
using ComputerisedAssingment.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\_ViewImports.cshtml"
using ComputerisedAssingment.App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
using ComputerisedAssingment.ModelEntity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2c25a0a6075ea996e094940eaade2e423ba8858", @"/Views/Student/view.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d2bd6c723ee2a9661c663cc240815e9db379217", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_view : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upload", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "View", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
  
    List<TeacherUpload> teacherUploaddata = ViewBag.TeacherUploaddata;
    List<StudentUpload> studentUploaddata = ViewBag.StudentUploaddata;
    ViewData["Title"] = "view";
    Layout = "~/Views/Shared/_Layout_Users.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-fluid"" style=""margin-top: 8%;"">
    <div class=""row justify-content-center"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-body row"">
                    <div class=""col-md-4"" style=""border-right: 1px solid rgba(0,0,0,.125);"">
                        <div class=""col-md-6 offset-md-4"">
                            <br />
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2c25a0a6075ea996e094940eaade2e423ba88585517", async() => {
                WriteLiteral("\r\n                                Upload\r\n                                <br />\r\n                                <br />\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2c25a0a6075ea996e094940eaade2e423ba88587258", async() => {
                WriteLiteral("\r\n                                View\r\n                                <br />\r\n                                <br />\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
                    </div>

                    <div class=""col-md-8"">
                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th scope=""col"">Title</th>
                                    <th scope=""col"">Owner</th>
                                    <th scope=""col"">Deadline</th>
                                    <th scope=""col"">Status</th>
                                    <th scope=""col"">Grade</th>
                                </tr>
                            </thead>

                            <tbody>
");
#nullable restore
#line 44 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                 foreach (var i in teacherUploaddata)
                                {
                                    {
                                        bool check = false;

                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                         foreach (var j in studentUploaddata)
                                        {


                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                             if (i.Id == j.TeacherUploadId)
                                            {
                                                check = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2485, "\"", 2521, 2);
            WriteAttributeValue("", 2492, "/TeacherUpload/", 2492, 15, true);
#nullable restore
#line 57 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
WriteAttributeValue("", 2507, i.Upload_file, 2507, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 57 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                                                                           Write(i.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n\r\n                                                    <td>");
#nullable restore
#line 59 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                                   Write(i.TeacherUniqueId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 60 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                                   Write(i.Deadline.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                                                    <td>Submitted</td>\r\n\r\n\r\n                                                    <td>");
#nullable restore
#line 66 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                                   Write(j.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                                                </tr>\r\n");
#nullable restore
#line 70 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                         if (check == false)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td><a");
            BeginWriteAttribute("href", " href=\"", 3233, "\"", 3269, 2);
            WriteAttributeValue("", 3240, "/TeacherUpload/", 3240, 15, true);
#nullable restore
#line 76 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
WriteAttributeValue("", 3255, i.Upload_file, 3255, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 76 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                                                                       Write(i.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                                <td>");
#nullable restore
#line 77 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                               Write(i.TeacherUniqueId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 78 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                               Write(i.Deadline.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>Not Submitted</td>\r\n\r\n                                                <td>N\\A</td>\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 84 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\SERBIUS\Desktop\Project\Code\ComputerisedAssignment\ComputerisedAssingment.App\Views\Student\view.cshtml"
                                         
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
