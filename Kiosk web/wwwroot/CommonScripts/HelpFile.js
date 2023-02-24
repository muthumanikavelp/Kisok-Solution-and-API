// Javascript log4j root functionality //
var js_filename = "";
js_filename = "HelpFile.js";

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
/*--------Begin Help Input Condition---------------*/

var gridRowID = -1;
var grid_row_inc = 0;
var function_name = "";
var grid_row_select_trans = "";
var global_rowid = "";

function DropDownEditor(defcondt, entflg) {
    try {
        if (entflg == "N") {
            var list = '<select id="cmblist_' + grid_row_inc + '" disabled class="form-control" style="width:50%; height:15px" />';
            list += (defcondt == "equalto") ? '<option value="equalto" selected>equal to</option>' : '<option value="equalto">equal to</option>';
            list += (defcondt == "like") ? '<option value="like" selected>like</option>' : '<option value="like">like</option>';
            list += (defcondt == "greaterthan") ? '<option value="greaterthan" selected>greater than</option>' : '<option value="greaterthan">greater than</option>';
            list += (defcondt == "notequalto") ? '<option value="notequalto" selected>not equal to</option>' : '<option value="notequalto">not equal to</option>';
            list += (defcondt == "notlike") ? '<option value="notlike" selected>not like</option>' : '<option value="notlike">not like</option>';
            list += (defcondt == "lessthan") ? '<option value="lessthan" selected>less than</option>' : '<option value="lessthan">less than</option>';
            list += '</select>';
            grid_row_inc++;
            return list;
        }
        else {
            var list = '<select id="cmblist_' + grid_row_inc + '" class="form-control" style="width:50%; height:15px" />';
            list += (defcondt == "equalto") ? '<option value="equalto" selected>equal to</option>' : '<option value="equalto">equal to</option>';
            list += (defcondt == "like") ? '<option value="like" selected>like</option>' : '<option value="like">like</option>';
            list += (defcondt == "greaterthan") ? '<option value="greaterthan" selected>greater than</option>' : '<option value="greaterthan">greater than</option>';
            list += (defcondt == "notequalto") ? '<option value="notequalto" selected>not equal to</option>' : '<option value="notequalto">not equal to</option>';
            list += (defcondt == "notlike") ? '<option value="notlike" selected>not like</option>' : '<option value="notlike">not like</option>';
            list += (defcondt == "lessthan") ? '<option value="lessthan" selected>less than</option>' : '<option value="lessthan">less than</option>';
            list += '</select>';
            grid_row_inc++;
            return list;
        }
    } catch (err) {
        alert(err);
    }
}

function textbox(defval, entflg) {
    try {
        gridRowID++;
        if (entflg == "N")
            return '<input id="txtInputVal_' + gridRowID + '"  type="text" disabled class="form-control pull-left" style="width:75%; height:15px" value= "' + defval + '">';
        else
            return '<input id="txtInputVal_' + gridRowID + '"  type="text" class="form-control pull-left" style="width:75%; height:15px" value= "' + defval + '">';
    } catch (err) {
        alert(err);
    }
}

