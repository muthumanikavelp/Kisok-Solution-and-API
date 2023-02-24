// Javascript log4j root functionality //
var js_filename = "";
js_filename = "ExportExcel.js";

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


$(document).ready(function () {
    $('#exportexcelModal').on('show.bs.modal', function (e) {
        $('#exporthdr').text(hdrtitle + '- Export Excel');
        //filter_combobox("cmbtemp", []);
       $('#cmbtemp').append();
        get_file_path_details();
        $('#chkall').prop("checked", false);
        $('#chkfilter').prop("checked", false);
        $('#chktemp').prop("checked", false);
        if ($('#cmbtemp').data("kendoComboBox") != undefined) {
            $('#cmbtemp').data("kendoComboBox").value('');
            $('#cmbtemp').data("kendoComboBox").enable(false);
        }
        $('#btnExc').prop("disabled", true);
    });

    $('#exportexcelModal').on('loaded.bs.modal', function (e) {
        $('#exporthdr').text(hdrtitle + '- Export Excel');
        get_file_path_details();
      //  filter_combobox("cmbtemp", []);
        $('#chkall').prop("checked", false);
        $('#chkfilter').prop("checked", false);
        $('#chktemp').prop("checked", false);
        if ($('#cmbtemp').data("kendoComboBox") != undefined) {
            $('#cmbtemp').data("kendoComboBox").value('');
            $('#cmbtemp').data("kendoComboBox").enable(false);
        }
        $('#btnExc').prop("disabled", true);
    });
});


$(function () {
    $('#chkall').on('click', function () {
        var checked = $(this).is(':checked');
        if (checked == true) {
            $('#chkall').prop("checked", true);
            $('#chkfilter').prop("checked", false);
            $('#chktemp').prop("checked", false);
            $('#cmbtemp').data("kendoComboBox").value('');
            $('#cmbtemp').data("kendoComboBox").enable(false);
            $('#btnExc').prop("disabled", false);
        }
        else {
            $('#cmbtemp').data("kendoComboBox").enable(false);
            $('#btnExc').prop("disabled", true);
        }
    });

    $('#chkfilter').on('click', function () {
        var checked = $(this).is(':checked');
        if (checked == true) {
            $('#chkall').prop("checked", false);
            $('#chkfilter').prop("checked", true);
            $('#chktemp').prop("checked", false);
            $('#cmbtemp').data("kendoComboBox").value('');
            $('#cmbtemp').data("kendoComboBox").enable(false);
            $('#btnExc').prop("disabled", false);
        }
        else {
            $('#cmbtemp').data("kendoComboBox").enable(false);
            $('#btnExc').prop("disabled", true);
        }
    });

    $('#chktemp').on('click', function () {
        var checked = $(this).is(':checked');
        if (checked == true) {
            $('#chkall').prop("checked", false);
            $('#chkfilter').prop("checked", false);
            $('#chktemp').prop("checked", true);
            $('#cmbtemp').data("kendoComboBox").enable(true);
            $('#btnExc').prop("disabled", false);
        }
        else {
            $('#cmbtemp').data("kendoComboBox").enable(false);
            $('#btnExc').prop("disabled", true);
        }
    });
});

function export_fuc() {
    $('.k-grid-excel').click();

}

function get_file_path_details() {
    var excel_data = {};
    var combo_data = [];
    var items = {};
    excel_data.userId = getlocalStorage('User_Id_Value');
    excel_data.type_code = "EXCEL";
    excel_data.menu_id = Screen_Id;
    //var spl_details = ajaxcall_param_new("/ExportExcel/fetch_file_path_details", excel_data);
    var spl_details = ajaxcall_param_login("/ExportExcel/fetch_file_path_details", JSON.stringify(excel_data));
    if (spl_details != undefined) {
        var mod_data = JSON.parse(spl_details);
        if (mod_data.success == true) {
            var file_locn = JSON.parse(mod_data.set1);
            if (file_locn != null) {
                for (var i = 0; i < file_locn.length; i++) {
                    var temp = file_locn[i].file_path;
                    items[i] = file_locn[i].template_name;
                    combo_data.push({ code: temp, desc: items[i] });
                }
                filter_combobox("cmbtemp", combo_data);
                $('#chktemp').prop("disabled", false);
            }
            else {
                filter_combobox("cmbtemp", []);
                $('#chktemp').prop("disabled", true);
            }
        }
        else {
            var message = mod_data.msg;
            kendoAlert(message);
        }
    }
}




function combo_download() {
    var index = $('#cmbtemp').data('kendoComboBox').select();
    var combo = $("#cmbtemp").data("kendoComboBox");
    var data = combo.dataItem(index);
    $("#btnExcDown").attr("href", data.path);
}


function getfilename_forExport() {
    var sdata = {};
    var items = {};
    var combo_data = [];
    sdata.TreeId = TreeId;
    sdata.SubTreeId = SubTreeId;
    if ((TreeId == undefined) && (SubTreeId == undefined)) {
        $("#cmbtemp").empty();
        filter_combobox("cmbtemp", combo_data);
    }
    else if ((TreeId != undefined) && (SubTreeId != undefined)) {
        var export_excel_data = ajaxcall_param("/ExportExcel/getfilename", JSON.stringify(sdata));
        var task_data = JSON.parse(export_excel_data);
        if (task_data.success == true) {
            var result = task_data.result;
            var length = result.split(',').length;
            $("#cmbtemp").empty();
            for (var i = 0; i < length; i++) {
                items[i] = result.split(',')[i].replace(/^.*[\\\//]/, '').split('.')[0];
                //  $("#cmbtemp").append('<option value="' + i + '">' + items[i] + '</option>');

                //combo_data = [{
                //     code: i, desc: items[i]
                // }];
                combo_data.push({ code: i, desc: items[i] });
            }
            filter_combobox("cmbtemp", combo_data);
        }
        else if (task_data.success == false) {
            $("#cmbtemp").empty();
            filter_combobox("cmbtemp", combo_data);
        }
    }
}

