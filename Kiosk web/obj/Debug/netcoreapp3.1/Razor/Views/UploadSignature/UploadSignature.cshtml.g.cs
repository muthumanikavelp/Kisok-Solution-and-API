#pragma checksum "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\UploadSignature\UploadSignature.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8f184b69092b7da4ca07f35839ea610dff48015"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UploadSignature_UploadSignature), @"mvc.1.0.view", @"/Views/UploadSignature/UploadSignature.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8f184b69092b7da4ca07f35839ea610dff48015", @"/Views/UploadSignature/UploadSignature.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d42bb5d0362289165b786aff1563b18b446af8d9", @"/Views/_ViewImports.cshtml")]
    public class Views_UploadSignature_UploadSignature : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("uploadsign_form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-role", new global::Microsoft.AspNetCore.Html.HtmlString("validator"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("novalidate", new global::Microsoft.AspNetCore.Html.HtmlString("novalidate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Save"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shade"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/save-finals.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("save_Image()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sign_img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Bill Image.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-5 img-bordered profileImg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("uploadsign_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("soil_print"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Ramya\Projects\Naf_Kiosk_Solution\Kiosk web\Views\UploadSignature\UploadSignature.cshtml"
  
    Layout = "~/Views/Shared/FormViewLayout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .k-window-titlebar {
        background-color: snow;
    }
    /*dropdown,date design overload*/
    .k-dropdown-wrap.k-state-default, .k-dropdown-wrap.k-state-focussed {
        background-color: #ffffff !important;
    }

    .k-picker-wrap.k-state-default, .k-picker-wrap.k-state-focussed {
        background-color: #ffffff !important;
    }
    /*table row line to be add*/
    .k-grid tr td {
        border-bottom: 1px solid #c5c5c5;
    }
</style>
<div class=""box-header text-center with-border"">
    <h3 class=""box-title"" style=""text-align: center; color: red; font-weight: 600; "">Upload Signature</h3>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8f184b69092b7da4ca07f35839ea610dff4801510368", async() => {
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <div id=\"grid_uploadsign\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div id=\"dialog\" style=\"background-color:white;\" >\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8f184b69092b7da4ca07f35839ea610dff4801512156", async() => {
                WriteLiteral(@"
        <div class=""row"">
            <div class=""col-sm-3"">
            </div>
            <div class=""col-sm-4"">
                <h5 style=""text-align:center;color:red;font-size:19px;"">Upload Signature</h5>
            </div>
            <div class=""col-sm-3"" id=""videomenu"">
                <div style=""float:right;"">

                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c8f184b69092b7da4ca07f35839ea610dff4801512779", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"&nbsp;

                </div>
            </div>
        </div>
        <hr style=""margin-top:0px !important;margin-bottom:0px !important;"">
        <div class=""row"" style=""margin-left: -5px; margin-top: 4%;"">
            <label class="" col-sm-3 control-label"" style=""font-weight: bold; padding-left: 5%;"">Name:</label>
            <div class="" col-sm-7"" style=""padding-left: 5%;"">
                <input type=""text"" name=""In_signature_name"" id=""txtsignname"" class=""form-control"" style="" height: 25px; margin-left: -25%;"">
            </div>
        </div>
        <div class=""row"" style=""margin-left: -5px; margin-top: 4%;"">
            <label class="" col-sm-3 control-label"" style=""font-weight: bold; padding-left: 5%;"">Designation:</label>
            <div class="" col-sm-7"" style=""padding-left: 5%;"">
                <input type=""text"" name=""In_signature_desgn"" id=""txtsigndesgn"" class=""form-control"" style="" height: 25px; margin-left: -25%;"">
            </div>
        </div>
        <div class=""row");
                WriteLiteral(@""" style=""margin-left: -5px;margin-top: 5%;"">
            <label class="" col-sm-3 control-label"" style=""font-weight: bold; padding-left: 5%;"">Signature Image:</label>
            <div class="" col-sm-7"" style=""padding-left: 5%;"">

                <input type=""file"" name=""In_signature_image"" id=""signfile"" class=""form-control"" style=""height: 25px;margin-left: -25%;"" />
                <label class=""title"" style=""width: 100%;margin-left: -25%;"" id=""filename"" name=""In_signature_image""></label>
                <input type=""hidden"" id=""signature_rowid"" name=""In_signature_rowid"" />
                <input type=""hidden"" id=""txtfilepath"" name=""In_signature_image"" />
                <input type=""hidden"" id=""txtMode"" name=""In_mode_flag"" />

            </div>

        </div>

        <div id=""dialogFileuploadView"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c8f184b69092b7da4ca07f35839ea610dff4801516207", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<div id=\"dialog1\" style=\"background-color:white;\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8f184b69092b7da4ca07f35839ea610dff4801519134", async() => {
                WriteLiteral("\r\n        <div class=\"row\">\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<script>
    $(document).ready(function () {
        $(""#dialogFileuploadView"").hide();
     
        kendodate_format();
        $(""#dialog"").hide();
        grid_uploadsign([]);
        list();
        load_master_code();
        Screen_Id = ""SIGN"";
        permission = sec_Master_Permission(Screen_Id);
    });
    $('#signfile').bind('change', function () {

        debugger;
        var fp = $(""#signfile"");
        var lg = fp[0].files.length; // get length
        var items = fp[0].files;
        var fileSize = 0;

        var ext = $('#signfile').val().split('.').pop().toLowerCase();
        //Allowed file types
        if ($.inArray(ext, ['png', 'jpg', 'jpeg']) == -1) {
            kendoAlert(""The file type is invalid.!"");
            $('#signfile').val("""");
            $('#upload-file-info').html("""");
        }

        if (lg > 0) {
            for (var i = 0; i < lg; i++) {
                fileSize = fileSize + items[i].size; // get file size
            }
 ");
            WriteLiteral(@"           if (fileSize > 314572800) {
                kendoAlert(""File size must not be more than 100 MB.!"");
                $('#signfile').val('');
                return false;
            }

        }
    });
    function load_master_code() {
        try {
            var data = {};
            data.screen_Id = ""SIGN"";
            var tab_values = ajaxcall_param(""/Home/screenId_mastercodelist"", JSON.stringify(data));
        }
        catch (err) {
            javascript_log4j_root(arguments.callee.name, err);
        }
    }
    function grid_uploadsign(data) {
        $(""#grid_uploadsign"").kendoGrid({
            dataSource: {
                data: data, //  pageSize: 20
            },
            height: 450,
            sortable: true,
            selectable: true,
            filterable: true,
            //change: onChangeSelection,
            selectable: ""singl"",   //  Grid Row Selection
            navigatable: true,
            toolbar: ""<a class='k-grid-add' id='A");
            WriteLiteral(@"ssign_sevices' onClick='serialno()'><span class='fa fa-plus' style='color:Black'></span></a>"",
            columns: [
               
                {
                    field: ""signature_rowid"",
                    title: ""Sign ID"",
                    width: 30
                },
                {
                    field: ""signature_name"",
                    title: ""Name"",
                    width: 30
                },
                {
                    field: ""signature_desgn"",
                    title: ""Designation"",
                    width: 30
                },
                {
                    field: ""signature_image"",
                    title: ""Signature image"",
                    width: 30
                },
                
                {
                    command: [
                        {
                            name: ""View"",
                            text: ""<span class='fa fa-eye' style ='color:#357ab8;'onClick='onview()'></span>""
     ");
            WriteLiteral(@"                   },
                        {
                            name: ""Edit"",
                            text: ""<span class='fa fa-pencil' style='color:#357ab8' onClick='onChangeSelection()'></span>""
                        },
                        {
                            name: ""Delete1"",
                            text: ""<span class='fa fa-times' style='color:#357ab8;padding-left:2px' onClick='ondelete()'></span>""
                        },
                    ], title: ""Action"", width: ""25px"",
                },
            ]
        });
    }
    function list() {
        debugger;
        var data = {};
        data.context = getContext();
        var Context = data.context;
        $.ajax({
            type: ""POST"",
            data: JSON.stringify({ orgnId: Context.orgnId, locnId: Context.locnId, localeId: Context.localeId, userId: Context.userId }),
            url: ""/UploadSignature/uploadsignList"",
            dataType: ""json"",
            contentType: 'a");
            WriteLiteral(@"pplication/json; charset=utf-8',
            success: function (response) {
                debugger;
                if (response != null) {
                    generate_uploadsign_list(response.list);
                }
                else {
                    grid_uploadsign([]);
                }
            },
            error: function (er) {
                alert(er)
                console.log(er)
            }

        });
    }
    function ondelete() {
        debugger;
        var kendoWindow = $(""<div />"").kendoWindow({
            title: ""Confirm"",
            width: ""350px"",
            height: ""130px"",
            resizable: false,
            modal: true
        });
        kendoWindow.data(""kendoWindow"")
            .content($(""#grid_delete-confirmation"").html())
            .center().open();
        kendoWindow
            .find("".grid_delete-confirm,.grid_delete-cancel"")
            .click(function () {
                if ($(this).hasClass(""grid_delete-con");
            WriteLiteral(@"firm"")) {
                    debugger;
                    var xhr = new XMLHttpRequest();
                    var fd = new FormData();
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == 4 && xhr.status == 200) {
                            kendoAlert(""Upload Signature Details Deleted successfully"");
                           
                            clear_val();
                            list();
                        }
                    };
                    var grid = $(""#grid_uploadsign"").data(""kendoGrid"");
                    var selectedItem = grid.dataItem(grid.select());
                    var formval = form_Serialize(""uploadsign_form"");
                    var obj_val1 = JSON.parse(formval);
                    obj_val1.In_signature_rowid = selectedItem.signature_rowid;
                    var data = getContext();
                    fd.append(""orgnId"", data.orgnId);
                    fd.append(""locnId"", data.locn");
            WriteLiteral(@"Id);
                    fd.append(""userId"", data.userId);
                    fd.append(""localeId"", data.localeId);
                    fd.append(""In_signature_rowid"", selectedItem.signature_rowid);
                    fd.append(""In_signature_tran_id"", selectedItem.signature_tran_id);
                    fd.append(""In_signature_name"", selectedItem.signature_name);
                    fd.append(""In_signature_desgn"", selectedItem.signature_desgn);
                    fd.append(""uploadFile"", document.getElementById('signfile').files[0]);
                    fd.append(""In_mode_flag"", ""D"");
                    xhr.open(""POST"", ""/UploadSignature/uploadsignsave"", true);
                    xhr.send(fd);
                    xhr.addEventListener(""load"", function (event) {
                    }, false);
                }
                kendoWindow.data(""kendoWindow"").close();
               
            });
    }
    function generate_uploadsign_list(res) {
        var data = changedataType(res);
");
            WriteLiteral(@"        grid_uploadsign(data);
    }
    function closerole() {
        $(""#dialog"").data(""kendoWindow"").close();
        list();
    }
    function serialno() {
        $(""#dialog"").kendoWindow();
        var dialog = $(""#dialog"").data(""kendoWindow"");
        dialog.open().element.closest("".k-window"").css({
            top: 171,
            left: 293, height: 330, width: 768
        });
        dialog.title(""Upload Signature"");
        dialog.bind(""open"", serialno);

        //add pop up close
        dialog.unbind(""close"");
        dialog.bind(""close"", onWindowEditClose);
        clear_val();
        $(""#videomenu"").show();
        //popup double click expand to avoid
        $(document).on('dblclick', '.k-window-titlebar', function (e) {
            debugger;
            // Restore old size
            dialog.toggleMaximization();
        });
    }
    //pop up close refresh
    var onWindowEditClose = function (e) {
        debugger;
        list();
    };
    function onC");
            WriteLiteral(@"hangeSelection() {
        debugger;
        $(""#dialog"").kendoWindow();
        var dialog = $(""#dialog"").data(""kendoWindow"");
        dialog.open().element.closest("".k-window"").css({
            top: 171,
            left: 293, height: 330, width: 768
        });
        dialog.title(""Upload Signature"");
        dialog.bind(""open"", serialno);
        clear_val();
        //popup double click expand to avoid
        $(document).on('dblclick', '.k-window-titlebar', function (e) {
            debugger;
            // Restore old size
            dialog.toggleMaximization();
        });
        var grid = $(""#grid_uploadsign"").data(""kendoGrid"");
        var selectedItem = grid.dataItem(grid.select());
        var formval = form_Serialize(""uploadsign_form"");
        var obj_val = JSON.parse(formval);
        obj_val.In_signature_rowid = selectedItem.signature_rowid;
        var data = {};
        data.context = getContext();
        data.context.Header = obj_val;
        var Context = da");
            WriteLiteral(@"ta.context;
        $.ajax({
            type: ""POST"",
            data: JSON.stringify({ userId: Context.userId, orgnId: Context.orgnId, locnId: Context.locnId, localeId: Context.localeId, In_signature_rowid: Context.Header.In_signature_rowid }),
            url: ""/UploadSignature/uploadsignfetch"",
            dataType: ""json"",
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                debugger;
                if (response != null) {
                    generate_uploadsign_fetch(response.UploadSign);
                }
                else {

                }
            },
            error: function (er) {
                alert(er)
                console.log(er)
            }

        });
        $(""#videomenu"").show();
    }
    function generate_uploadsign_fetch(res) {
        debugger;
        $(""#signature_rowid"").val(res.signature_rowid);
        $(""#txtMode"").val(res.mode_flag);
        $(""#txtsignname"").val(res");
            WriteLiteral(@".signature_name);
        $(""#txtsigndesgn"").val(res.signature_desgn);
        var filename = res.signature_image;
        $('#filename').text(filename);
    }
    function clear_val() {
        $(""#signature_rowid"").val("""");
        $(""#txtMode"").val("""");
        $(""#txtsignname"").val("""");
        $(""#txtsigndesgn"").val("""");
        $('#filename').text("""");
      
    }
    function save_Image() {
        debugger;
        var xhr = new XMLHttpRequest();
        var fd = new FormData();
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200)
            {
                    debugger;
                    kendoAlert(""Upload Signature saved successfully"");
                   // generate_uploadsign_fetch();
                    list();
            }
        };
        debugger;
        var data = getContext();
        var formval = form_Serialize(""uploadsign_form"");
        var obj_val = JSON.parse(formval);
       
        var adgid");
            WriteLiteral(@" = obj_val.In_signature_rowid;
        if (adgid == """") {
            obj_val.In_signature_rowid = 0;
        }
        else {
            obj_val.In_signature_rowid = parseInt(obj_val.In_signature_rowid);
        }
        var tranid = obj_val.In_signature_tran_id;
        if (tranid == """") {
            obj_val.In_signature_tran_id = ""0"";
        }

        if (obj_val.In_signature_name == """") {
            kendoAlert(""Signature Name Cannot be Empty"");
            return false;
        }
        if (obj_val.In_signature_desgn == """") {
            kendoAlert(""Signature designation Cannot be Empty"");
            return false;
        }
        if (obj_val.In_signature_rowid != 0) {
            obj_val.In_mode_flag = ""U"";
        }
        else {
            obj_val.In_mode_flag = ""I"";
        }

        fd.append(""userId"", data.userId);
        fd.append(""orgnId"", data.orgnId);
        fd.append(""locnId"", data.locnId);
        fd.append(""localeId"", data.localeId);
        fd.app");
            WriteLiteral(@"end(""In_signature_rowid"", obj_val.In_signature_rowid);
        fd.append(""In_signature_tran_id"", obj_val.In_signature_tran_id);
        fd.append(""In_signature_name"", obj_val.In_signature_name);
        fd.append(""In_signature_desgn"", obj_val.In_signature_desgn);
        var uploaddoc = $('#filename').text();
        fd.append(""In_signature_image"", uploaddoc);
        fd.append(""uploadFile"", document.getElementById('signfile').files[0]);
        fd.append(""In_mode_flag"", obj_val.In_mode_flag);
        xhr.open(""POST"", ""/UploadSignature/uploadsignsave"", true);
        xhr.send(fd);
        xhr.addEventListener(""load"", function (event) {
        }, false);
    }
    function onview() {

        debugger;
        $(""#dialog"").kendoWindow();
        var dialog = $(""#dialog"").data(""kendoWindow"");
        dialog.open().element.closest("".k-window"").css({
            top: 171,
            left: 293, height: 330, width: 768
        });
        dialog.title(""Upload Signature"");
        dialog.bin");
            WriteLiteral(@"d(""open"", serialno);
        clear_val();
        //popup double click expand to avoid
        $(document).on('dblclick', '.k-window-titlebar', function (e) {
            debugger;
            // Restore old size
            dialog.toggleMaximization();
        });
        var grid = $(""#grid_uploadsign"").data(""kendoGrid"");
        var selectedItem = grid.dataItem(grid.select());
        var formval = form_Serialize(""uploadsign_form"");
        var obj_val = JSON.parse(formval);
        obj_val.In_signature_rowid = selectedItem.signature_rowid;
        var data = {};
        data.context = getContext();
        data.context.Header = obj_val;
        var Context = data.context;
        $.ajax({
            type: ""POST"",
            data: JSON.stringify({ userId: Context.userId, orgnId: Context.orgnId, locnId: Context.locnId, localeId: Context.localeId, In_signature_rowid: Context.Header.In_signature_rowid }),
            url: ""/UploadSignature/uploadsignfetch"",
            dataType: ""json"",");
            WriteLiteral(@"
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                debugger;
                if (response != null) {
                    generate_uploadsign_fetch(response.UploadSign);
                }
                else {

                }
            },
            error: function (er) {
                alert(er)
                console.log(er)
            }

        });
        $(""#videomenu"").hide();
      
        //popup double click expand to avoid
        $(document).on('dblclick', '.k-window-titlebar', function (e) {
            debugger;
            // Restore old size
            dialog.toggleMaximization();


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