$(document).ready(function () {
    $('#HelpModal').on('show.bs.modal', function (e) {
        $("#grid_condition").empty();
        $("#grid_resultset").empty();
        $(this).data('modal', null);
        var help_condition = {};
        help_condition.search_id = searchid;
        $('#Helphdr').text(hdrtitle + ' - Search');

        var data = ajaxcall_url_with_1param("/HelpFilter/datatypelist", JSON.stringify(help_condition));
        if (data != undefined) {
            data = JSON.parse(data);
            var trans_con;
            if (trans_input_data() !== undefined) {
                trans_con = trans_input_data();
            }
            else if (trans_input_data1() !== undefined) {
                trans_con = trans_input_data1();
            }

            $.each(trans_con, function (key, val) {
                if (trans_con[key].trasfer == "Yes") {
                    if (trans_con[key].controlId != "") {
                        $.each(data, function (d_key, d_val) {
                            if (data[d_key].column == trans_con[key].dataCol) {
                                data[d_key].defval = $("#" + trans_con[key].controlId).val();
                                if (data[d_key].defval == undefined)
                                    data[d_key].defval = $("#" + trans_con[key].controlId).data("kendoComboBox").value();
                            }
                        });
                    }
                    else if (trans_con[key].grid_id != "") {
                        $.each(data, function (t_key, d_val) {
                            if (data[t_key].column == trans_con[key].dataCol) {
                                var grid_data = $('#' + trans_con[key].grid_id).data('kendoGrid');
                                var g_data = grid_data.dataItem(grid_data.select());
                                g_data = grid_row_select_trans;
                                if (g_data != null) {
                                    var t_val = g_data[data[t_key].column];
                                    data[t_key].defval = t_val;
                                }
                            }
                        });
                    }
                }
            });

            if (Screen_Id == "MBADVGEN") {
                if (data[0].column == "user_code") {
                    data[0].defval = getlocalStorage('User_Id_Value');
                }
            }
            grid_condition(data);
        }

        $("#grid_condition .k-grid-content").css("height", "103px");

    })

    $('#HelpModal').on('loaded.bs.modal', function (e) {
        $("#grid_condition").empty();
        $("#grid_resultset").empty();
        var help_condition = {};
        help_condition.search_id = searchid;
        $('#Helphdr').text(hdrtitle + ' - Search');
        var data = ajaxcall_url_with_1param("/HelpFilter/datatypelist", JSON.stringify(help_condition));
        if (data != undefined) {
            data = JSON.parse(data);

            var trans_con;
            if (trans_input_data() !== undefined) {
                trans_con = trans_input_data();
            }
            else if (trans_input_data1() !== undefined) {
                trans_con = trans_input_data1();
            }
            $.each(trans_con, function (key, val) {
                if (trans_con[key].trasfer == "Yes") {
                    if (trans_con[key].controlId != "") {
                        $.each(data, function (d_key, d_val) {
                            if (data[d_key].column == trans_con[key].dataCol) {
                                data[d_key].defval = $("#" + trans_con[key].controlId).val();
                                if (data[d_key].defval == undefined)
                                    data[d_key].defval = $("#" + trans_con[key].controlId).data("kendoComboBox").value();
                            }
                        });
                    }
                    else if (trans_con[key].grid_id != "") {
                        $.each(data, function (t_key, d_val) {
                            if (data[t_key].column == trans_con[key].dataCol) {
                                var grid_data = $('#' + trans_con[key].grid_id).data('kendoGrid');
                                var g_data = grid_data.dataItem(grid_data.select());
                                g_data = grid_row_select_trans;
                                if (g_data != null) {
                                    var t_val = g_data[data[t_key].column];
                                    data[t_key].defval = t_val;
                                }
                            }
                        });
                    }
                }
            });

            if (Screen_Id == "MBADVGEN") {
                if (data[0].column == "user_code") {
                    data[0].defval = getlocalStorage('User_Id_Value');
                }
            }
            grid_condition(data);
        }
        $("#grid_condition .k-grid-content").css("height", "103px");
    });
});

function grid_condition(data) {
    try {
        grid_row_inc = 0;
        gridRowID = -1;

        $("#grid_condition").kendoGrid({
            dataSource: {
                data: data
            },
            height: 130,
            width: 400,
            scrollable: true,
            columns: [{
                field: "coldesc",
                title: "Search Condition",
                headerAttributes: {
                    style: "text-align: left;font-size: 15px;font-weight: bold;padding-left:0.286em;padding-top: inherit"
                }
            }, {
                field: "defcondt",
                height: 20,
                headerAttributes: {
                    style: "display: none;height: 0; border-bottom-width: 0; overflow: auto"
                },
                template: '#=DropDownEditor(defcondt,entflg)#'
            }, {
                field: "defval",
                height: 20,
                headerAttributes: {
                    style: "display: none"
                },
                template: '#=textbox(defval,entflg)#'
            }
            ],

        });
    } catch (err) {
        alert(err);
    }
}

