using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer;

namespace BussinessLayer
{
    public partial class clsContractorContact : IPrcCommonMethods<clsContractorContact, bool, bool, IList<clsContractorContact>, clsContractorContact>
    {

        public bool InsertUpdate(clsContractorContact objEnitty)
        {
            throw new NotImplementedException();
        }
        public string Save(clsContractorContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorContactID", SqlDbType.Int, objEntity.ContractorContactID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.VarChar, objEntity.ContractorID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonName", SqlDbType.VarChar, objEntity.ContactPersonName));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonPhone", SqlDbType.VarChar, objEntity.ContactPersonPhone));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonEmail", SqlDbType.VarChar, objEntity.ContactPersonEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonFax", SqlDbType.VarChar, objEntity.ContactPersonFax));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcContractorContactMaster_Save]", Collection);
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





        public bool Delete(clsContractorContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorContactID", SqlDbType.Int, objEntity.ContractorContactID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcContractorContactMaster_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsContractorContact objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorContactIDs", SqlDbType.VarChar, objEnitty.ContractorContactIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcContractorContactMaster_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsContractorContact> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsContractorContact> GetAllContractorContact(clsContractorContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.VarChar, objEnitty.ContractorID));
                ds = objWrapper.GetSQLDataSet("[ProcContractorContactMaster_ListAll]", Collection);
                IList<clsContractorContact> objRetList = DataUtil.ConvertToList<clsContractorContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsContractorContact> GetAllProjectContractorContactMapped(clsContractorContact objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectContractorContactMaster_ListAll]", Collection);
                IList<clsContractorContact> objRetList = DataUtil.ConvertToList<clsContractorContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsContractorContact> GetAllContractorsContact(clsContractorContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorIDs", SqlDbType.VarChar, objEnitty.ContractorIDs));
                ds = objWrapper.GetSQLDataSet("[ProcContractorsContactMaster_ListAll]", Collection);
                IList<clsContractorContact> objRetList = DataUtil.ConvertToList<clsContractorContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool SaveProjectContractorcontact(clsContractorContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorContactIDs", SqlDbType.VarChar, objEntity.ContractorContactIDs));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                //Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectContractorContactMaster_Save]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public clsContractorContact SelectOne(clsContractorContact objEntity)
        {
            Wraper objWrapper = null;
            IList<clsContractorContact> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorContactID", SqlDbType.Int, objEntity.ContractorContactID));
                ds = objWrapper.GetSQLDataSet("[ProcContractorContactMaster_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsContractorContact>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        #region IPrcCommonMethods<clsContractorContact,bool,bool,IList<clsContractorContact>,clsContractorContact> Members

       
        #endregion
    }
}
