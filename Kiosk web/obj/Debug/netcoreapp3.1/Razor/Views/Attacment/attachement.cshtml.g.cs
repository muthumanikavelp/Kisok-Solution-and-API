#pragma checksum "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\Attacment\attachement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd497b7a9504742e28906ad9b9394e1e9499c0f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attacment_attachement), @"mvc.1.0.view", @"/Views/Attacment/attachement.cshtml")]
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
#line 1 "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\_ViewImports.cshtml"
using Kiosk_web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\_ViewImports.cshtml"
using Kiosk_web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd497b7a9504742e28906ad9b9394e1e9499c0f9", @"/Views/Attacment/attachement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d42bb5d0362289165b786aff1563b18b446af8d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Attacment_attachement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#nullable restore
#line 1 "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\Attacment\attachement.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd497b7a9504742e28906ad9b9394e1e9499c0f93452", async() => {
                WriteLiteral("\r\n    <title></title>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd497b7a9504742e28906ad9b9394e1e9499c0f94441", async() => {
                WriteLiteral(@"
    <div class=""box-header text-center with-border"">
        <h3 class=""box-title"" style=""text-align:center;color:red;font-weight: 600;"">Attachment</h3>
    </div>
    <div class=""row"" style=""padding-top:20px;padding-bottom:20px;padding-left:10px"">
        <div class=""col-sm-3"">
            <label for=""txtcode"">Browse File</label>
            <input type=""file"" id=""txtcode"" name=""in_parent_code"" class=""form-control"" style=""width:96%;height:20px"">
        </div>
        <div class=""col-sm-3"">
            <label for=""txtcode"">Description</label>
            <input type=""text"" id=""txtdes"" name=""in_des_code"" class=""form-control"" style=""width:96%;height:20px"">
        </div>
        <div class=""col-sm-3"">
            <label for=""txtcode"">Document</label>
            <input type=""text"" id=""txtdoc"" name=""in_doc_code"" class=""form-control"" style=""width:90%;height:20px"">
        </div>
        <div class=""col-sm-1"">
            <label></label>
            <button type=""submit"" id=""button_Attachment""");
                WriteLiteral(@" value=""Upload"" class=""btn btn-primary"" style=""height:1%;margin-top:2%;""> <span class=""fa fa-upload""></span></button>
        </div>
    </div>
    <div class=""row"" style=""padding-left: 10px"">
        <div class=""col-lg-10"">
            <div id=""grid_attachment"">
            </div>
        </div>
    </div>
");
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
            WriteLiteral(@"
</html>
<script>
    $(document).ready(function () {
        grid_attachment([]);
    });
    $('#txtcode').bind('change', function () {

        debugger;
        var fp = $(""#txtcode"");
        var lg = fp[0].files.length; // get length
        var items = fp[0].files;
        var fileSize = 0;

        var ext = $('#txtcode').val().split('.').pop().toLowerCase();
        //Allowed file types
        if ($.inArray(ext, ['xlsx', 'xls', 'gif', 'png', 'jpg', 'jpeg', 'docx', 'doc', 'pdf', 'rtf', 'ppt', 'txt', 'odt', 'msg']) == -1) {
            kendoAlert(""The file type is invalid.!"");
            $('#txtcode').val("""");
           // $('#upload-file-info').html("""");
        }

        if (lg > 0) {
            for (var i = 0; i < lg; i++) {
                fileSize = fileSize + items[i].size; // get file size
            }
            if (fileSize > 314572800) {
                kendoAlert(""File size must not be more than 300 MB.!"");
                $('#txtcode').val('');
          ");
            WriteLiteral(@"      return false;
            }

        }
    });
    function grid_attachment(data) {
        $(""#grid_attachment"").kendoGrid({
            dataSource: {
                data: data, //  pageSize: 20
            },
            height: 270,
            sortable: true,
            selectable: true,
            navigatable: true,
            filterable: true,
            columns: [
                {
                    field: ""out_attach_rowid"",
                    title: ""attach Id"",
                    hidden: true,
                    width: 30
                },
                {
                    field: ""file_code"",
                    title: ""File"",
                    width: 30,
                    template: '<a href=\""#=file_code#\"">#=File#</a>'
                   
                },
                {
                    field: ""out_document"",
                    title: ""Document"",
                    width: 30
                },
                {
                 ");
            WriteLiteral(@"   field: ""out_descrition"",
                    title: ""descrition"",
                    width: 30
                },
                {
                    field: ""out_attached_by"",
                    title: ""Attached By"",
                    width: 30
                },
                {
                    command: [
                        {
                            name: ""Delete"",
                            text: ""<span class='fa fa-times' style='color:#357ab8;padding-left:2px' onClick='ondelete()'></span>""
                        },
                    ], title: ""Action"", width: ""25px"",
                },],
        });
    }
</script>

");
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