function input_search() {
    try {
        var grid = $("#grid_condition").data("kendoGrid");
        var tData = grid.tbody.find("tr");
        var result = [];
        $.each(tData, function (key, value) {
            var row = value.children;
            var tmpKey = {};
            tmpKey.column = grid._data[key].column;
            tmpKey.dataType = grid._data[key].datatype;
            $.each(row, function (key, value) {
                if (value.firstElementChild != null) {
                    var tdata = $("#" + value.firstElementChild.id).val();
                    if (key == 1) {
                        tmpKey.condition = tdata;
                    } else if (key == 2) {
                        tmpKey.value = tdata;
                    }
                }
            });
            result.push(tmpKey);
        });
        return result;
    } catch (err) {
        alert(err);
    }
}

function getGriddata() {

    try {
        var inpucondition = input_search();
        var data = {};
        data.input = JSON.stringify(inpucondition);
        data.search_id = searchid;
        var result = ajaxcall_url_with_1param("/HelpFilter/search", JSON.stringify(data));
        if (result != "")
            grid_resultset(JSON.parse(result));
        else
            $("#grid_resultset").data("kendoGrid").dataSource.data([]);
    } catch (err) {
        alert(err);
    }
}

/*--------End Help Input Condition---------------*/

/*--------Begin Help OutPut Condition---------------*/

$(document).ready(function () {


    $('#HelpModal').on('show.bs.modal', function (e) {
        $(this).data('modal', null);
        var help_condition = {};
        help_condition.search_id = searchid;
        var data = ajaxcall_url_with_1param("/HelpFilter/datatypedetails", JSON.stringify(help_condition));
        if (data != undefined) {
            data = JSON.parse(data);
            grid_resultset(data);
        }
        $("#grid_resultset .k-grid-content").css("height", "150px");
    })



    $('#HelpModal').on('loaded.bs.modal', function (e) {
        var help_condition = {};
        help_condition.search_id = searchid;
        var data = ajaxcall_url_with_1param("/HelpFilter/datatypedetails", JSON.stringify(help_condition));
        if (data != undefined) {
            data = JSON.parse(data);
            grid_resultset(data);
        }
        $("#grid_resultset .k-grid-content").css("height", "150px");
    });
});

function getGridSelectedValue() {
    try {
        var grid = $("#grid_resultset").data("kendoGrid");
        currentSelection = grid.select();
        selectedRows = [];
        currentSelection.each(function () {
            var currentRowIndex = $(this).closest("tr").index();
            if (selectedRows.indexOf(currentRowIndex) == -1) {
                selectedRows.push(currentRowIndex);
            }
        });
    } catch (err) {
        alert(err);
    }
}

function getFields(data) {
    try {
        var fields = {};
        $.each(data[0], function (key, value) {
            if (key.indexOf(" ") > -1) {
                key = removeSpaces(key);
                fields[key] = { type: "string" };
            } else {
                fields[key] = { type: "string" };
            }

        });
        return fields;
    } catch (err) {
        alert(err);
    }
}

function getColumns(data, id) {
    try {
        var columns = [];
        var i = 0;
        $.each(data[0], function (key, value) {
            var col = {};
            var dub_key = removeSpaces(key);
            col.field = dub_key;
            col.title = key;
            if (key == "check_sel" && value == "0") {
                var grid = $(id).data("kendoGrid");
                col.template = '#=sel_checkbox(check_sel)#';
                col.width = "60px";

            }
            else {
                col.width = 150;
            }

            col.headerAttributes = { style: "text-align: left" };
            columns.push(col);
        });
        return columns;
    } catch (err) {
        alert(err);
    }
}

function removeSpaces(sKey) {
    try {
        if (sKey.indexOf(" ") > -1) {
            var spt = sKey.split(" ");
            var sptResult = "";
            $.each(spt, function (key, value) {
                sptResult += value;
            });
            return sptResult;
        } else {
            return sKey;
        }
    } catch (err) {
        alert(err);
    }
}

