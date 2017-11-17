using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer;

namespace BussinessLayer
{
    public partial class clsGenerateInvoice : IPrcCommonMethods<clsGenerateInvoice, string, bool, IList<clsGenerateInvoice>, clsGenerateInvoice>
    {
        public string InsertUpdate(clsGenerateInvoice objEntity)
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
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectGenerateInvoiceID", SqlDbType.Int, objEntity.ProjectGenerateInvoiceID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceIDs", SqlDbType.VarChar, objEntity.ProjectInvoiceIDs));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceNumber", SqlDbType.VarChar, objEntity.InvoiceNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcGenerateInvoice_InsertUpdate]", Collection);
                strError = pstrError.Value.ToString();


            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strError;
        }

        public bool DeleteMultiple(clsGenerateInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectGenerateInvoiceIDs", SqlDbType.VarChar, objEntity.ProjectGenerateInvoiceIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcGenerateInvoice_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsGenerateInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectGenerateInvoiceID", SqlDbType.Int, objEntity.ProjectGenerateInvoiceID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcGenerateInvoice_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsGenerateInvoice> GetAllInvoice(clsGenerateInvoice objEnitty)
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
                ds = objWrapper.GetSQLDataSet("ProcGeneratedInvoice_ListAll", Collection);
                IList<clsGenerateInvoice> objRetList = DataUtil.ConvertToList<clsGenerateInvoice>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsGenerateInvoice> GetAll()
        {
            throw new NotImplementedException();
        }

     
        
        public clsGenerateInvoice SelectOne(clsGenerateInvoice objEntity)
        {
            Wraper objWrapper = null;
            IList<clsGenerateInvoice> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectGenerateInvoiceID));
                ds = objWrapper.GetSQLDataSet("ProcGenerateInvoice_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsGenerateInvoice>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }
        
    }
}
