using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsClient : IPrcCommonMethods<clsClient, bool, bool, IList<clsClient>, clsClient>
    {
        #region IPrcCommonMethods<clsClient,bool,bool,IList<clsClient>,clsClient> Members

        public string Save(clsClient objEntity)
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
                pstrError.ParameterName = "pstrError";

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEntity.ClientID));
                Collection.Add(SQLDBParameter.CreateParameter("@pCompanyName", SqlDbType.VarChar, objEntity.CompanyName));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet1", SqlDbType.VarChar, objEntity.Street1));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet2", SqlDbType.VarChar, objEntity.Street2));

                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEntity.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEntity.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEntity.Zip));
               
               

                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEntity.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhone", SqlDbType.VarChar, objEntity.Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEntity.Email));

                Collection.Add(SQLDBParameter.CreateParameter("@pNames", SqlDbType.VarChar, objEntity.Names));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhones", SqlDbType.VarChar, objEntity.Phones));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmails", SqlDbType.VarChar, objEntity.Emails));
                Collection.Add(SQLDBParameter.CreateParameter("@pFaxs", SqlDbType.VarChar, objEntity.Faxs));

                Collection.Add(SQLDBParameter.CreateParameter("@pFax", SqlDbType.VarChar, objEntity.Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEntity.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Bit, objEntity.CreatedBy));
                

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcClient_InsertUpdate", Collection);
                strRet = pstrError.Value.ToString();
                return strRet;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strRet;
        }


        public bool InsertUpdate(clsClient objEntity)
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
                pstrError.ParameterName = "pstrError";

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEntity.ClientID));
                Collection.Add(SQLDBParameter.CreateParameter("@pCompanyName", SqlDbType.VarChar, objEntity.CompanyName));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet1", SqlDbType.VarChar, objEntity.Street1));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet2", SqlDbType.VarChar, objEntity.Street2));
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEntity.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEntity.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEntity.Zip));
               

                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEntity.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhone", SqlDbType.VarChar, objEntity.Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEntity.Email));

                Collection.Add(SQLDBParameter.CreateParameter("@pNames", SqlDbType.VarChar, objEntity.Names));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhones", SqlDbType.VarChar, objEntity.Phones));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmails", SqlDbType.VarChar, objEntity.Emails));
                Collection.Add(SQLDBParameter.CreateParameter("@pFaxs", SqlDbType.VarChar, objEntity.Faxs));

                Collection.Add(SQLDBParameter.CreateParameter("@pFax", SqlDbType.VarChar, objEntity.Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEntity.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Bit, objEntity.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Bit, objEntity.UpdatedBy));

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcClient_InsertUpdate", Collection);
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



        public bool Delete(clsClient objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEntity.ClientID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcClient_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsClient objEnitty)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;

            try
            {
                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientIDs", SqlDbType.VarChar, objEnitty.ClientIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClient_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsClient> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcClient_ListAll", Collection);
                IList<clsClient> objRetList = DataUtil.ConvertToList<clsClient>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsClient SelectOne(clsClient objEntity)
        {
            Wraper objWrapper = null;
            IList<clsClient> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEntity.ClientID));
                ds = objWrapper.GetSQLDataSet("ProcClient_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsClient>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        public IList<clsClient> ClLogin(clsClient objEntity)
        {
            Wraper objWrapper = null;

            IList<clsClient> objRetList = null;
            List<SqlParameter> Collection = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEMail", SqlDbType.VarChar, objEntity.Email));
                //Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEntity.Password));
                ds = objWrapper.GetSQLDataSet("sp_ClLogin", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsClient>(ds.Tables[0]);
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