function formatData(data) {
    try {
        var arr = [];
        $.each(data, function (key, value) {
            var obj = {};
            $.each(value, function (sKey, sValue) {
                sKey = removeSpaces(sKey);
                obj[sKey] = sValue;
            });
            arr.push(obj);
        });
        return arr;
    } catch (err) {
        alert(err);
    }
}

function grid_resultset(data) {
    var fields = getFields(data);
    var columns = getColumns(data, '#grid_resultset');
    data = formatData(data);
    gridRowID = -1;
    //if (getlocalStorage('screen') == "ICDINVOICE")
    //    $("#grid_resultset table").css("width", "500%")
    //if (getlocalStorage('screen') == "ICDCI")
    //    $("#grid_resultset table").css("width", "500%")
    //if (getlocalStorage('screen') == "ICDINWARD")
    //    $("#grid_resultset table").css("width", "500%")
    //$("table").css('width', 'auto');
    //$("#grid_resultset table").css("width", "200%")
    $("#grid_resultset").kendoGrid({
        dataSource: {
            data: data,
            schema: {
                model: {
                    fields: fields
                }
            },
            pageSize: 10000000
        },
        height: 180,
        // width: 400,
        scrollable: true,
        dataBound: function () {
            $(".checkbox").bind("change", function (e) {
                $(e.target).closest("tr").toggleClass("k-state-selected");

            });
        },
        selectable: "single",
        // change:onChange,
        pageable: {
            pageSizes: true,
            buttonCount: 20
        },
        headerAttributes: {
            style: "text-align:left;font-size: 15px; font-weight: bold;padding-left:0.286em;padding-top: inherit"
        },
        resizable: true,
        columns: columns
    });
}

function sel_checkbox(check_sel) {
    gridRowID++;
    if (check_sel == "0")
        return '<input id="chk_sel_' + gridRowID + '" class="checkbox" type="checkbox" />';
    else
        return '';
}

/*--------End Help OutPut Condition---------------*/

function closeModal() {
    $('#HelpModal').modal("hide");
}

function clearGrid() {
    $("#grid_resultset").data("kendoGrid").dataSource.data([]);
    var helpval = $("#txtInputVal_0").val();
    $("#txtInputVal_1").val("");
    $("#txtInputVal_2").val("");
    $("#txtInputVal_3").val("");
}

/*-------Trasnfer Selected Data from Popup Grid to Main Form-----------*/

