#pragma checksum "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6aa1838e96d1cc0ac0a22e9ba760e5703358b18e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ToDoList.Api.Extensions.Activity.Views_Activity_Details), @"mvc.1.0.view", @"/Views/Activity/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Activity/Details.cshtml", typeof(ToDoList.Api.Extensions.Activity.Views_Activity_Details))]
namespace ToDoList.Api.Extensions.Activity
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\_ViewImports.cshtml"
using ToDoList;

#line default
#line hidden
#line 4 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\_ViewImports.cshtml"
using ToDoList.Api.ViewsModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6aa1838e96d1cc0ac0a22e9ba760e5703358b18e", @"/Views/Activity/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3053f17a056662572479834371cd6cd9e1e179e", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ToDoList.Core.Models.Activity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml"
  
    ViewData["Title"] = Model.Title;

#line default
#line hidden
            BeginContext(83, 117, true);
            WriteLiteral("\r\n<h2>To Do List - szczegóły</h2>\r\n\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-heading\">\r\n        <h3>");
            EndContext();
            BeginContext(201, 11, false);
#line 10 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml"
       Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(212, 82, true);
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"panel-body\">\r\n        <div>\r\n            Data: ");
            EndContext();
            BeginContext(295, 10, false);
#line 14 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml"
             Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(305, 56, true);
            WriteLiteral("\r\n        </div>\r\n        <div>\r\n            Szczegóły: ");
            EndContext();
            BeginContext(362, 10, false);
#line 17 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml"
                  Write(Model.Note);

#line default
#line hidden
            EndContext();
            BeginContext(372, 100, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"panel-footer\">\r\n        <div>\r\n            Priorytet: ");
            EndContext();
            BeginContext(473, 35, false);
#line 22 "C:\Users\mssyp\Desktop\projekty\ToDoList\ToDoList\Views\Activity\Details.cshtml"
                  Write(Model.Priority.GetEnumDisplayName());

#line default
#line hidden
            EndContext();
            BeginContext(508, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ToDoList.Core.Models.Activity> Html { get; private set; }
    }
}
#pragma warning restore 1591
