// Javascript log4j root functionality //
var js_filename = "";
js_filename = "ValidationScript.js";

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
//$(document).ready(function () {
//    $(".mask_datetime").inputmask("datetime", { "placeholder": "dd/mm/yyyy hh:mm" });
//    $(".mask_date").inputmask("date", { "placeholder": "dd/mm/yyyy" });
//    $("#numbers").inputmask("currency");
//});


//function validatedate(id) {
//    inputText = document.getElementById(id);
//    var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
//     Match the date format through regular expression  
//    if (inputText.value != "") {
//        if (inputText.value.match(dateformat)) {
//             document.form1.text1.focus();
//            Test which seperator is used '/' or '-'  
//            var opera1 = inputText.value.split('/');
//            var opera2 = inputText.value.split('-');
//            lopera1 = opera1.length;
//            lopera2 = opera2.length;
//             Extract the string into month, date and year  
//            if (lopera1 > 1) {
//                var pdate = inputText.value.split('/');
//            }
//            else if (lopera2 > 1) {
//                var pdate = inputText.value.split('-');
//            }
//            var dd = parseInt(pdate[0]);
//            var mm = parseInt(pdate[1]);
//            var yy = parseInt(pdate[2]);
//             Create list of days of a month [assume there is no leap year by default]  
//            var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
//            if (mm == 1 || mm > 2) {
//                if (dd > ListofDays[mm - 1]) {
//                    kendoAlert('Invalid date format!');
//                    return false;
//                    inputText.value = "";
//                }
//            }
//            if (mm == 2) {
//                var lyear = false;
//                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
//                    lyear = true;
//                }
//                if ((lyear == false) && (dd >= 29)) {
//                    kendoAlert('Invalid date format!');
//                    return false;
//                    inputText.value = "";
//                }
//                if ((lyear == true) && (dd > 29)) {
//                    kendoAlert('Invalid date format!');
//                    return false;
//                    inputText.value = "";
//                }
//            }
//        }
//        else {
//            kendoAlert("Invalid date format!");
//             document.form1.text1.focus();

//            return false;
//            inputText.value = "";
//        }
//    }
//    else {
//        kendoAlert("date cannot be blank!");
//    }
//}


$(function () {

    setprofilePicture();
});
function setprofilePicture() {
    
    var data = {};
    if (getlocalStorage("User_Id_Value") != undefined) {
        data.userId = getlocalStorage("User_Id_Value");//sessionStorage.getItem('User_Id_Value');
        data.Dbtype = getlocalStorage("Db_type");
        profile = ajaxcall_param('/Login/LoadProfile', JSON.stringify(data));

        if (profile != "") {
            document.getElementById('profileImg').setAttribute('src', 'data:image/png;base64,' + profile);
            document.getElementById('profileImg1').setAttribute('src', 'data:image/png;base64,' + profile);
        }
        else {
            document.getElementById("profileImg").src = "/images/noimage.png";
            document.getElementById("profileImg1").src = "/images/noimage.png";
        }
    }

}
function validatedate(inputText) {
    var dateformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    // Match the date format through regular expression
    if (inputText.match(dateformat)) {
        //Test which seperator is used '/' or '-'
        var opera1 = inputText.split('/');
        var opera2 = inputText.split('-');
        lopera1 = opera1.length;
        lopera2 = opera2.length;
        // Extract the string into month, date and year
        if (lopera1 > 1) {
            var pdate = inputText.split('/');
        }
        else if (lopera2 > 1) {
            var pdate = inputText.split('-');
        }
        var dd = parseInt(pdate[0]);
        var mm = parseInt(pdate[1]);
        var yy = parseInt(pdate[2]);
        // Create list of days of a month [assume there is no leap year by default]
        var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        if (mm == 1 || mm > 2) {
            if (dd > ListofDays[mm - 1]) {
                // kendoAlert('Invalid date format!');
                return false;
            }
        }
        if (mm == 2) {
            var lyear = false;
            if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                lyear = true;
            }
            if ((lyear == false) && (dd >= 29)) {
                return false;
            }
            if ((lyear == true) && (dd > 29)) {
                return false;
            }
        }
    }
    else {
        return false;
    }
    return true;
}



function isDate(currVal)
{
    if (currVal == "") {
        return true;
    }
   // var stringToValidate = "9-2-0012";
    var rgexp = /(^(((0[1-9]|1[0-9]|2[0-8])[/](0[1-9]|1[012]))|((29|30|31)[/](0[13578]|1[02]))|((29|30)[/](0[4,6,9]|11)))[/](19|[2-9][0-9])\d\d$)|(^29[/]02[/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)/;
    var isValidDate = rgexp.test(currVal);
    return isValidDate;
}



function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
        return false;

    return true;
}


