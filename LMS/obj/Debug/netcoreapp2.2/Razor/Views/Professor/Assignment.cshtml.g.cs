#pragma checksum "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e6677f2756a860344b41dc55430580232a02fdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Assignment), @"mvc.1.0.view", @"/Views/Professor/Assignment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Assignment.cshtml", typeof(AspNetCore.Views_Professor_Assignment))]
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
#line 1 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e6677f2756a860344b41dc55430580232a02fdc", @"/Views/Professor/Assignment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Assignment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
  
    ViewData["Title"] = "Assignment";
    Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(103, 12, true);
            WriteLiteral("\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(115, 934, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e6677f2756a860344b41dc55430580232a02fdc4305", async() => {
                BeginContext(121, 921, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      /*width: 130px;
      height: 210px;
      position: fixed;
      z-index: 1;
      top: 80px;
      left: 10px;*/
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      /*margin-left: auto;
      margin-right: auto;*/
      z-index: 1;
      top: 50px;
      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
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
            EndContext();
            BeginContext(1049, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1051, 621, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e6677f2756a860344b41dc55430580232a02fdc6414", async() => {
                BeginContext(1057, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1092, "\'", 1215, 8);
                WriteAttributeValue("", 1099, "/Professor/Class?subject=", 1099, 25, true);
#line 59 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1124, ViewData["subject"], 1124, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1144, "&num=", 1144, 5, true);
#line 59 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1149, ViewData["num"], 1149, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1165, "&season=", 1165, 8, true);
#line 59 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1173, ViewData["season"], 1173, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1192, "&year=", 1192, 6, true);
#line 59 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1198, ViewData["year"], 1198, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1216, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1240, "\'", 1366, 8);
                WriteAttributeValue("", 1247, "/Professor/Students?subject=", 1247, 28, true);
#line 60 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1275, ViewData["subject"], 1275, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1295, "&num=", 1295, 5, true);
#line 60 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1300, ViewData["num"], 1300, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1316, "&season=", 1316, 8, true);
#line 60 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1324, ViewData["season"], 1324, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1343, "&year=", 1343, 6, true);
#line 60 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1349, ViewData["year"], 1349, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1367, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1388, "\'", 1516, 8);
                WriteAttributeValue("", 1395, "/Professor/Categories?subject=", 1395, 30, true);
#line 61 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1425, ViewData["subject"], 1425, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1445, "&num=", 1445, 5, true);
#line 61 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1450, ViewData["num"], 1450, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1466, "&season=", 1466, 8, true);
#line 61 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1474, ViewData["season"], 1474, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1493, "&year=", 1493, 6, true);
#line 61 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
WriteAttributeValue("", 1499, ViewData["year"], 1499, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1517, 148, true);
                WriteLiteral(">Assignment Categories</a>\r\n  </div>\r\n\r\n\r\n  <div class=\"main\">\r\n    <h4 id=\"asgname\">Assignment</h4>\r\n    <div id=\"asgcontents\"></div>\r\n\r\n  </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1672, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1714, 114, true);
                WriteLiteral("\r\n  <script type=\"text/javascript\">\r\n\r\n    LoadData();\r\n\r\n    function LoadData() {\r\n\r\n      asgname.innerText = \'");
                EndContext();
                BeginContext(1829, 17, false);
#line 85 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
                      Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(1846, 59, true);
                WriteLiteral("\';\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(1906, 45, false);
#line 89 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
         Write(Url.Action("GetAssignmentContents", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(1951, 68, true);
                WriteLiteral("\',\r\n        dataType: \'text\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(2020, 19, false);
#line 92 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(2039, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(2067, 15, false);
#line 93 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(2082, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(2107, 18, false);
#line 94 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(2125, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(2154, 16, false);
#line 95 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(2170, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(2197, 15, false);
#line 96 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(2212, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(2237, 17, false);
#line 97 "C:\Users\Camille\source\repos\LearningManagementSystem\LMS\Views\Professor\Assignment.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(2254, 383, true);
                WriteLiteral(@"'},
        success: function (data, status) {
          //alert(data);

          var contentsdiv = document.getElementById(""asgcontents"");
          contentsdiv.innerHTML = data;
          
        },
          error: function (ex) {
              alert(""GetAssignmentContents controller did not return successfully"");
        }
        });


    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(2640, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591