using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsIntermediary : IPrcCommonMethods<clsIntermediary, bool, bool, IList<clsIntermediary>, clsIntermediary>
    {
        public string Save(clsIntermediary objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryID", SqlDbType.Int, objEnitty.IntermediaryID));
                Collection.Add(SQLDBParameter.CreateParameter("@pCompanyName", SqlDbType.VarChar, objEnitty.CompanyName));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet1", SqlDbType.VarChar, objEnitty.Street1));
                Collection.Add(SQLDBParameter.CreateParameter("@pStreet2", SqlDbType.VarChar, objEnitty.Street2));
                Collection.Add(SQLDBParameter.CreateParameter("@pCity", SqlDbType.VarChar, objEnitty.City));
                Collection.Add(SQLDBParameter.CreateParameter("@pState", SqlDbType.VarChar, objEnitty.State));
                Collection.Add(SQLDBParameter.CreateParameter("@pZip", SqlDbType.VarChar, objEnitty.Zip));                
                Collection.Add(SQLDBParameter.CreateParameter("@pWebsite", SqlDbType.VarChar, objEnitty.Website));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhone", SqlDbType.VarChar, objEnitty.Phone));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEnitty.Email));
                Collection.Add(SQLDBParameter.CreateParameter("@pFax", SqlDbType.VarChar, objEnitty.Fax));

                Collection.Add(SQLDBParameter.CreateParameter("@pNames", SqlDbType.VarChar, objEnitty.Names));
                Collection.Add(SQLDBParameter.CreateParameter("@pPhones", SqlDbType.VarChar, objEnitty.Phones ));
                Collection.Add(SQLDBParameter.CreateParameter("@pEmails", SqlDbType.VarChar, objEnitty.Emails));
                Collection.Add(SQLDBParameter.CreateParameter("@pFaxs", SqlDbType.VarChar, objEnitty.Faxs));

                Collection.Add(SQLDBParameter.CreateParameter("@pIsActive", SqlDbType.Bit, objEnitty.IsActive));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediary_InsertUpdate]", Collection);
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

        

        public bool DeleteMultiple(clsIntermediary objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryIDs", SqlDbType.VarChar, objEnitty.IntermediaryIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediary_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsIntermediary objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryID", SqlDbType.Int, objEnitty.IntermediaryID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediary_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsIntermediary> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("[ProcIntermediary_ListAll]", Collection);
                IList<clsIntermediary> objRetList = DataUtil.ConvertToList<clsIntermediary>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsIntermediary SelectOne(clsIntermediary objEntity)
        {
            Wraper objWrapper = null;
            IList<clsIntermediary> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryID", SqlDbType.Int, objEntity.IntermediaryID));
                ds = objWrapper.GetSQLDataSet("[ProcIntermediary_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsIntermediary>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        #region IPrcCommonMethods<clsIntermediary,bool,bool,IList<clsIntermediary>,clsIntermediary> Members

        public bool InsertUpdate(clsIntermediary objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
