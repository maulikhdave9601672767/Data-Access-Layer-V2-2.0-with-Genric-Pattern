using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectUploadEngineerInvoice : IPrcCommonMethods<clsProjectUploadEngineerInvoice, bool, bool, IList<clsProjectUploadEngineerInvoice>, clsProjectUploadEngineerInvoice>
    {
        #region IPrcCommonMethods<clsProjectUploadEngineerInvoice,bool,bool,IList<clsProjectUploadEngineerInvoice>,clsProjectUploadEngineerInvoice> Members

        public bool InsertUpdate(clsProjectUploadEngineerInvoice objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerInvoiceID", SqlDbType.Int, objEnitty.ProjectEngineerInvoiceID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentTitle", SqlDbType.VarChar, objEnitty.DocumentTitle));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentFileName", SqlDbType.VarChar, objEnitty.DocumentFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectEngineerInvoice_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectUploadEngineerInvoice> GetAllProjectPO(clsProjectUploadEngineerInvoice objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                ds = objWrapper.GetSQLDataSet("[ProjectEngineerInvoice_GetAll]", Collection);
                IList<clsProjectUploadEngineerInvoice> objRetList = DataUtil.ConvertToList<clsProjectUploadEngineerInvoice>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool Delete(clsProjectUploadEngineerInvoice objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerInvoiceID", SqlDbType.Int, objEnitty.ProjectEngineerInvoiceID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectEngineerInvoice_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectUploadEngineerInvoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectUploadEngineerInvoice SelectOne(clsProjectUploadEngineerInvoice objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
