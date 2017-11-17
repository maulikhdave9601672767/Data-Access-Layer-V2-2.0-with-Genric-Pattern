using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsIntermediaryContact : IPrcCommonMethods<clsIntermediaryContact, bool, bool, IList<clsIntermediaryContact>, clsIntermediaryContact>
    {
        public string Save(clsIntermediaryContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryContactID", SqlDbType.Int, objEntity.IntermediaryContactID));
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryID", SqlDbType.VarChar, objEntity.IntermediaryID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonName", SqlDbType.VarChar, objEntity.ContactPersonName));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonPhone", SqlDbType.VarChar, objEntity.ContactPersonPhone));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonEmail", SqlDbType.VarChar, objEntity.ContactPersonEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pContactPersonFax", SqlDbType.VarChar, objEntity.ContactPersonFax));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediaryContactMaster_Save]", Collection);
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





        public bool Delete(clsIntermediaryContact objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryContactID", SqlDbType.Int, objEntity.IntermediaryContactID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediaryContactMaster_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsIntermediaryContact objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryContactIDs", SqlDbType.VarChar, objEnitty.IntermediaryContactIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcIntermediaryContactMaster_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsIntermediaryContact> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsIntermediaryContact> GetAllIntermediaryContact(clsIntermediaryContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryID", SqlDbType.VarChar, objEnitty.IntermediaryID ));
                ds = objWrapper.GetSQLDataSet("[ProcIntermediaryContactMaster_ListAll]", Collection);
                IList<clsIntermediaryContact> objRetList = DataUtil.ConvertToList<clsIntermediaryContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsIntermediaryContact> GetAllProjectIntContactMapped(clsIntermediaryContact objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.VarChar, objEnitty.ProjectId));
                ds = objWrapper.GetSQLDataSet("[ProcProjectIntContactMapping_ListAll]", Collection);
                IList<clsIntermediaryContact> objRetList = DataUtil.ConvertToList<clsIntermediaryContact>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsIntermediaryContact SelectOne(clsIntermediaryContact objEntity)
        {
            Wraper objWrapper = null;
            IList<clsIntermediaryContact> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pIntermediaryContactID", SqlDbType.Int, objEntity.IntermediaryContactID));
                ds = objWrapper.GetSQLDataSet("[ProcIntermediaryContactMaster_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsIntermediaryContact>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        #region IPrcCommonMethods<clsIntermediaryContact,bool,bool,IList<clsIntermediaryContact>,clsIntermediaryContact> Members

        public bool InsertUpdate(clsIntermediaryContact objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
