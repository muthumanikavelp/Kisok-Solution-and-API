// Javascript log4j root functionality //
var js_filename = "";
js_filename = "AdvanceFilter.js";

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
function Onshow() {
    $('#advfilterModal').modal("show");

}

function closeModel() {
    $("#advfilterModal").modal("hide");
    //$("#advfilterModal").remove();
    //$('.modal-backdrop').remove();

}

$("#btn_select").click(function (event) {
    //document.getElementById("textserarch").value = "";
    //loadfilter();
});

function oncancel_filter() {
    $('#textserarch').val('');
    closeModel();
}
function onclear_filter() {
    $("#textserarch").val('');
    $("#txtString_0").val('');
    $("#txtString_1").val('');
    $("#txtString_2").val('');
    $("#txtString_3").val('');
    $("#txtString_4").val('');
    $("#txtString_5").val('');
    $("#txtString_6").val('');
    $("#txtString_7").val('');
    $("#txtString_8").val('');
    $("#txtString_9").val('');
    $("#txtString_10").val('');
    $("#txtString_11").val('');
    $("#txtString_12").val('');
    $("#txtString_13").val('');
    $("#txtString_14").val('');
    $("#txtString_15").val('');
    $("#txtString_16").val('');
    $("#txtString_17").val('');
    $("#txtString_18").val('');
    $("#txtString_19").val('');
    $("#txtString_20").val('');
    $("#txtString_21").val('');
    $("#txtString_22").val('');
    $("#txtString_23").val('');
    $("#txtString_24").val('');
    $("#txtString_25").val('');
    $("#txtString_16").val('');
    $("#txtDate_0").val('');
    $("#txtDate_1").val('');
    $("#txtDate_2").val('');
    $("#txtDate_3").val('');
    $("#txtDate_4").val('');
    $("#txtDate_5").val('');
    $("#txtInt_0").val('');
    $("#txtInt_1").val('');
    $("#txtInt_2").val('');
    $("#txtInt_3").val('');
    $("#txtInt_4").val('');
    $("#txtInt_5").val('');
    $("#txtInt_6").val('');
    $("#txtInt_7").val('');
    $("#txtInt_8").val('');
    $("#txtInt_9").val('');
    $("#txtInt_10").val('');
    $("#cmb_0").val('');
    $("#cmb_1").val('');
    $("#cmb_2").val('');
    $("#cmb_3").val('');
    $("#cmb_4").val('');
    $("#cmb_5").val('');
    $("#cmb_6").val('');
    $("#cmb_7").val('');
    $("#cmb_8").val('');
    $("#cmb_9").val('');
    $("#cmb_10").val('');
    $("#cmb_11").val('');
    $("#cmb_12").val('');
    $("#cmb_13").val('');
    $("#cmb_14").val('');
    $("#cmb_15").val('');
    $("#cmb_16").val('');
    $("#cmb_17").val('');
    $("#cmb_18").val('');
    $("#cmb_19").val('');
    $("#cmb_20").val('');
    $("#cmb_21").val('');
    $("#cmb_22").val('');
    $("#cmb_23").val('');
    $("#cmb_24").val('');
    $("#cmb_25").val('');
    $("#cmb_26").val('');
    $("#cmb_27").val('');
    $("#cmb_28").val('');
    $("#cmb_29").val('');
    $("#cmb_30").val('');
}
var gridRowID = -1;
var grid1_inc = 0;

$(document).ready(function () {

    $('#advfilterModal').on('show.bs.modal', function (e) {
        pager_click = true;
        $(this).data('modal', null);
        var data_flterid = {};
        data_flterid.filterID = fltID;
        //filter_condition = "";
        var data = {};
        data.fltercond = "";

        ajaxcall_param('/AdvancedFilter/setFilter_condition', JSON.stringify(data));

        $('#advhdr').text(hdrtitle + ' - Filter By');

        $("#textserarch").val("");

        var data = ajaxcall_param("/AdvancedFilter/filterdetails", JSON.stringify(data_flterid));
        if (data != undefined) {
            data = JSON.parse(data);
            gridFilter(data);
        }

        pageload_ScreenIdmaster_code();
    })

    $('#advfilterModal').on('loaded.bs.modal', function (e) {
        pager_click = true;
        var data_flterid = {};
        data_flterid.filterID = fltID;
        // filter_condition = "";
        var data = {};
        data.fltercond = "";

        ajaxcall_param('/AdvancedFilter/setFilter_condition', JSON.stringify(data));
        $('#advhdr').text(hdrtitle + ' - Filter By');

        $("#textserarch").val("");
        var data = ajaxcall_param("/AdvancedFilter/filterdetails", JSON.stringify(data_flterid));
        if (data != undefined) {
            data = JSON.parse(data);
            gridFilter(data);
        }
        pageload_ScreenIdmaster_code();
    });

});


