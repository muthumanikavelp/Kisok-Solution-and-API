// Javascript log4j root functionality //
var js_filename = "";
js_filename = "forgotPassword.js";

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

var Sec_question = sessionStorage.getItem('Sec_question');
var profile_userID = sessionStorage.getItem('User_name');
//var forgetpsw = sessionStorage.getItem('forgetpsw');


var msg_success = "";

function close1() {
    location.href = "../Login/Login";
}

function refresh() {
    captcha();
}

var mode = "";
$(function () {
    // Form_validate_Name = $('form.form-horizontal').attr('id');

    var combo_data = [{ code: "PET_NAME", desc: "what is your pet name?" },
    { code: "WELL_WISH", desc: "Who is your well-wisher?" }];
    filter_combobox("cmb_question", combo_data);
    captcha();
    $("#txtUserId").val(profile_userID);

    $("#cmb_question").data("kendoComboBox").value(Sec_question);
    var cmbQuestion = $('#cmb_question').data("kendoComboBox");
    cmbQuestion.enable(false);
    //$("#cmb_question").val(Sec_question);
    $("#seq_mode").val(Sec_question);
    sessionStorage.setItem('UserID', $("#txtUserId").val());
    if (Sec_question == "") {
        var cmbQuestion = $('#cmb_question').data("kendoComboBox");
        cmbQuestion.enable();
        $("#lblPass").text("Change Password");
        mode = "C";
    }
    else {
        mode = "F";
    }
    $("#txtcnfrmPassword").bind("change", function () {
        password_check();
    });

    $("#txtCaptchaAnswer").bind("change", function () {
        ValidCaptcha();
    });
});


function load_master_code() {
    debugger;
    var data = {};
    var context = getContext();
    data.userId = context.userId
    data.orgnId = context.orgnId
    data.locnId = context.locnId
    data.localeId = context.localeId
    data.screen_Id = "CHANGE_PWD";
    var tab_values = ajaxcall_param_login("/ForgotPassword/screenId_mastercodelist", JSON.stringify(data));
}



function grid_combo_pass_mastercodes(mstcode) {
    var data = {};
    var list = [];
    data.mstcode = mstcode;
    // var parent_code = ajaxcall1('/ForgotPassword/sceeenId_mastercodelist');
    var mst_Dt = ajaxcall_param_login('/ForgotPassword/getScreenIDcode', JSON.stringify(data));
    if (mst_Dt.toString() == "null" || mst_Dt == "[]") {
        //var parent_code = ajaxcall1('/ForgotPassword/sceeenId_mastercodelist');
        mst_Dt = ajaxcall_param_login('/ForgotPassword/getScreenIDcode', JSON.stringify(data));
    }
    if (mst_Dt.toString() != "null" && mst_Dt != "[]")
        list = getGridComboList1(JSON.parse(mst_Dt));//changed as getComboList
    return list;
}


function getGridComboList1(mst_Dt) {
    var arr = [];
    $.each(mst_Dt, function (key, value) {
        var list = {};
        if (value != null) {
            list.code = value.code;
            list.desc = value.description;
            list.status = value.code_status;
            list.dependent = value.dependent_code;
        }
        arr.push(list);
    });
    return arr;
}


function load_combo_mastercodes(mstcode) {
    var Get_mstDt = get_Mstlist(mstcode);
    var list = getComboList(JSON.parse(Get_mstDt));
    return list;

}

function get_Mstlist(mstcode) {
    var data = {};
    data.mstcode = mstcode;
    var mst_Dt = ajaxcall_param('/ForgotPassword/getcode', JSON.stringify(data));
    return mst_Dt;
}

function getComboList(mst_Dt) {
    var list = "";
    list += "<option></option>";
    $.each(mst_Dt, function (key, value) {
        if (value != null) {
            var colorCode = getComboColorCode(value.code_status);
            list += '<option value=' + value.code + ' class=' + colorCode + '>' + value.description + '</option>';
        }
    });
    return list;
}

function getComboColorCode(status) {
    if (status == "Inactive") {
        return "color_Red";
    }
    else {
        return "color_Default"
    }
}

