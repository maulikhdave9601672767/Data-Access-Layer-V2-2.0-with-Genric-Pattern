using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsContractor : IPrcCommonMethods<clsContractor, bool, bool, IList<clsContractor>, clsContractor>
    {
        #region IPrcCommonMethods<clsAddressType,bool,bool,IList<clsAddressType>,clsAddressType> Members

        public string Save(clsContractor objEnitty)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            string strRet = "";
            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
             
            try
            {
                pstrError = new SqlParameter();
                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "pstrError";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEnitty.ContractorID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorName", SqlDbType.VarChar, objEnitty.ContractorName));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet1", SqlDbType.VarChar, objEnitty.Street1));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet2", SqlDbType.VarChar, objEnitty.Street2 ));
                
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEnitty.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEnitty.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEnitty.Zip));
                
                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEnitty.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhone", SqlDbType.VarChar, objEnitty.Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEnitty.Email));

                Collection.Add(SQLDBParameter.CreateParameter("@pNames", SqlDbType.VarChar, objEnitty.Names));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhones", SqlDbType.VarChar, objEnitty.Phones));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmails", SqlDbType.VarChar, objEnitty.Emails));
                Collection.Add(SQLDBParameter.CreateParameter("@pFaxs", SqlDbType.VarChar, objEnitty.Faxs));

                Collection.Add(SQLDBParameter.CreateParameter("@pFax", SqlDbType.VarChar, objEnitty.Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEnitty.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcContractor_InsertUpdate", Collection);
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

        public bool InsertUpdate(clsContractor objEnitty)
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

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEnitty.ContractorID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorName", SqlDbType.VarChar, objEnitty.ContractorName));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet1", SqlDbType.VarChar, objEnitty.Street1));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet2", SqlDbType.VarChar, objEnitty.Street2));
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEnitty.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEnitty.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEnitty.Zip));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson1Name", SqlDbType.VarChar, objEnitty.ContactPerson1Name));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson1Phone", SqlDbType.VarChar, objEnitty.ContactPerson1Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson1Email", SqlDbType.VarChar, objEnitty.ContactPerson1Email));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson1Fax", SqlDbType.VarChar, objEnitty.ContactPerson1Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson2Name", SqlDbType.VarChar, objEnitty.ContactPerson2Name));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson2Phone", SqlDbType.VarChar, objEnitty.ContactPerson2Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson2Email", SqlDbType.VarChar, objEnitty.ContactPerson2Email));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPerson2Fax", SqlDbType.VarChar, objEnitty.ContactPerson2Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEnitty.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhone", SqlDbType.VarChar, objEnitty.Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEnitty.Email));

                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEnitty.Password));
                Collection.Add(SQLDBParameter.CreateParameter("@pAllow", SqlDbType.VarChar, objEnitty.Allow));

                Collection.Add(SQLDBParameter.CreateParameter("@pFax", SqlDbType.VarChar, objEnitty.Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEnitty.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.VarChar, objEnitty.UpdatedBy));

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcContractor_InsertUpdate", Collection);
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

        public bool DeleteMultiple(clsContractor objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorIDs", SqlDbType.VarChar, objEnitty.ContractorIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcContractor_DeleteMultiple", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsContractor objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEnitty.ContractorID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcContractor_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsContractor> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcContractor_ListAll", Collection);
                IList<clsContractor> objRetList = DataUtil.ConvertToList<clsContractor>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsContractor SelectOne(clsContractor objEntity)
        {
            Wraper objWrapper = null;
            IList<clsContractor> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEntity.ContractorID));
                ds = objWrapper.GetSQLDataSet("ProcContractor_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsContractor>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        public IList<clsContractor> ContLogin(clsContractor objEntity)
        {
            Wraper objWrapper = null;

            IList<clsContractor> objRetList = null;
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
                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEntity.Password));
                ds = objWrapper.GetSQLDataSet("sp_ContLogin", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsContractor>(ds.Tables[0]);
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