function gridFilter(data) {
    gridRowID = -1;
    grid1_inc = 0;
    var grid = $("#gridFilter").kendoGrid({


        dataSource: {
            data: data,
        },
        columns: [{
            field: "coldesc",
            title: "Field",
            width: 100,
        },
         {
             field: "colname",
             title: "columname",
             width: 100,
             hidden: true
         },
        {
            field: "datatype",
            title: "Datatye",
            width: 100,
            hidden: true
        },
         {
             field: "mstcode",
             title: "Mastercode",
             hidden: true,

             width: 100,
         },
        {
            field: "defcondt",
            title: "Condition",
            template: '#=DropDownEditor(defcondt)#',
            width: 100,
        },

        {
            field: "defval",
            title: "Value",
            width: 100,
            template: '#=templatefields(datatype,mstcode)#',
            //change: btnsearc(data)
        }
        ],



    }).data("kendoGrid");



}



function DropDownEditor(defcondt) {
    var list = '<select id="cmblist_' + grid1_inc + '"  class="form-control"  onchange="setCondition(this)" style="width:60%; height:15px" />';
    list += (defcondt == "=") ? '<option value="=" selected>=</option>' : '<option value="=">=</option>';
    list += (defcondt == "like") ? '<option value="like" selected>like</option>' : '<option value="like">like</option>';
    list += (defcondt == ">") ? '<option value=">" selected>></option>' : '<option value=">">></option>';
    list += (defcondt == "!=") ? '<option value="!=" selected>!=</option>' : '<option value="!=">!=</option>';
    list += '</select>';

    //$("#" + "cmblist_" + grid1_inc).val(defcondt);
    grid1_inc++;
    return list;
}



function templatefields(fld_type, mstcode) {

    if (fld_type == "S") {
        gridRowID++;
        return '<input id="txtString_' + gridRowID + '" type="text" class="form-control pull-left" onchange="setValue(this)" style="width:74%; height:15px">';
    }
    else if (fld_type == "D") {
        gridRowID++;
        return '<input id="txtDate_' + gridRowID + '" type="Date" class="form-control pull-left" onchange="setValue(this)" style="width:74%; height:15px">';
    }
    else if (fld_type == "N") {
        gridRowID++;
        return '<input id="txtInt_' + gridRowID + '" type="number" onchange="setValue(this)" class="form-control pull-left" style="width:74%; height:15px">';
    }
    else if (fld_type == "Q") {
        gridRowID++;
        if (mstcode == "STATUS") {
            var cmblist = JSON.parse(load_mastercodes(mstcode));
        }
        else {
            var cmblist = JSON.parse(load_ScreenIdmastercodes(mstcode));
        }

        var list = '<select id="cmb_' + gridRowID + '"  class="form-control"  onchange="setValue(this)" style="width:74%; height:15px" />';
        list += '<option value=""></option>';
        $.each(cmblist, function (key, value) {
            if (value != null) {
                list += '<option value=' + value.code + '>' + value.description + '</option>';
            }
        });
        list += '</select>';
        return list;
    }
}


function pageload_ScreenIdmaster_code() {
    var data = {};
    data.screen_Id = Screen_Id;
    var tab_values = ajaxcall_param("/Home/screenId_mastercodelist", JSON.stringify(data));
}


function load_ScreenIdmastercodes(mstcode) {
    var data = {};
    data.screen_Id = mstcode;
    var mst_Dt = ajaxcall_param('/Home/getScreenIDcode', JSON.stringify(data));
    return mst_Dt;
}

function load_mastercodes(mstcode) {

    var data = {};
    data.mstcode = mstcode;
    var mst_Dt = ajaxcall_param('/Home/getcode', JSON.stringify(data));
    return mst_Dt;
}

function setCondition(evt) {
    var id_val = $("#" + evt.id).val();
    var str = "";
    var data = $("#gridFilter").data("kendoGrid").dataSource.data();
    var spt = evt.id.split("_");
    var rowId = parseInt(spt[1]);

    data[rowId].defcondt = id_val;

    for (var i = 0; i < data.length; i++) {

        if (data[i].defVal != null && data[i].defVal != "") {
            if (i > 0 && str.length != 0)
                str += " and ";

            if (data[i].datatype == 'Q')
                str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";

            else if (data[i].datatype == 'D') {
                // str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";
                var date_value = data[i].defVal;
                var split_date = date_value.split("-");
                var Splited_Datevalue = split_date[2] + "/" + split_date[1] + "/" + split_date[0];
                str += data[i].coldesc + " " + data[i].defcondt + " '" + Splited_Datevalue + "'";
            }
            else if (data[i].datatype == 'N')
                str += data[i].coldesc + " " + data[i].defcondt + " " + data[i].defVal;

            else if (data[i].datatype == "S") {
                if (data[i].defcondt == 'like')
                    str += data[i].coldesc + " " + data[i].defcondt + " '%" + data[i].defVal + "%'";
                else
                    str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";
            }
        }
    }
    document.getElementById("textserarch").value = str;

}