function single_row_select() {
    try {
        var grid = $("#grid_resultset").data("kendoGrid");


        grid.select().each(function () {
            var dataItem = grid.dataItem($(this).closest("tr"));

            var data = {};
            data.row_val = JSON.stringify(dataItem);
            var result = ajaxcall_url_with_1param("/HelpFilter/onSelection", JSON.stringify(data));
            if (result != undefined) {
                var rowvalue = JSON.parse(result);
                var gridValues = getlocalStorage("parentGrid");
                var parentGridData = getlocalStorage("parentGridData");
                var resultData = [];
                var textboxids = getlocalStorage("textbox_id");

                if (textboxids != null) {
                    $.each(textboxids, function (key, id) {
                        $.each(rowvalue, function (skey, value) {
                            if (id.dataCol == skey) {
                                switch (id.type) {
                                    case "Text":
                                    case "Textarea":
                                        $("#" + id.controlId).val(value);
                                        break;
                                    case "Combobox":
                                        $("#" + id.controlId).data('kendoComboBox').value(value);
                                        break;
                                    case "radio":
                                        $("#" + 'input[name="' + id.controlId + '"][value="' + value + '"]').prop(checked, true);
                                        break;
                                    case "checkbox":
                                        if (value == "1") {
                                            $("#" + id.controlId).attr('checked', true);
                                            $("#" + id.controlId).attr('value', value);
                                        }
                                        else {
                                            $("#" + id.controlId).attr('checked', false);
                                            $("#" + id.controlId).attr('value', 2);
                                        }
                                        break;
                                }
                            }
                            return;
                        });
                    });
                    textboxids = "";
                    $('#HelpModal').modal("hide");
                }
                else if (gridValues != null) {
                    var setGrid = [];
                    var obj = {};
                    $.each(gridValues, function (key, id) {
                        $.each(rowvalue, function (skey, value) {
                            if (id.dataCol == skey) {
                                obj[id.grid_row_col] = value;
                            }
                            obj["mode_flag"] = "I";
                            if (searchid == "S09")
                                obj["mode_uniflo"] = "False";
                            if (searchid == "S10") {
                                obj["mode_comp"] = "False";
                                obj["mode_uniflo"] = "False";
                            }
                            return;
                        });
                    });



                    $.each(parentGridData, function (pKey, pVal) {
                        var p_grd_data = parentGridData[pKey];
                        // if (p_grd_data.mode_flag == "I" || p_grd_data.mode_flag == "E" || p_grd_data.mode_flag == "R") //|| p_grd_data.mode_flag == "R" || p_grd_data.mode_flag == "T"
                        // if (p_grd_data.mode_flag!="")
                        // {
                        if ($.isEmptyObject(obj) == false) {
                            $.each(p_grd_data, function (fkey, fval) {
                                $.each(obj, function (okey, oval) {
                                    if (fkey == okey) {
                                        //if (fkey == "mode_flag") {
                                        //if (pKey != 0 && p_grd_data.mode_flag == "I")
                                        //    parentGridData[pKey][okey] = "R";
                                        //else if (p_grd_data.mode_flag == "E")
                                        //    parentGridData[pKey][okey] = "U";
                                        //else
                                        //    parentGridData[pKey][okey] = "T";
                                        // }
                                        // else {
                                        //if (pKey != 0) {
                                        //    if (parentGridData[pKey].mode_flag == "I" )//|| parentGridData[pKey].mode_flag == "R"
                                        //    {
                                        //        if (parentGridData[pKey].uid == global_rowid) {
                                        //            parentGridData[pKey][okey] = fval;
                                        //        }
                                        //        //parentGridData[pKey][okey] = fval;
                                        //        //parentGridData[pKey][okey] = oval;
                                        //        //parentGridData[pKey].mode_flag = "U";
                                        //    }
                                        //    else {

                                        //        if (parentGridData[pKey].uid == global_rowid)
                                        //        {
                                        //            parentGridData[pKey][okey] = oval;
                                        //        }                                                   
                                        //    }
                                        //}
                                        //else {
                                        //    if (parentGridData[pKey].uid == global_rowid) {
                                        //        parentGridData[pKey][okey] = oval;
                                        //    }
                                        //}

                                        if (parentGridData[pKey].uid == global_rowid) {
                                            parentGridData[pKey][okey] = oval;
                                        }
                                        // }
                                    }
                                });
                            });
                        }
                        // }
                        //else if (p_grd_data.mode_flag == undefined) {
                        //   if ($.isEmptyObject(obj) == false) {
                        //       setGrid.push(obj);
                        //      parentGridData = setGrid[pKey];
                        //   }
                        // }
                    })




                    resultData = parentGridData;
                    // gridValues = "";
                    $('#HelpModal').modal("hide");
                    eval(function_name + '(resultData);');
                    //var rows = $('#Machine_Grid').data('kendoGrid').tbody.children();
                    //setColor(rows, resultData);
                }
            }
        });

    } catch (err) {
        alert(err);
    }
}

//function Transferdata() {
//    try {
//        var grid = $("#grid_resultset").data("kendoGrid");
//        var data = {};
//        var selectedvalue = [];
//        if (grid.tbody.find("input:checked").length > 0) {
//            grid.tbody.find("input:checked").closest("tr").each(function (index) {
//                var dataItem = grid.dataItem($(this).closest("tr"));
//                selectedvalue.push(dataItem);
//            });
//            data.row_val = JSON.stringify(selectedvalue);
//            var result = ajaxcall_url_with_1param("/HelpFilter/onSelection", JSON.stringify(data));

//            var rowvalue = JSON.parse(result);
//            var gridValues = getlocalStorage("parentGrid");

//            var parentGridData = getlocalStorage("parentGridData");
//            var resultData = [];

//            var setGrid = [];
//            var final_data = "";
//            var popGridval = [];

