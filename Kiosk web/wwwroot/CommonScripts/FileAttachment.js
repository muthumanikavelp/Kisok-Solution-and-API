// Javascript log4j root functionality //
var js_filename = "";
js_filename = "FileAttachment.js";

function getCurentForm_FileName() {
    var pagePathName = window.location.pathname;
    return pagePathName.substring(pagePathName.lastIndexOf("/") + 1);
}

function javascript_log4j_root(methodName, errmsg) {
    try {
        var err_data = {};
        err_data.formName = getCurentForm_FileName();
        err_data.filename = js_filename;
        err_data.methodName = methodName.toString();
        err_data.errmsg = errmsg.toString();
        var result = ajaxcall_param('/Home/javascript_log4j', JSON.stringify(err_data));
    }
    catch (err) {
        alert(err);
    }
}

function gridAttach(Attach_data) {
    $("#fileattach_Grid").kendoGrid({
        dataSource: {
            data: Attach_data,
        },
        change: function (e) {
            debugger;
            var grid_cont = $("#fileattach_Grid").data("kendoGrid");
            var selectedItem = grid_cont.dataItem(grid_cont.select());
            var grp = selectedItem.attach_group_code;
            var subgrp = selectedItem.attach_subgroup_code;
            var notes = selectedItem.notes;
            $("#cmb_attr_group").empty();
            list_in = grid_comboScreen_mastercodes("ATTCH_GRP");
            filter_combobox("cmb_attr_group", list_in);
            $("#cmb_attr_subgroup").empty();
            list_in = grid_comboScreen_mastercodes("ATTCH_SGRP");
            filter_combobox("cmb_attr_subgroup", list_in);
            $("#cmb_attr_group").data("kendoComboBox").value(grp);
            Category_selectChange();
            $("#cmb_attr_subgroup").data("kendoComboBox").value(subgrp);
            $("#txtRemarks").val(notes);
            $("#txtVersion").val(selectedItem.file_version);
            $("#txtFilename").val(selectedItem.filename);
            $("#txtSize").val(selectedItem.file_size);
            $("#txtSeqNo").val(selectedItem.attach_rowid);
            $("#txtfilepath").val(selectedItem.file_path);
            $("#txtfilepathdown").val(selectedItem.file_path);
            $('#cmb_attr_subgroup').data("kendoComboBox").enable(true);
            // $("#cmb_attr_subgroup").removeAttr('disabled');
            $("#txtVersion").prop("readonly", true);
            $("#txtFilename").prop("readonly", true);
            $("#txtSize").prop("readonly", true);
            //$("#file").removeAttr('disabled');
            $("#file").prop("disabled", true);
            $("#btnDwnload").attr("href", selectedItem.file_path);          
            $("#txtModeFlag").val("U");
        },
        height: 200,
        //selectable: true,
        selectable: "singl",
        scrollable: true,
        columns: [
              {
                  field: "attach_rowid",
                  title: "Attach Row",
                  hidden: true,
                  width: 50
              },
               {
                   field: "filename",
                   title: "File Name",
                   width: 120

               },
              {
                  field: "file_version",
                  title: "Version",
                  width: 100

              },
               {
                   field: "file_path",
                   title: "Path",
                   hidden: true,
                   width: 100

               },
                {
                    field: "notes",
                    title: "Remarks",
                    width: 120

                }]
    });
}

$(document).ready(function () {
    $('#fileattachModal').on('shown.bs.modal', function (e) {
        $('#fahdr').text(hdrtitle + ' - Attachment');
        page_load();
    });

    $('#fileattachModal').on('loaded.bs.modal', function (e) {
        $('#fahdr').text(hdrtitle + ' - Attachment');
        page_load();
    });


    $("#fileattachModal").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
    });
    $("#fileattach_Grid .k-grid-content").css("height", "200px");

    if ($("#modevalue").text() == "View Mode") {
        $("#file_attach").hide();
    }

});

