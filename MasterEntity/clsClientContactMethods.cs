using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;

namespace BussinessLayer
{
    public partial class clsClientContact : IPrcCommonMethods<clsClientContact, bool, bool, IList<clsClientContact>, clsClientContact>
    {
        public bool InsertUpdate(clsIntermediary objEnitty)
        {
            throw new NotImplementedException();
        }
        public string Save(clsClientContact objEntity) 
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
                Collection.Add(SQLDBParameter.CreateParameter("@pClientContactID", SqlDbType.Int, objEntity.ClientContactID));
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.VarChar, objEntity.ClientID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonName", SqlDbType.VarChar, objEntity.ContactPersonName));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonPhone", SqlDbType.VarChar, objEntity.ContactPersonPhone));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonEmail", SqlDbType.VarChar, objEntity.ContactPersonEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonFax", SqlDbType.VarChar, objEntity.ContactPersonFax));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClientContactMaster_Save]", Collection);
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





        public bool Delete(clsClientContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pClientContactID", SqlDbType.Int, objEntity.ClientContactID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClientContactMaster_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsClientContact objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pClientContactIDs", SqlDbType.VarChar, objEnitty.ClientContactIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClientContactMaster_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsClientContact> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsClientContact> GetAllClientContact(clsClientContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.VarChar, objEnitty.ClientID));
                ds = objWrapper.GetSQLDataSet("[ProcClientContactMaster_ListAll]", Collection);
                IList<clsClientContact> objRetList = DataUtil.ConvertToList<clsClientContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsClientContact> GetAllProjectClientContactMapped(clsClientContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.VarChar, objEnitty.ProjectID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectClientContactMaster_ListAll]", Collection);
                IList<clsClientContact> objRetList = DataUtil.ConvertToList<clsClientContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsClientContact> GetAllClientsContact(clsClientContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientIDs", SqlDbType.VarChar, objEnitty.ClientIDs));
                ds = objWrapper.GetSQLDataSet("[ProcClientsContactMaster_ListAll]", Collection);
                IList<clsClientContact> objRetList = DataUtil.ConvertToList<clsClientContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool SaveProjectclientcontact(clsClientContact objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            string strRet = "";
            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            string strError = "";
            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pClientContactIDs", SqlDbType.VarChar, objEntity.ClientContactIDs));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                //Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectClientContactMaster_Save]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public clsClientContact SelectOne(clsClientContact objEntity)
        {
            Wraper objWrapper = null;
            IList<clsClientContact> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pClientContactID", SqlDbType.Int, objEntity.ClientContactID));
                ds = objWrapper.GetSQLDataSet("[ProcClientContactMaster_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsClientContact>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        #region IPrcCommonMethods<clsClientContact,bool,bool,IList<clsClientContact>,clsClientContact> Members

        public bool InsertUpdate(clsClientContact objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