//            $.each(rowvalue, function (key, value) {
//                var obj = {};
//                $.each(gridValues, function (skey, id) {
//                    if (value[id.dataCol] != undefined) {
//                        obj[id.grid_row_col] = value[id.dataCol];
//                        obj["mode_flag"] = "I";
//                    }
//                });
//                popGridval.push(obj);
//            });

//            var p_grnd = popGridval;

//            $.each(parentGridData, function (mKey, mVal) {
//                var mod_flg = parentGridData[mKey];
//                if (mod_flg != undefined) {
//                    if (mod_flg.mode_flag == "E") {
//                        delete parentGridData[mKey];
//                        parentGridData = startFromZero(parentGridData);
//                        parentGridData.push(p_grnd[0]);
//                    }
//                }
//            });

//            $.each(parentGridData, function (pKey, pVal) {
//                if (parentGridData.length == 1) {
//                    if (pKey != 0) {
//                        p_grnd.push(parentGridData[pKey]);
//                    }
//                }
//                else {
//                    if (pKey == 0)
//                        delete p_grnd[pKey];
//                    p_grnd = startFromZero(p_grnd);
//                    p_grnd.push(parentGridData[pKey]);
//                }
//            });

//            parentGridData = p_grnd;

//            gridValues = "";
//            //resultData = parentGridData.concat(setGrid);
//            resultData = parentGridData;

//            $('#HelpModal').modal("hide");
//            eval(function_name + '(resultData);');
//            var child_del = $('.k-grid-Delete').children('span:first');
//            $('.k-grid-Delete').html(child_del);

//            var child_copy = $('.k-grid-Copy').children('span:first');
//            $('.k-grid-Copy').html(child_copy);
//            return;
//        }
//        else {
//            var chkid = $("#grid_resultset .k-state-selected").children().children().attr("id");
//            if (chkid == undefined) {
//                single_row_select();
//            }
//        }
//    } catch (err) {
//        alert(err);
//    }
//}



function Transferdata() {
    debugger;
    try {
        var grid = $("#grid_resultset").data("kendoGrid");
        var selectedItem = grid.dataItem(grid.select());
        if (selectedItem != null) {
            var data = {};
            var selectedvalue = [];
            if (grid.tbody.find("input:checked").length > 0) {
                grid.tbody.find("input:checked").closest("tr").each(function (index) {
                    var dataItem = grid.dataItem($(this).closest("tr"));
                    selectedvalue.push(dataItem);
                });
                data.row_val = JSON.stringify(selectedvalue);
                var result = ajaxcall_url_with_1param("/HelpFilter/onSelection", JSON.stringify(data));

                var rowvalue = JSON.parse(result);
                var gridValues = getlocalStorage("parentGrid");

                var parentGridData = getlocalStorage("parentGridData");
                var resultData = [];

                var setGrid = [];
                var final_data = "";
                var popGridval = [];



                $.each(rowvalue, function (key, value) {
                    var obj = {};
                    $.each(gridValues, function (skey, id) {
                        if (value[id.dataCol] != undefined) {
                            obj[id.grid_row_col] = value[id.dataCol];
                            obj["mode_flag"] = "I";
                        }
                    });
                    popGridval.push(obj);
                });

                var p_grnd = popGridval;

                $.each(parentGridData, function (mKey, mVal) {
                    var mod_flg = parentGridData[mKey];
                    if (mod_flg != undefined) {
                        if (mod_flg.mode_flag == "E") {
                            delete parentGridData[mKey];
                            parentGridData.push(p_grnd[0]);
                            parentGridData = startFromZero(parentGridData);
                        }
                    }
                });

                $.each(parentGridData, function (pKey, pVal) {
                    if (parentGridData.length == 1) {
                        if (pKey != 0) {
                            p_grnd.push(parentGridData[pKey]);
                        }
                    }
                    else {
                        if (pKey == 0)
                            delete p_grnd[pKey];
                        p_grnd = startFromZero(p_grnd);
                        p_grnd.push(parentGridData[pKey]);
                    }
                });

                parentGridData = p_grnd;

                gridValues = "";
                //resultData = parentGridData.concat(setGrid);
                resultData = parentGridData;

                $('#HelpModal').modal("hide");
                eval(function_name + '(resultData);');
                var child_del = $('.k-grid-Delete').children('span:first');
                $('.k-grid-Delete').html(child_del);

                var child_copy = $('.k-grid-Copy').children('span:first');
                $('.k-grid-Copy').html(child_copy);
                return;
            }
            else {
                var chkid = $("#grid_resultset .k-state-selected").children().children().attr("id");
                if (chkid == undefined) {
                    single_row_select();
                }
            }
        }
        else {
            kendoAlert("Please Select the Row For Transfer the Data");
        }
    } catch (err) {
        alert(err);
    }
}

