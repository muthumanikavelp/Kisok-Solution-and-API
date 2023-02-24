
$(document).ready(function () {
    //load_data();
    $('#chklistModal').on('show.bs.modal', function (e) {
        $('#fahdr').text(hdrtitle + ' - Checklist');

    });

    $('#chklistModal').on('loaded.bs.modal', function (e) {
        $('#fahdr').text(hdrtitle + ' - Checklist');

        // load_data();

    });



    var combo_data2 = [{ code: 1, desc: "Stage 1" },
      { code: 2, desc: "Stage 2" },
      { code: 3, desc: "Stage 3" }];
    filter_combobox("cmb_stage", combo_data2);




    var data1 = [];
    $("#history_grid").kendoGrid({
        dataSource: {
            data: data1,
        },
        height: 200,
        selectable: true,
        scrollable: false,
        columns: [
             {
                 field: "code",
                 title: "Edit Date",
                 width: 100
             },
               {
                   field: "alert_desc",
                   title: "Edited by",
                   width: 200

               }]
    });



    if ($("#modevalue").text() == "New Mode") {
        $("#checklist_grid1").css("display", "none");
        $("#checklist_grid2").css("display", "none");
        $("#Checklist_grid").css("height", "340px");
        $("#checklist_body").css("height", "420px");
        $("#Checklist_grid .k-grid-content").css("height", "320px");
    }
    else {
        $("#Checklist_grid .k-grid-content").css("height", "200px");
    }

    if (($("#DocStat").val() == "Active") || ($("#DocStat").val() == "Rejected")) {
        $("#chklst_form #btnSave").attr("disabled", false);

    }
    else {
        $("#chklst_form #btnSave").attr("disabled", true);
       
    }
   
   

});
var menuId = "";
function load_data() {

    menuId = getlocalStorage("MenuId");
    console.log(menuId);
    if (menuId == "FARMER_PRO" || menuId == "FARMER_REG") {
        //var data = [{check_element: "KYC", check_subelement: "Address Proof", check_sub_value: "Aadhar card/Ration Card", mandatory: "0", values: "Aadhar- 5402 xxxxx 35 ", complied: "1", verify_on: "12/01/2017", verify_by: "gkan", remarks: "remarks1"
        //},
        //{
        //    check_element: "KYC", check_subelement: "ID Proof", check_sub_value: "Aadhar card/PAN Card/Passport", mandatory: "0", values: "", complied: "0", verify_on: "12/01/2017", verify_by: "gkan", remarks: ""
        //},
        // {
        //     check_element: "Photo Match", check_subelement: "Yes/No", check_sub_value: "", mandatory: "0", values: "", complied: "0", verify_on: "", verify_by: "", remarks: ""
        // }]
        try {
            var formval = form_Serialize("chklst_form");
            var obj_val = JSON.parse(formval);
            if (obj_val != undefined) {
                obj_val.doc_rowid = 0;
                obj_val.doc_no = "0";
                obj_val.doc_type = "0";
                var data = {};
                data.context = getContext();
                data.context.Header = obj_val;
                var Context = data.context;
                $.ajax({
                    type: "POST",
                    data: JSON.stringify({ userId: Context.userId, orgnId: Context.orgnId, locnId: Context.locnId, localeId: Context.localeId, doc_rowid: Context.Header.doc_rowid, doc_no: Context.Header.doc_no, doc_type: Context.Header.doc_type }),
                    url: "/Checklist/Checklistfetch",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    success: function (response) {
                        debugger;
                        if (response.context != null) {
                            generate_Chek_Tran_List_element(response.context.Element)
                            generate_Chek_Tran_List_history(response.context.History);
                        }
                        else {
                            load_checklist([]);
                        }
                    },
                    error: function (er) {
                        alert(er)
                        console.log(er)
                    }

                });

            }
        }
        catch (err) {
            javascript_log4j_root(arguments.callee.name, err);
            console.log(err);
        }

    }
        //else if (menuId == "FARMER_LOANAPP") {
        //    var data1 = [{
        //        check_element: "Sanction Letter", check_subelement: "Has the sanctioned letter accepted by Farmer", check_sub_value: "", mandatory: "1", values: "", complied: "", verify_on: "", verify_by: "", remarks: "NA"
        //    },
        //    {
        //        check_element: "Credit Evaluation", check_subelement: "Is the score as per eligibility standards", check_sub_value: "", mandatory: "0", values: "Score 720", complied: "", verify_on: "", verify_by: "", remarks: "NA"
        //    },
        //    {
        //        check_element: "Supplier Quotation", check_subelement: "Are quotations received from Supplier", check_sub_value: "", mandatory: "1", values: "2 Quotes Received", complied: "", verify_on: "", verify_by: "", remarks: ""
        //    },
        //    {
        //        check_element: "NACH Mandate", check_subelement: "Has mandate duly filled", check_sub_value: "", mandatory: "1", values: "", complied: "", verify_on: "", verify_by: "", remarks: ""
        //    },
        //    {
        //        check_element: "NACH Mandate", check_subelement: "Has the farmer submitted security cheques along with mandate", check_sub_value: "", mandatory: "1", values: "", complied: "", verify_on: "", verify_by: "", remarks: ""
        //    },
        //    ]
        //    load_checklist(data1);
        //}
    else {

    }
}

function generate_Chek_Tran_List_element(res) {
    try {
        if (res != null) {
            var data = changedataType(res);
            load_checklist(data);
        }
        else {
            load_checklist([]);
        }
    }
    catch (err) {
        javascript_log4j_root(arguments.callee.name, err);
    }
}



$(function () {
    $('#Checklist_grid').on('click', '.chkbx1', function () {
        var checked = $(this).is(':checked');
        var grid = $('#Checklist_grid').data().kendoGrid;
        var dataItem = grid.dataItem($(this).closest('tr'));
        var row = $(this).closest('tr');
        if (checked == true) {
            dataItem._set('mandatory', '1');
        }
        else {
            dataItem._set('mandatory', '0');
        }
    });

    $('#Checklist_grid').on('click', '.chkbx2', function () {
        var checked = $(this).is(':checked');
        var grid = $('#Checklist_grid').data().kendoGrid;
        var dataItem = grid.dataItem($(this).closest('tr'));
        var row = $(this).closest('tr');
        if (checked == true) {
            dataItem._set('complied', '1');
        }
        else {
            dataItem._set('complied', '0');
        }
    });
});