function page_load() {
    load_master_combo_code();
    $("#txtFileID").val(getlocalStorage("doc_no"));
    $("#txtFileDate").val('');
    $("#txtFileStatus").val('');
    $("#txtDocRowID").val(getlocalStorage("doc_row_id"))
    $("#txtMenuID").val(getlocalStorage("MenuId"));
    $("#txtSeqNo").val("0");
    //$("#txtVersion").val("1");
    $("#txtModeFlag").val("I");
    $("#cmb_attr_group").empty();
    list_in = grid_comboScreen_mastercodes("ATTCH_GRP");
    filter_combobox("cmb_attr_group", list_in);
    $("#cmb_attr_subgroup").empty();
    list_in = grid_comboScreen_mastercodes("ATTCH_SGRP");
    filter_combobox("cmb_attr_subgroup", list_in);
    fetch_DocAttach_details($("#txtDocRowID").val(), $("#txtFileID").val(), $("#txtMenuID").val());
    $('#cmb_attr_subgroup').data("kendoComboBox").enable(false);
    $("#fileDate").css("display", "none");
    $("#fileStatus").css("display", "none");

}

function load_master_combo_code() {
    var data = {};
    data.screen_Id = "ATTACH_DOC";
    var tab_values = ajaxcall_param("/Home/screenId_mastercodelist", JSON.stringify(data));
}

function Category_selectChange() {
    debugger;
    $('#cmb_attr_subgroup').data('kendoComboBox').value('');
    var category = $('#cmb_attr_group').data("kendoComboBox").text();
    for (var i = 0; i < ($('#cmb_attr_subgroup').data("kendoComboBox").dataSource._data.length) ; i++) {
        var val = $('#cmb_attr_subgroup').data('kendoComboBox').dataSource._data[i].dependent;
        // alert(val);
        var row = $($('#cmb_attr_subgroup').data('kendoComboBox').list.find('li')[i]);
        // alert(row);
        if (val == category) {
            row.css('display', 'block');
            $('#cmb_attr_subgroup').data("kendoComboBox").enable(true);
        }
        else {
            row.css('display', 'none')
        }
    }
}

$("#file").change(function () {
    readURL(this);

});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.readAsDataURL(input.files[0]);
    }
}

var file_Val = "";
var file_Size = "";
var download_fileName = "";
var dn_file_name = "";


function save_file() {
    try {
        document.getElementById('file').files[0];
        file_Val = document.getElementById('file').files[0].name;
        file_Size = document.getElementById('file').files[0].size;
        $("#txtFilename").val(file_Val);
        $("#txtVersion").val("1");
        var fileupload_size = bytesToSize(file_Size);
        $("#txtSize").val(fileupload_size);
        if (file_Size > 5242880) {
            kendoAlert("File length cannot exceed 5 MB", "Warnning");
            $("#txtSize").val("");
            $("#txtFilename").val("");
        }
    }
    catch (error) {
        alert(error)
    }
}

function bytesToSize(bytes) {
    var kilobyte = 1024;
    var megabyte = kilobyte * 1024;
    var gigabyte = megabyte * 1024;
    var terabyte = gigabyte * 1024;
    if ((bytes >= 0) && (bytes < kilobyte)) {
        return bytes + ' B';
    } else if ((bytes >= kilobyte) && (bytes < megabyte)) {

        return ((bytes / kilobyte)).toFixed(2) + ' KB';

    } else if ((bytes >= megabyte) && (bytes < gigabyte)) {

        return ((bytes / megabyte)).toFixed(2) + ' MB';

    } else if ((bytes >= gigabyte) && (bytes < terabyte)) {
        return ((bytes / gigabyte)).toFixed(2) + ' GB';

    } else if (bytes >= terabyte) {
        return ((bytes / terabyte)).toFixed(2) + ' TB';

    } else {
        return bytes + ' B';
    }
}