function setValue(evt) {
    var id_val = $("#" + evt.id).val();
    var str = "";
    var data = $("#gridFilter").data("kendoGrid").dataSource.data();
    var spt = evt.id.split("_");
    var rowId = parseInt(spt[1]);

    data[rowId].defVal = id_val;

    for (var i = 0; i < data.length; i++) {

        if (data[i].defVal != null && data[i].defVal != "") {
            if (i > 0 && str.length != 0)
                str += " and ";

            if (data[i].datatype == 'Q')
                str += data[i].coldesc + " " + data[i].defcondt + " '" + $("#" + "cmb_" + i + " option:selected").text() + "'";
                //str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";

            else if (data[i].datatype == 'D') {
                //str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";
                var date_value = data[i].defVal;
                var split_date = date_value.split("-");
                var Splited_Datevalue = split_date[2] + "/" + split_date[1] + "/" + split_date[0];
                str += data[i].coldesc + " " + data[i].defcondt + " '" + Splited_Datevalue + "'";
            }
            else if (data[i].datatype == 'N')
                str += data[i].coldesc + " " + data[i].defcondt + " " + data[i].defVal;

            else if (data[i].datatype == "S") {
                if (data[i].defcondt == 'like')
                    str += data[i].coldesc + " " + data[i].defcondt + " '%" + data[i].defVal + "%'";
                else
                    str += data[i].coldesc + " " + data[i].defcondt + " '" + data[i].defVal + "'";
            }
        }
    }
    document.getElementById("textserarch").value = str;

}

function onselect_filter() {
    debugger;
    var str = " and ";
    var data = $("#gridFilter").data("kendoGrid").dataSource.data();
    // var spt = evt.id.split("_");
    // var rowId = parseInt(spt[1]);

    // data[rowId].defVal = id_val;

    for (var i = 0; i < data.length; i++) {

        if (data[i].defVal != null && data[i].defVal != "") {

            if (i > 0 && str.length != 0 && str != " and ")
                str += " and ";

            if (data[i].datatype == 'Q')
                // str += data[i].coldesc + " " + data[i].defcondt + " '" + $("#" + "cmb_"+i +" option:selected").text() + "'";
                str += data[i].colname + " " + data[i].defcondt + " '" + data[i].defVal + "'";
            else if (data[i].datatype == 'D') {
                //str += data[i].colname + " " + data[i].defcondt + " '" + data[i].defVal + "'";
                var date_value = data[i].defVal;
                var split_date = date_value.split("-");
                var Splited_Datevalue = split_date[1] + "/" + split_date[2] + "/" + split_date[0];
                str += data[i].colname + " " + data[i].defcondt + " '" + Splited_Datevalue + "'";
            }
            else if (data[i].datatype == 'N')
                str += data[i].colname + " " + data[i].defcondt + " " + data[i].defVal;

            else if (data[i].datatype == "S") {
                if (data[i].defcondt == 'like')
                    str += data[i].colname + " " + data[i].defcondt + " '%" + data[i].defVal + "%'";
                else
                    str += data[i].colname + " " + data[i].defcondt + " '" + data[i].defVal + "'";
            }
        }
    }

    filter_condition = (str != " and ") ? str : " and 1 = 1 ";
    //if (Screen_Id != "TEMPLATES") {
    //    filter_condition = filter_condition.replace(/%/g, "%25");
    //    filter_condition = filter_condition.replace(/'/g, "%27");
    //    filter_condition = filter_condition.replace(/ /g, "%20");
    //}

    var data = {};
    data.fltercond = filter_condition;
    ajaxcall_param('/AdvancedFilter/setFilter_condition', JSON.stringify(data));
    setlocalStorage('flt_condition', filter_condition);
    closeModel();
    if (Screen_Id == "FARMREG" || Screen_Id == "FARMPREF") {
        list_pager_refresh();
    }
    else {
        master_list_page_refresh();
    }
}


function master_list_page_refresh()
{
    
    listpageloadfetch();
}

//$("#btn_select").click(function (evt) {

//var id_val = $("#" + evt.id).val();


//});