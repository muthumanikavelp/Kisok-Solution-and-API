

// Javascript log4j root functionality //
var js_filename = "";
js_filename = "ChangePassword.js";

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

/// <reference path="ChangePassword.js" />

$(document).ready(function () {
    load_master_code();
    $('#ChangePasswordModal').on('show.bs.modal', function (e) {
        $(this).data('modal', null)
        pageload();
    })
    $('#ChangePasswordModal').on('loaded.bs.modal', function (e) {
       pageload();

    });
    
    $("#ChangePasswordModal").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
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
    var tab_values = ajaxcall_param("/Home/screenId_mastercodelist", JSON.stringify(data));
}

function refresh() {
    captcha();
}

function pageload () {
    captcha();
    $("#txtUserId").val(getlocalStorage("User_Id_Value"));
    $("#txtUserIdCaptcha").val(getlocalStorage("User_Id_Value"));

    var sQuestion = grid_comboScreen_mastercodes("QCD_SEC_QUES");
    filter_combobox("cmb_question", sQuestion);

  
}

function ValidCaptcha_next() {
    var str1 = removeSpaces($("#txtCaptcha1").val());
    var str2 = removeSpaces($("#txtReCaptcha1").val());
    if (str1 == str2)
        return true;
    else
        return false;
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
    $("#txtCaptcha1").val(code);
}

function ValidCaptcha() {
    var str1 = removeSpaces($("#txtCaptcha").val());
    var str2 = removeSpaces($("#txtReCaptcha").val());
    if (str2 != "") {
        if (str1 == str2) {
            return true;
        }
        else {
            kendoAlert("captcha mismatch");
        }
    }
}

function ValidCaptcha_next() {
    var str1 = removeSpaces($("#txtCaptcha1").val());
    var str2 = removeSpaces($("#txtReCaptcha2").val());
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
function removeSpaces(string) {
    return string.split(' ').join('');
}

function password_check()
{
    if ($("#txtNewPassword").val() == $("#txtConPassword").val()) {
        return true;
    }
    else
    {
        kendoAlert("password mismatch");
        return false;
    }

}

function RestrictSpace() {
    if (event.keyCode == 32) {
        event.returnValue = false;
        return false;
    }
}


function save_password()
{
    Form_validate_Name = "frmChangePassword";
    var container = $("#frmChangePassword");
    kendo.init(container);
    master_save();
    Form_validate_Name = "";
}


function save_security() {
    Form_validate_Name = "frmchangePassword1";
    var container = $("#frmchangePassword1");
    kendo.init(container);
    master_save();
    Form_validate_Name = "";
}


function save() {
    if (Form_validate_Name == "frmChangePassword") {       
        var valPassword = password_check();
        if (valPassword == true) {
            var valCaptcha = ValidCaptcha();
        }
        if (valPassword == true && valCaptcha == true) {
            var textb = $("#txtNewPassword").val();
            if (textb.trim() == "") {
                kendoAlert('Password cannot be blank');
                return false;
            }
            $("#txtUserId").removeAttr("disabled");
            var formval = form_Serialize("frmChangePassword");
            var obj_val = JSON.parse(formval);
            var data = {};
            data.context =getContext();
            data.context.Header = obj_val;
            save_user(data);
           // location.href = "../Login/Login";
        }
        return false;
    }
    else if (Form_validate_Name == "frmchangePassword1")
    {        
        var validate = ValidCaptcha_next();
        if (validate == true) {
            $("#txtUserIdCaptcha").removeAttr("disabled");
            //  var formval = $("#frmPassword1").serialize();
            var formval = form_Serialize("frmchangePassword1");
            var obj_val1 = JSON.parse(formval);
            //obj_val1 = cmb_question.val("what is your first mobile number?")
            //$("#txtUserIdCaptcha").prop("disabled", true);
            obj_val1.mode_flag = 'F';
            var data = {};
            data.context = getContext();
            data.context.Header = obj_val1;
            change_security(data);
        }
        return false;
    }
   
}

function save_user(HeaderrequestObject) {
    UserRole_userrole_detail_changepassword.invoke(HeaderrequestObject, save_API_ResponseHandler)
}

function save_API_ResponseHandler(data, textStatus) {
    if (textStatus == "success") {
        //responseJSON = jQuery.parseJSON(data);
        responseJSON = data;
        if (responseJSON.ApplicationException != null) {
            //Response contains error
            var errorNumber = "", errorDescription = "";
            var exception = responseJSON.ApplicationException;
            errorDescription = exception.errorDescription;
            if (exception.errorNumber != null)
                errorNumber = exception.errorNumber;
            if (errorNumber != "")
                errorNumber += ": ";
            kendoAlert(errorNumber + errorDescription);
            return false;
        }
        else {
            try {
                bind_saveAPI_Response(responseJSON);              
                return true;
            }
            catch (e) {
                kendoAlert(e.message);
                return false;
            }
        }
    }
    else {
        kendoAlert('Error encountered during API execution. ' + data);
    }
}

function bind_saveAPI_Response(responseJSON) {
    kendoAlert("saved successfully");

}

function change_security(HeaderrequestObject) {
    UserRole_userrole_detail_changesecanswer.invoke(HeaderrequestObject, save_API_ResponseHandler)
}

function save_API_ResponseHandler(data, textStatus) {
    if (textStatus == "success") {
        //responseJSON = jQuery.parseJSON(data);
        responseJSON = data;
        if (responseJSON.ApplicationException != null) {
            //Response contains error
            var errorNumber = "", errorDescription = "";
            var exception = responseJSON.ApplicationException;
            errorDescription = exception.errorDescription;
            if (exception.errorNumber != null)
                errorNumber = exception.errorNumber;
            if (errorNumber != "")
                errorNumber += ": ";
            kendoAlert(errorNumber + errorDescription);
            return false;
        }
        else {
            try {
                bind_changeAPI_Response(responseJSON);
                return true;
            }
            catch (e) {
                kendoAlert(e.message);
                return false;
            }
        }
    }
    else {
        kendoAlert('Error encountered during API execution. ' + data);
    }
}

function bind_changeAPI_Response(responseJSON) {
    kendoAlert("changed successfully");

}