function btn_upload() {
    if ($("#txtSeqNo").val() == "0") {
        if ($("#txtFilename").val() != "") {
            if (fileExists()) {
                // e.preventDefault();
                var kendoWindow = $("<div />").kendoWindow
                    ({
                        title: "Confirm",
                        width: "350px",
                        height: "130px",
                        resizable: false,
                        modal: true
                    });
                kendoWindow.data("kendoWindow")
            .content($("#fileAttach-confirmation").html())
            .center().open();
                kendoWindow
                    .find(".fileAttach-confirm,.fileAttach-cancel")
                        .click(function () {
                            if ($(this).hasClass("fileAttach-confirm")) {

                                var newver = parseInt(ver_no) + 1;
                                $("#txtVersion").val(newver);
                                $("#txtModeFlag").val("I");
                                //updateVer_upload();
                                save_Image();

                            }
                            else {

                                kendoAlert("File not upgraded", "Warning");
                            }

                            kendoWindow.data("kendoWindow").close();
                        })
                        .end()
            }
            else {
                save_Image();

            }
        }
        else {
            kendoAlert("FileName cannot be blank", "Warning");
        }
    }
    else {
        updateVer_upload();
    }

    //save_Image();  
}

function save_Image() {
    try {
        var rowid = $("#txtDocRowID").val();
        var ver = $("#txtVersion").val();
        var xhr = new XMLHttpRequest();
        var fd = new FormData();
        fd.append("upFiles", document.getElementById('file').files[0]);
        var formval = form_Serialize("frm_attach");
        fd.append("formval", formval);
        var Save_FileName = document.getElementById('file').files[0].name;
        var sp_file = Save_FileName.split(".");
        fd.append("name", sp_file[0] + "_" + rowid + "_" + ver);
        xhr.open("POST", "/FileAttachment/file_load/", true);
        xhr.send(fd);
        xhr.addEventListener("load", function (event) {
            var file_result = JSON.parse(this.responseText);
            // console.log(file_result.success);
            // if (file_result.success == true) {
            $("#txtfilepath").val(file_result.result);
            updateVer_upload();
            //fetch_DocAttach_details($("#txtDocRowID").val(), $("#txtFileID").val(), $("#txtMenuID").val());
            //clear();
            //kendoAlert(file_result.msg);
            //}
            // else {
            // kendoAlert(file_result.msg);
            // }

        }, false);
    }
    catch (error) {
        alert(error);
    }
}



function updateVer_upload() {
    debugger;
    var data = {};
    var formval = form_Serialize("frm_attach");
    var obj_val = JSON.parse(formval);
    obj_val.userid = getlocalStorage("User_Id_Value");
    obj_val.orgnId = getlocalStorage("org_code");
    obj_val.localeid = "en_US";
    obj_val.locnid = "chennai";
    data = obj_val;
    var save_details = ajaxcall_param('/FileAttachment/save_docAttach', JSON.stringify(data));
    if (save_details != undefined) {
        var Doc_detail = JSON.parse(save_details);
        if (Doc_detail.success == true) {
            kendoAlert(Doc_detail.msg);
            fetch_DocAttach_details($("#txtDocRowID").val(), $("#txtFileID").val(), $("#txtMenuID").val());
            file_clear();
        }
        else {
            kendoAlert(Doc_detail.msg);
        }
    }
}

function file_clear() {
    $("#txtFilename").val("");
    $("#txtVersion").val("");
    $("#txtRemarks").val("");
    $("#txtSize").val("");
    $("#txtSeqNo").val("0");
    $('#cmb_attr_group').data("kendoComboBox").value("");
    $('#cmb_attr_subgroup').data("kendoComboBox").enable(false);
    $('#cmb_attr_subgroup').data("kendoComboBox").value("");
    $("#file").prop("disabled", false);
    $("#txtModeFlag").val("I");
}