function startFromZero(arr) {
    try {
        var newArr = [];
        var count = 0;
        for (var i in arr) {
            newArr[count++] = arr[i];
        }
        return newArr;
    } catch (err) {
        alert(err);
    }
}

function onChange(e) {
    try {
        var chkid = $("#grid_resultset .k-state-selected").children().children().attr("id");
        if (chkid != undefined) {
            chkid = "#" + chkid;
            if ($(chkid).is(':checked')) {
                $(chkid).prop('checked', false);
            }
            else {
                $(chkid).prop('checked', true);
            }
        }
    } catch (err) {
        alert(err);
    }
}

function singleSelect() {
    try {
        var grid = $("#grid_resultset").data("kendoGrid");
        var checked = [];
        var dataItems = [];
        for (var i in checkedIds) {
            if (checkedIds[i]) {
                checked.push(i);
                dataItems.push(grid.dataItem("tr:eq(" + i + ")"));
            }
        }
    } catch (err) {
        alert(err);
    }
}

/* Trasfer data from popup window to main form */

function transfer(event, type, grid_id, fun_name) {
    //if (grid_id == "S27")
    //{

    try {

        removelocalStorage("textbox_id");
        removelocalStorage("parentGridData");
        removelocalStorage("parentGrid");

        function_name = fun_name;

        hdrtitle = $(event).attr('hdrtitle');
        searchid = $(event).attr('searchid');
        if (type == "grid") {

            var gridDataArray = $('#' + grid_id).data('kendoGrid');

            var edt_rw_data = gridDataArray.dataItem(gridDataArray.select());
            grid_row_select_trans = edt_rw_data;// row selection

            if (edt_rw_data == null) {
                var datas = gridDataArray.dataSource;
                datas._data[0].mode_flag = "E";
                global_rowid = datas._data[0].uid;

            }
                //else if (edt_rw_data.mode_flag == "I" || edt_rw_data.mode_flag == "U" || edt_rw_data.mode_flag == "T") {
            else {
                edt_rw_data.mode_flag = "E";
                global_rowid = edt_rw_data.uid;
                //  gridDataArray.dataSource.remove(edt_rw_data);
                // gridDataArray.dataSource.add(edt_rw_data);
            }

            var columnDataVector = [];

            if (grid_control() != undefined) {
                columnDataVector = grid_control();
            }
            //else if (grid_control1() != undefined) {
            //    columnDataVector = grid_control1();
            //}

            var gridval = [];
            var gridData = gridDataArray.dataSource.data();
            $.each(gridData, function (key, value) {
                var obj = {};
                $.each(columnDataVector, function (skey, sval) {
                    if (sval.grid_row_col != null) {
                        obj[sval.grid_row_col] = value[sval.grid_row_col];
                    }
                });
                var firstvalue = obj[Object.keys(obj)[0]];
                gridval.push(obj);
            });
            setlocalStorage("parentGridData", gridval);
            setlocalStorage("parentGrid", columnDataVector);
        }
        else {
            if (function_name == "form_control1") {
                var form_ctrl_datacol = form_control1();
                setlocalStorage("textbox_id", form_ctrl_datacol);
            }
            else {
                var form_ctrl_datacol = form_control();
                setlocalStorage("textbox_id", form_ctrl_datacol);

            }

        }

    } catch (err) {
        alert(err);
    }
}