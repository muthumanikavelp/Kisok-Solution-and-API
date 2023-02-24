using System;
using nafmodel;
using nafdatamodel;
using static nafmodel.Web_MasterDefinition_model;

namespace nafservice
{
    public class Web_MasterDefinition_service
    {
        public static MasterRootObject MasterDefinition_List(MasterContext ObjContext, string Mysql)
        {
            MasterRootObject ObjFetchAll = new MasterRootObject();
            Web_MasterDefinition_DB objDataModel = new Web_MasterDefinition_DB();
            try
            {
                ObjFetchAll = objDataModel.MasterDefinition_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static Master_FRoot MasterDefinition_SingleFetch(Master_FContext objfarmer, string Mysql)
        {
            Master_FRoot ObjFarmerRoot = new Master_FRoot();
            Web_MasterDefinition_DB objDataModel = new Web_MasterDefinition_DB();

            try
            {
                ObjFarmerRoot = objDataModel.MasterDefinition_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static Master_DocumentSave MasterDefinition_Save(Master_RootSave objmodel, string MysqlCon)
        {
            Master_DocumentSave objIUStockDocument = new Master_DocumentSave();
            try
            {
                Web_MasterDefinition_DB objDataModel = new Web_MasterDefinition_DB();
                objIUStockDocument = objDataModel.MasterDefinition_Save(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // //   logger.Error(ex.ToString());
                throw ex;
            }
        }


        //delete
        public static Master_DocumentSave MasterDefinition_delete(Master_RootSave objmodel, string MysqlCon)
        {
            Master_DocumentSave objIUStockDocument = new Master_DocumentSave();
            try
            {
                Web_MasterDefinition_DB objDataModel = new Web_MasterDefinition_DB();
                objIUStockDocument = objDataModel.MasterDefinition_delete(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // //   logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static MasterCodeScreenID GetMasterCodeScreenId_srv(string org, string locn, string user, string lang, string screen_code,string ConString)
        {
            MasterCodeScreenID objScreen = new MasterCodeScreenID();
            try
            {
                Web_MasterDefinition_DB objDataModel = new Web_MasterDefinition_DB();
                objScreen = objDataModel.GetMasterCodeScreenId_db(org, locn, user, lang, screen_code, ConString);
            }
            catch (Exception ex)
            {
                ////   logger.Error(ex);
            }
            return objScreen;
        }
    }
}
