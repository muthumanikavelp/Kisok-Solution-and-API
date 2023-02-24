
// Javascript log4j root functionality //
var js_filename = "";
js_filename = "AjaxScript.js";

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
/* Without parammeter function*/
function ajaxcall(url) {
    //set_context();
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    // timeinterval_reset();
    // webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}

function ajaxcall1(url) {
    //set_context();
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    // timeinterval_reset();
    // webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}

/* With parammeter function*/
function ajaxcall_url_with_1param(url, paramValue) {
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    //  webconfig_settings();
    return result.responseText;
}

function ajaxcall_param(url, paramValue) {
  
    //set_context();       ///As per code review we dont want this code
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    //timeinterval_reset();
    //webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}

function ajaxcall_param_login(url, paramValue) {
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    //timeinterval_reset();
    //webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}

function ajaxcall_param_login1(url, paramValue) {
    var result = $.ajax({
        url: url,
        type: 'get',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    //timeinterval_reset();
    //webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}1

function set_context() {
  
    var data = {};
    data.user_Id = getlocalStorage("User_Id_Value");
    data.orgn_Id = getlocalStorage("org_code");
    var set_data = ajax_set_context('/Login/Set_context', JSON.stringify(data));
}




function ajax_set_context(url, paramValue) {
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    // timeinterval_reset();
    // webSession_Exit();
    // webconfig_settings();
    return result.responseText;
}

function ajaxcall_param_new(url, paramValue) {
    //set_context();
    var send = {};
    send.receiveData = JSON.stringify(paramValue);
    var result = $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(send),
        contentType: 'application/json; charset=utf-8',
        async: false
    });
    return result.responseText;
}

function showAlert(msg) {
    var len = $(".modelAlertId").length;
    if (len > 0) {
        $(".modelAlertId").remove();
    }
    $("body").append('<div class="modal modelAlertId" data-backdrop="static"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4 class="modal-title"><center>Alert</center></h4></div><div class="modal-body"><center>' + msg + '</center></div><div class="modal-footer"><button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button><button type="button" class="btn btn-outline">Save changes</button></div></div></div></div>');

    $(".modelAlertId").modal("show");
    msg = "";
}


function form_Serialize(id) {
    var sArray = $("#" + id).serializeArray();
    var sObj = {};
    $.each(sArray, function (key, value) {
        sObj[value.name] = value.value;
    });
    return JSON.stringify(sObj);
}