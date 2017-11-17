using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;


namespace BussinessLayer
{
    public partial class clsEngineer : IPrcCommonMethods<clsEngineer, bool, bool, IList<clsEngineer>, clsEngineer>
    {
        #region IPrcCommonMethods<clsAddressType,bool,bool,IList<clsAddressType>,clsAddressType> Members

        public string Save(clsEngineer objEnitty)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            string strRet = "";
            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            string strError = "";
            try
            {
                pstrError = new SqlParameter();
                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEnitty.EngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerName", SqlDbType.VarChar, objEnitty.EngineerName));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact1", SqlDbType.VarChar, objEnitty.EngineerContact1));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact2", SqlDbType.VarChar, objEnitty.EngineerContact2));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact3", SqlDbType.VarChar, objEnitty.EngineerContact3));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerEmail", SqlDbType.VarChar, objEnitty.EngineerEmail));

                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEnitty.Password));
                Collection.Add(SQLDBParameter.CreateParameter("@pAllow", SqlDbType.Bit, objEnitty.Allow));

                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerAddress", SqlDbType.VarChar, objEnitty.EngineerAddress));
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEnitty.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEnitty.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEnitty.Zip));
                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEnitty.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEnitty.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Int, objEnitty.UpdatedBy));

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcEngineer_InsertUpdate", Collection);
                strRet = pstrError.Value.ToString();
                return strRet;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            
        }

        public bool InsertUpdate(clsEngineer objEnitty)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;

            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            string strError = "";
            try
            {
                pstrError = new SqlParameter();
                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEnitty.EngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerName", SqlDbType.VarChar, objEnitty.EngineerName));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact1", SqlDbType.VarChar, objEnitty.EngineerContact1));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact2", SqlDbType.VarChar, objEnitty.EngineerContact2));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerContact3", SqlDbType.VarChar, objEnitty.EngineerContact3));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerEmail", SqlDbType.VarChar, objEnitty.EngineerEmail));

                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEnitty.Password));
                Collection.Add(SQLDBParameter.CreateParameter("@pAllow", SqlDbType.Bit, objEnitty.Allow));

                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerAddress", SqlDbType.VarChar, objEnitty.EngineerAddress));
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEnitty.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEnitty.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEnitty.Zip));
                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEnitty.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEnitty.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Int, objEnitty.UpdatedBy));

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcEngineer_InsertUpdate", Collection);
                strError = pstrError.Value.ToString();
                if (strError != "")
                {
                    throw new Exception(strError);
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsEngineer objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;

            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerIDs", SqlDbType.VarChar, objEntity.EngineerIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcEngineerID_DeleteMultiple", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        

        public bool Delete(clsEngineer objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;

            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEntity.EngineerID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcEngineerID_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
         public bool LogEngineerCost(clsEngineer objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;

            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEntity.EngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerCost", SqlDbType.VarChar, objEntity.EngineerCost));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcEngineerCost_Insert]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsEngineer> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();
                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcEngineer_ListAll", Collection);
                IList<clsEngineer> objRetList = DataUtil.ConvertToList<clsEngineer>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsEngineer SelectOne(clsEngineer objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsEngineer> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEnitty.EngineerID));
                ds = objWrapper.GetSQLDataSet("ProcEngineer_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsEngineer>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        public IList<clsEngineer> EngLogin(clsEngineer objEntity)
        {
            Wraper objWrapper = null;

            IList<clsEngineer> objRetList = null;
            List<SqlParameter> Collection = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEMail", SqlDbType.VarChar, objEntity.EngineerEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEntity.Password));
                ds = objWrapper.GetSQLDataSet("sp_EngLogin", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsEngineer>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList;
        }

        #endregion

    }
}
