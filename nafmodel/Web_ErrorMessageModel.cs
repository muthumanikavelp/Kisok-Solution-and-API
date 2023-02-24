using System;
using System.Collections.Generic;
using System.Text;

namespace nafmodel
{
    public class Web_ErrorMessageModel
    {
        public string Errorno = "";
        public string ErrorMsg = "";
        public string ErrorMessage(string errorNo)
        {
            if (errorNo == "001")
            {
                ErrorMsg = "";
            }
            if (errorNo == "15001")
            {
                ErrorMsg = "Activity / Screen Name cannot be blank";
            }
            if (errorNo == "15009")
            {
                ErrorMsg = "Document Numbering cannot be made as inactive as this is used by some Activity / Screen Name";
            }
            if (errorNo == "15002")
            {
                ErrorMsg = "FY Description cannot be blank";
            }
            if (errorNo == "15010")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "15011")
            {
                ErrorMsg = "Inactive Record  cannot be modified";
            }
            if (errorNo == "15003")
            {
                ErrorMsg = "Sequence No cannot be blank ";
            }
            if (errorNo == "15004")
            {
                ErrorMsg = "Field Description cannot be blank";
            }
            if (errorNo == "15005")
            {
                ErrorMsg = "Value Type cannot be blank";
            }
            if (errorNo == "15006")
            {
                ErrorMsg = "Length cannot be blank";
            }
            if (errorNo == "15007")
            {
                ErrorMsg = "Value cannot be blank";
            }
            if (errorNo == "15008")
            {
                ErrorMsg = "Sequence No should be unique for an Activity / Screen Name";
            }
            if (errorNo == "14001")
            {
                ErrorMsg = "FY Code cannot be blank";
            }
            if (errorNo == "14002")
            {
                ErrorMsg = "FY Description cannot be blank";
            }
            if (errorNo == "14003")
            {
                ErrorMsg = "FY Code should be unique ";
            }
            if (errorNo == "14004")
            {
                ErrorMsg = "FY Description should be unique";
            }
            if (errorNo == "14005")
            {
                ErrorMsg = "FY Start Cannot be blank ";
            }
            if (errorNo == "14006")
            {
                ErrorMsg = "FY Code should be unique ";
            }
            if (errorNo == "14008")
            {
                ErrorMsg = "FY end date should always be greater than FY start date";
            }
            if (errorNo == "14009")
            {
                ErrorMsg = "FY duration should not overlap with existing FYs ";
            }
            if (errorNo == "14010")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "14011")
            {
                ErrorMsg = "Inactive Record  cannot be modified";
            }
            if (errorNo == "14012")
            {
                ErrorMsg = "FYs duration cannot duplicate ";
            }
            if (errorNo == "03001")
            {
                ErrorMsg = "Entity Group code cannot be blank";
            }
            if (errorNo == "03002")
            {
                ErrorMsg = "Entity Group name cannot be blank";
            }
            if (errorNo == "03003")
            {
                ErrorMsg = "Attribute Group Name(Local Lang)  cannot be blank";
            }
            if (errorNo == "03004")
            {
                ErrorMsg = "Attribute Group Name in_entitygrp_name should be unique";
            }
            if (errorNo == "03010")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "03018")
            {
                ErrorMsg = "Attribute Code cannot be blank";
            }
            if (errorNo == "03019")
            {
                ErrorMsg = "Attribute Group Type  cannot be blank";
            }
            if (errorNo == "03020")
            {
                ErrorMsg = "Entity Group Code '~entitygrp_code <-> udd_userid~' cannot be duplicated";
            }
            if (errorNo == "03015")
            {
                ErrorMsg = " InActive record cannot be modified";
            }
            if (errorNo == "03021")
            {
                ErrorMsg = "Sl No' cannot be blank";
            }
            if (errorNo == "03022")
            {
                ErrorMsg = "  Attribute Name (English) cannot be blank";
            }
            if (errorNo == "03023")
            {
                ErrorMsg = "Attribute Name (Local Lang) cannot be blank";
            }
            if (errorNo == "03024")
            {
                ErrorMsg = "Attribute Type cannot be blank";
            }
            if (errorNo == "03025")
            {
                ErrorMsg = "Attribute Length cannot be blank";
            }
            if (errorNo == "03026")
            {
                ErrorMsg = " Attribute Name (English) entity_name  udd_short_desc should be unique";
            }
            if (errorNo == "03027")
            {
                ErrorMsg = "Attribute Name (Local Lang)  in_entity_ll_name should be unique";
            }
            if (errorNo == "03011")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue ";
            }
            if (errorNo == "01001")
            {
                ErrorMsg = "Role Code cannot be blank";
            }
            if (errorNo == "01002")
            {
                ErrorMsg = "Role Name Cannot be blank";
            }
            if (errorNo == "01003")
            {
                ErrorMsg = "Organization Level cannot be blank";
            }
            if (errorNo == "01004")
            {
                ErrorMsg = "Screen permissions cannot be set as blank for the role";
            }
            if (errorNo == "01005")
            {
                ErrorMsg = "Role cannot be made as inactive as this role is assigned to some active user";
            }
            if (errorNo == "01010")
            {
                ErrorMsg = "Role Code cannot be duplicated";
            }
            if (errorNo == "01011")
            {
                ErrorMsg = "Role Name cannot be duplicated";
            }
           /* if (errorNo == "01020")
            {
                ErrorMsg = "Inactive record cannot be modified/deleted";
            }
           */
            if (errorNo == "01020")
            {
                ErrorMsg = "Role Code cannot be modified/deleted";
            }
            if (errorNo == "01021")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "02001")
            {
                ErrorMsg = "User Code cannot be blank";
            }
            if (errorNo == "02003")
            {
                ErrorMsg = "User Name cannot be blank";
            }
            if (errorNo == "02002")
            {
                ErrorMsg = "Role cannot be blank";
            }
            if (errorNo == "02004")
            {
                ErrorMsg = "Password cannot be blank";
            }
            if (errorNo == "02006")
            {
                ErrorMsg = "Belongs to Organization cannot be blank";
            }
            if (errorNo == "02008")
            {
                ErrorMsg = "Password cannot be blank";
            }
            if (errorNo == "02009")
            {
                ErrorMsg = "Mobile No cannot be blank";
            }
            if (errorNo == "02010")
            {
                ErrorMsg = " User Code cannot be duplicated";
            }
            if (errorNo == "02011")
            {
                ErrorMsg = "Valid Till  cannot be a past date";
            }
            if (errorNo == "02015")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "02016")
            {
                ErrorMsg = "User Name should be unique";
            }
            if (errorNo == "02017")
            {
                ErrorMsg = "User cannot be made as inactive as this user has one/more active transaction(s)";
            }
            #region Attribute Group Mapping
            if (errorNo == "04001")
            {
                ErrorMsg = "Activity / Screen Name cannot be blank";
            }
            if (errorNo == "04002")
            {
                ErrorMsg = "Attribute Group Name  cannot be blank";
            }
            if (errorNo == "04010")
            {
                ErrorMsg = "Inactive record cannot be modified";
            }
            if (errorNo == "04004")
            {
                ErrorMsg = " Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "04015")
            {
                ErrorMsg = "Attribute Group Name should be unique for an Activity / Screen Name";
            }
            #endregion

            #region Bank
            if (errorNo == "16001")
            {
                ErrorMsg = "There is no farmer in DB";
            }
            if (errorNo == "16002")
            {
                ErrorMsg = "Bank Name cannot be blank";
            }
            if (errorNo == "16003")
            {
                ErrorMsg = "Bank Code should be unique";
            }
            if (errorNo == "16010")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue";
            }
            if (errorNo == "16011")
            {
                ErrorMsg = "Inactive Record  cannot be modified";
            }
            if (errorNo == "16004")
            {
                ErrorMsg = "Bank Name  should be unique";
            }
            if (errorNo == "16009")
            {
                ErrorMsg = "Bank Branch cannot be made as inactive as this is used by some Activity / Screen Name";
            }
            if (errorNo == "16012")
            {
                ErrorMsg = "Bank cannot be made as inactive as this is used by some Activity / Screen Name";
            }
            if (errorNo == "16005")
            {
                ErrorMsg = "Bank Branch cannot be blank";
            }
            if (errorNo == "16007")
            {
                ErrorMsg = "Bank IFSC Code Cannot Be Blank";
            }
            if (errorNo == "16006")
            {
                ErrorMsg = " Bank Branch  should be unique within a Bank";
            }
            if (errorNo == "16008")
            {
                ErrorMsg = "Bank IFSC Code should be unique within a Bank";
            }
            if (errorNo == "001")
            {
                ErrorMsg = "";
            }
            if (errorNo == "001")
            {
                ErrorMsg = "";
            }
            if (errorNo == "001")
            {
                ErrorMsg = "";
            }

            if (errorNo == "020145")
            {
                ErrorMsg = "User Name cannot be blank";
            }
            #endregion
            return ErrorMsg;
        }

    }
}