function captcha() {
    var a = Math.ceil(Math.random() * 9) + ' ';
    var b = Math.ceil(Math.random() * 9) + ' ';
    var c = Math.ceil(Math.random() * 9) + ' ';
    var d = Math.ceil(Math.random() * 9) + ' ';
    var e = Math.ceil(Math.random() * 9) + ' ';
    var f = Math.ceil(Math.random() * 9) + ' ';
    var g = Math.ceil(Math.random() * 9) + ' ';
    var code = a + b + c + d + e + f + g;
    $("#txtCaptcha").val(code);
}




function removeSpaces(string) {
    return string.split(' ').join('');
}

function savedraft() {
    debugger;
    var mandatory_check = true;
    if ($("#txtAnswer").val() == "" && $("#txtnewPassword").val() == "" && $("#txtcnfrmPassword").val() == "") {
        kendoAlert("Enter Answer and New Password and Confirm Password");
        mandatory_check = false;
    } else {
        if ($("#txtAnswer").val() == "" && $("#txtnewPassword").val() == "" && $("#txtcnfrmPassword").val() == "") {
            kendoAlert("Enter Answer and New Password and Confirm Password");
            mandatory_check = false;
        } else {
            if ($("#txtAnswer").val() == "" || $("#txtAnswer").val() == undefined) {
                kendoAlert("Enter Answer");
                mandatory_check = false;
            }
            if ($("#txtnewPassword").val() == "" || $("#txtnewPassword").val() == undefined) {
                kendoAlert("Enter New Password");
                mandatory_check = false;
            }
            if ($("#txtcnfrmPassword").val() == "" || $("#txtcnfrmPassword").val() == undefined) {
                kendoAlert("Enter Confirm Password");
                mandatory_check = false;
            }
        }
    }
    if (mandatory_check == true) {
        var valPassword = password_check();
        if (valPassword == true) {
            var valCaptcha = ValidCaptcha();
        }
        if (valPassword == true && valCaptcha == true) {
            var textb = $("#txtnewPassword").val();
            if (textb.trim() == "") {
                kendoAlert('Password cannot be blank');
                return false;
            }
            $("#txtUserId").removeAttr("disabled");
            var cmbQuestion = $('#cmb_question').data("kendoComboBox");
            cmbQuestion.enable();
            $("#cmb_question").removeAttr("disabled");
            var context = {
                orgnId: "", //Unicode string
                locnId: "", //Unicode string
                userId: "", //Unicode string
                localeId: "",//Unicode string
            };
            var formval = form_Serialize("forgotPassword_form");
            var obj_val = JSON.parse(formval);
            obj_val.mode_flag = mode;
            var data = {};            
            data.context = context;           
            data.context.Header = obj_val;
            var Context = data.context;
            $.ajax({
                type: "POST",
                data: JSON.stringify({ userId: Context.Header.user_code, orgnId: Context.orgnId, locnId: Context.locnId, localeId: Context.localeId, Header: Context.Header }),
                url: "/ForgotPassword/SaveForgotPassword",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    console.log(response)
                    var Res = JSON.parse(response);
                    if (Res.out_result == "") {
                        kendoAlert("Saved Succedfully");
                    }
                    else {
                        kendoAlert(Res.out_result);
                    }
                },
                error: function (er) {
                    alert(er)
                    console.log(er)
                }

            });
            $("#txtUserId").prop("disabled", true);
            $("#cmb_question").prop("disabled", true);
            var cmbQuestion = $('#cmb_question').data("kendoComboBox");
            cmbQuestion.enable(false);
        }
        return false;
    }
}

function password_check() {
    if ($("#txtnewPassword").val() == $("#txtcnfrmPassword").val()) {
        return true;
    }
    else {
        kendoAlert("password mismatch");
        return false;
    }
}

function validation_for() {

}

function ValidCaptcha() {
    var str1 = removeSpaces($("#txtCaptcha").val());
    var str2 = removeSpaces($("#txtCaptchaAnswer").val());
    if (str2 != "") {
        if (str1 == str2) {
            return true;
        }
        else {
            kendoAlert("captcha mismatch");
            return false;
        }
    }
}

