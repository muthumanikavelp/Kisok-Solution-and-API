function purchase_order_list(FilterrequestObject) {
    PurchaseOrder_Purchase_Order_retrive_PO_List.invokeAPI(null, FilterrequestObject, purchase_order_listAPI_ResponseHandler);
}

function purchase_order_listAPI_ResponseHandler(data, textStatus) {
    if (textStatus == "success") {
        responseJSON = jQuery.parseJSON(data);
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
                generate_purchase_order_Grid(responseJSON);
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

function retrieve_purchase_order(HeaderrequestObject) {
    PurchaseOrder_Purchase_Order_retrievePO.invokeAPI(null, HeaderrequestObject, retrieve_purchase_orderAPI_ResponseHandler);
}

function retrieve_purchase_orderAPI_ResponseHandler(data, textStatus) {
    if (textStatus == "success") {
        responseJSON = jQuery.parseJSON(data);
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
                generatePurchaseOrderdetails(responseJSON.context.Detail);                
                generatePurchaseOrderterm(responseJSON.context.Terms);
                generateField(responseJSON.context.Header);
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

function save_purchase_order(HeaderrequestObject, DetailrequestObjectArray, TermsrequestObjectArray) {
    PurchaseOrder_Purchase_Order_savePO.invokeAPI(null, HeaderrequestObject, DetailrequestObjectArray, TermsrequestObjectArray, save_purchase_orderAPI_ResponseHandler)
}

function save_purchase_orderAPI_ResponseHandler(data, textStatus) {
    if (textStatus == "success") {
        responseJSON = jQuery.parseJSON(data);
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
                bind_purchase_orderAPI_Response(responseJSON);
                var po_rowid = responseJSON.context.Header.po_rowid;
                purchase_order_fetch(po_rowid);
                $("#txt_Row_Id").val(po_rowid);
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

function bind_purchase_orderAPI_Response(responseJSON) {
    kendoAlert("Purchase Order Details saved successfully");
   // var group = $('#cmb_item_group').data("kendoComboBox").value();
   // var subgroup = $('#cmb_item_subgroup').data("kendoComboBox").value();
   // var itemcode = $("#txt_item_code").val();
    //var itemdesc = $("#txt_item_desc").val();
  //  item_master_fetch(group, subgroup, itemcode, itemdesc);


}