$(document).ready(function() {         
    //attach keypress to input
    $('.number').keydown(function (event) {
        // Allow special chars + arrows 
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 
            || event.keyCode == 27 || event.keyCode == 13 
            || (event.keyCode == 65 && event.ctrlKey === true) 
            || (event.keyCode >= 35 && event.keyCode <= 39)){
            return;
        }else {
            // If it's not a number stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105 )) {
                event.preventDefault(); 
            }   
        }
    });
            
});



var oneDotAllowed = 0;
function isValidRupeeFormat(id, event, digit, enableMinus) {
    var value = $("input[id$='" + id + "']").val();
    var txt1 = parseInt($("#txt_name").val());
    var txt2 = parseInt($("#txt_shrt_cde").val()) + 1;
    digit = txt1 - txt2;
    $("#" + event.srcElement.id).attr("maxlength", txt1);
    if (txt2 == 1) {
        return isValidOnlyNumbers(event);
    }
    var e = event || evt; // for trans-browser compatibility
    localStorage.removeItem("rupeeFormat_Id");
    localStorage.setItem("rupeeFormat_Id", id);
    var charCode = e.which || e.keyCode;
    if ((charCode == 45 && enableMinus == true) || event.key == "Backspace" || event.key == "Left" || event.key == "Right" || event.key == "Up" || event.ctrlKey == true || event.key == "Down" || event.key == "Del" || event.key == "Tab") {
        return true;
    }
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    else if (charCode == 46 && value == "") {
        $("input[id$='" + id + "']").val("0");
    }
    var splitVal = value.split(".");
    if (charCode == 46) {
        if (oneDotAllowed == 1 && splitVal.length == 2) {
            return false;
        }
        oneDotAllowed = 1;
    }
    if (splitVal.length >= 2) {
        var cursorPos = $("input[id$='" + id + "']").getCursorPosition();
        if (splitVal[1].length == txt2 - 1) {
            if (value.length - 3 < cursorPos) {
                return false;
            }
        }
    }
    if (value.length == digit) {
        if (splitVal.length == 1) {
            if (charCode != 46) {
                return false;
            }
        }
    }
    if (value.length == digit - 1) {
        if (splitVal.length == 1 && charCode != 46) {
            $("input[id$='" + id + "']").val(value + String.fromCharCode(charCode) + ".");
            oneDotAllowed = 1;
            return false;
        }
    }
    return true;
}

function txtChangedRupeeFormat(id) {
    if (id == undefined) {
        id = localStorage.getItem("rupeeFormat_Id");
    } else {
        id = id.ID;
    }
    var value = $("input[id$='" + id + "']").val();
    var splitValue = value.split(".");

    if (splitValue.length == 1)
        $("input[id$='" + id + "']").val(value + ".00");

    if (splitValue.length == 2) {
        if (splitValue[1] == "")
            $("input[id$='" + id + "']").val(value + "00");
        else
            $("input[id$='" + id + "']").val(value + "00".substring(0, 2 - splitValue[1].length));
    }
}


$("document").ready(function () {
    jQuery.fn.getSelectionStart = function () {
        if (this.lengh == 0) return -1;
        input = this[0];

        var pos = input.value.length;

        if (input.createTextRange) {
            var r = document.selection.createRange().duplicate();
            r.moveEnd('character', input.value.length);
            if (r.text == '')
                pos = input.value.length;
            pos = input.value.lastIndexOf(r.text);
        } else if (typeof (input.selectionStart) != "undefined")
            pos = input.selectionStart;

        return pos;
    }

    jQuery.fn.getCursorPosition = function () {
        if (this.lengh == 0) return -1;
        return $(this).getSelectionStart();
    }
    //get cursor current position end

    //insert a string at a specific index
    String.prototype.insert = function (index, string) {
        if (index > 0)
            return this.substring(0, index) + string + this.substring(index, this.length);
        else
            return string + this;
    };

});


function isValidOnlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function digitCheck() {
    if ($("#txt_shrt_cde").val() == 1 || $("#txt_shrt_cde").val() == 2 || $("#txt_shrt_cde").val() == 0) {
        return true;
    }
    else {
        kendoAlert("this digit is not allowed");
        $("#txt_shrt_cde").val('');
        $("#txt_shrt_cde").focus();
        return false;
    }
}