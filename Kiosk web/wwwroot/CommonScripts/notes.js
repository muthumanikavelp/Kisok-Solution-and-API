// Javascript log4j root functionality //
var js_filename = "";
js_filename = "notes.js";

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
    $('#notesModal').on('show.bs.modal', function (e) {
        $('#nthdr').text(hdrtitle + '- Notes');
        getNotesHistory();

    });

    $('#notesModal').on('loaded.bs.modal', function (e) {
        $('#nthdr').text(hdrtitle + '- Notes');
        getNotesHistory();

    });


    $("#notesModal").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
    });

    $("#notes_history_grid .k-grid-content").css("height", "200px");


    if ($("#modevalue").text() == "View Mode") {

        $("#btnSave").hide();
    }
    //$('#notesModal').on('shown.bs.modal', function (e) {
    //    getNotesHistory();
    //});

});

var doc_no = "";
var doc_row = "";

function getNotesHistory() {
    debugger;
    var data = {};
    data.menu_id = getlocalStorage('MenuId');
    data.doc_number = getlocalStorage("doc_no");
    doc_no = 1;
    data.doc_rowid = getlocalStorage("doc_row_id");
    doc_row = 1;
    data.userid = getlocalStorage("User_Id_Value");
    data.orgnId = getlocalStorage("org_code");
    data.localeid = "en_US";
    data.locnid = "chennai";
    var fetch_details = ajaxcall_param('/Notes/getNotes', JSON.stringify(data));
    if (fetch_details != undefined) {
        var Notes_fetch_detail = JSON.parse(fetch_details);
        if (Notes_fetch_detail.success == true) {
            var grid_data = JSON.parse(Notes_fetch_detail.list);
            if (grid_data != null) {
                generateGrid(grid_data);
            }
            else {
                generateGrid([]);
            }
        }
        else {
            var message = Notes_fetch_detail.msg;
            kendoAlert(message);
        }
    }
    $("#txtNotes").val('');

}

function generateGrid(data) {
    $("#notes_history_grid").kendoGrid({
        dataSource: {
            data: data,
        },
        height: 200,
        selectable: true,
        scrollable: true,
        columns: [
            {
                field: "created_by_name",
                title: "By",
                width: 50
            },
            {
                field: "created_datetime",
                title: "Date Time",
                width: 100
            },
            {
                field: "notes",
                title: "Notes",
                width: 350

            }]
    });
}


function savenotes() {
    if ($("#txtNotes").val() != "") {
        var save_data = {};
        save_data.userId = getlocalStorage('User_Id_Value');
        save_data.menu_id = getlocalStorage('MenuId');
        save_data.doc_rowid = getlocalStorage("doc_row_id");
        save_data.doc_number = getlocalStorage("doc_no");
        save_data.notes = $("#txtNotes").val();
        save_data.mode_flag = "I";
        save_data.userid = getlocalStorage("User_Id_Value");
        save_data.orgnId = getlocalStorage("org_code");
        save_data.localeid = "en_US";
        save_data.locnid = "chennai";
        var save_details = ajaxcall_param('/Notes/saveNotes', JSON.stringify(save_data));
        if (save_details != undefined) {
            var Notes_save_detail = JSON.parse(save_details);
            if (Notes_save_detail.success == true) {
                kendoAlert(Notes_save_detail.msg);
                getNotesHistory();

            }
        }
    }
    else {
        kendoAlert("Notes cannot be blank");
    }

}