var file_data = [];
function fetch_DocAttach_details(DocNo, DocType, ScreenID) {
    debugger;
    var data_Doc_details = {};
    data_Doc_details.userid = getlocalStorage("User_Id_Value");
    data_Doc_details.orgnId = getlocalStorage("org_code");
    data_Doc_details.localeid = "en_US";
    data_Doc_details.locnid = "chennai";
    data_Doc_details.Doc_No = DocNo;
    data_Doc_details.Doc_Type = DocType;
    data_Doc_details.screen_id = ScreenID;
    var get_Doc_detail = ajaxcall_param("/FileAttachment/fetch_docAttach", JSON.stringify(data_Doc_details));
    if (get_Doc_detail != undefined) {

        Attach_data = JSON.parse(get_Doc_detail);
        if (Attach_data.filelist != "null") {
            if (Attach_data.success == true) {
                file_data = (JSON.parse(Attach_data.filelist));
                gridAttach(JSON.parse(Attach_data.filelist));
            }
        }
        else {         
            var Attach_data = [];
            gridAttach(Attach_data);
        }
    }

}


var ver_no = 0;
function fileExists() {
    ver_no = 0;
    var file_exists = false;
    var grid_data = $("#fileattach_Grid").data("kendoGrid").dataSource.data();

    for (var i = 0; i < grid_data.length; i++) {
        if (grid_data[i].filename == file_Val) {
            //$("#txtseqno").val(grid_data[i].seq_no);

            if (ver_no == 0) {
                ver_no = grid_data[i].file_version;
            }
            if (grid_data[i].file_version > ver_no) {
                ver_no = grid_data[i].file_version;
            }
            file_exists = true;
        }
    }
    return file_exists;
}

function delete_attachment() {
    debugger;
    var data = {};
    var formval = form_Serialize("frm_attach");
    var obj_val = JSON.parse(formval);
    obj_val.userid = getlocalStorage("User_Id_Value");
    obj_val.orgnId = getlocalStorage("org_code");
    obj_val.localeid = "en_US";
    obj_val.locnid = "chennai";
    data = obj_val;
    var save_details = ajaxcall_param('/FileAttachment/delete_docAttach', JSON.stringify(data));
    if (save_details != undefined) {
        var Doc_detail = JSON.parse(save_details);
        if (Doc_detail.success == true) {
            kendoAlert(Doc_detail.msg);
            $("#download_exl_template").attr("href", "");
            $("#txtfilepathdown").val('');
            fetch_DocAttach_details($("#txtDocRowID").val(), $("#txtFileID").val(), $("#txtMenuID").val());
        }
        else {
            kendoAlert(Doc_detail.msg);
        }
    }
}



function btn_remove() {
    var gridattach = $("#fileattach_Grid").data("kendoGrid");
    var selectedItem = gridattach.dataItem(gridattach.select());

    if ($("#txtSeqNo").val() != "0") {
        if ($("#txtFilename").val() != "") {
            if (selectedItem != null) {
                var kendoWindow = $("<div />").kendoWindow
                                  ({
                                      title: "Confirm",
                                      width: "350px",
                                      height: "130px",
                                      resizable: false,
                                      modal: true
                                  });
                kendoWindow.data("kendoWindow")
            .content($("#selectfile-confirmation").html())
            .center().open();
                kendoWindow
                    .find(".selectfile-confirm,.selectfile-cancel")
                        .click(function () {
                            if ($(this).hasClass("selectfile-confirm")) {
                                $("#txtModeFlag").val("D");
                                var remove_file = selectedItem.file_path;
                                $("#txtfilepath").val(remove_file);
                                $("#txtSeqNo").val(selectedItem.attach_rowid);
                                //save_Image();
                                delete_attachment();
                                file_clear();
                            }
                            else {
                                // updateVer_upload();
                                kendoWindow.data("kendoWindow").close();
                            }

                            kendoWindow.data("kendoWindow").close();
                        })
                        .end()
            }

            else {
                kendoAlert("Please select a file to Remove", "Message");
            }
        }
        else {
            kendoAlert("FileName cannot be blank", "Message");
        }
    }
    else {
        kendoAlert("Please select a file to Remove", "Message");
    }
}