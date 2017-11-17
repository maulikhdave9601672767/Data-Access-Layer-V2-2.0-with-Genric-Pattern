using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsInvoice : IPrcCommonMethods<clsInvoice, string, bool, IList<clsInvoice>, clsInvoice>
    {
        #region IPrcCommonMethods<clsInvoice,bool,bool,IList<clsInvoice>,clsInvoice> Members

        public string InsertUpdate(clsInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectInvoiceID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceNumber", SqlDbType.VarChar, objEntity.InvoiceNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceDate", SqlDbType.DateTime, objEntity.InvoiceDate));

                Collection.Add(SQLDBParameter.CreateParameter("@pAmount", SqlDbType.Decimal, objEntity.Amount));
                Collection.Add(SQLDBParameter.CreateParameter("@pDescription", SqlDbType.VarChar, objEntity.Description));
                Collection.Add(SQLDBParameter.CreateParameter("@pDueDate", SqlDbType.DateTime, objEntity.DueDate));

                Collection.Add(SQLDBParameter.CreateParameter("@pEmail", SqlDbType.VarChar, objEntity.Email));
                Collection.Add(SQLDBParameter.CreateParameter("@pStatus", SqlDbType.VarChar, objEntity.Status));
                Collection.Add(SQLDBParameter.CreateParameter("@pDateReceived", SqlDbType.DateTime, objEntity.DateReceived));

                Collection.Add(SQLDBParameter.CreateParameter("@pCheckNumber", SqlDbType.VarChar, objEntity.CheckNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pAmountReceived", SqlDbType.Decimal, objEntity.AmountReceived));
                Collection.Add(SQLDBParameter.CreateParameter("@pAmountInPercentage", SqlDbType.Decimal, objEntity.AmountInPercentage));
                Collection.Add(SQLDBParameter.CreateParameter("@pUploadedImageInvoiceName", SqlDbType.VarChar, objEntity.UploadedImageInvoiceName));

                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Int, objEntity.UpdatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceFileName", SqlDbType.VarChar, objEntity.InvoiceFileName));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcInvoice_InsertUpdate", Collection);
                strError = pstrError.Value.ToString();
                

            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strError;
        }

        public string UpdateReceiveStatus(clsInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectInvoiceID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceNumber", SqlDbType.VarChar, objEntity.InvoiceNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pDateReceived", SqlDbType.DateTime, objEntity.DateReceived));
                Collection.Add(SQLDBParameter.CreateParameter("@pCheckNumber", SqlDbType.VarChar, objEntity.CheckNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pAmountReceived", SqlDbType.Decimal, objEntity.AmountReceived));
                Collection.Add(SQLDBParameter.CreateParameter("@pAmountInPercentage", SqlDbType.Decimal, objEntity.AmountInPercentage));
                Collection.Add(SQLDBParameter.CreateParameter("@pUploadedImageInvoiceName", SqlDbType.VarChar, objEntity.UploadedImageInvoiceName));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceFileName", SqlDbType.VarChar, objEntity.InvoiceFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcInvoice_Receive]", Collection);
                strError = pstrError.Value.ToString();


            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strError;
        }

        public bool DeleteMultiple(clsInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceIDs", SqlDbType.VarChar, objEntity.ProjectInvoiceIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcInvoice_DeleteMultiple", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsInvoice objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectInvoiceID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcInvoice_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsInvoice> GetAllInvoice(clsInvoice objEnitty)
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
                ds = objWrapper.GetSQLDataSet("ProcInvoice_ListAll", Collection);
                IList<clsInvoice> objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsInvoice> GetAll()
        {
            throw new NotImplementedException() ;
        }
        public IList<clsInvoice> GetAllInvoiceDueDate()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                
                ds = objWrapper.GetSQLDataSet("[ProcProjectInvoiceDueDate_ListAll]", Collection);
                IList<clsInvoice> objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public DataSet GetAllOpenInvoiceDetails( string strFromDate,string strToDate)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            DataSet dsRet = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                dsRet = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pFromDate", SqlDbType.VarChar, strFromDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pToDate", SqlDbType.VarChar, strToDate));
                ds = objWrapper.GetSQLDataSet("[ProjectOpenInventoryReport]", Collection);

                DataTable dtYear = ds.Tables[0].DefaultView.ToTable(true, "CompanyName");
                dtYear.TableName = "CompanyName";
                dsRet.Tables.Add(dtYear);

                DataTable dtDetails = ds.Tables[0].DefaultView.ToTable();
                dtDetails.TableName = "dtDetails";
                dsRet.Tables.Add(dtDetails);

                return dsRet;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsInvoice> GetAllGenerateInvoice(clsInvoice objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProcGenerateInvoice_ListAll]", Collection);
                IList<clsInvoice> objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsInvoice> GetProjectInvoicesDetails(clsInvoice objEntity)
        {
            Wraper objWrapper = null;
            IList<clsInvoice> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                //Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceIDs", SqlDbType.VarChar, objEntity.ProjectInvoiceIDs));
                ds = objWrapper.GetSQLDataSet("[ProcProjectInvoices_GetDetails]", Collection);
                objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);

            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList;
        }
        public clsInvoice SelectOne(clsInvoice objEntity)
        {
            Wraper objWrapper = null;
            IList<clsInvoice> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectInvoiceID));
                ds = objWrapper.GetSQLDataSet("ProcInvoice_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }
        public clsInvoice GetProjectInvoiceDetails(clsInvoice objEntity)
        {
            Wraper objWrapper = null;
            IList<clsInvoice> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInvoiceID", SqlDbType.Int, objEntity.ProjectInvoiceID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectInvoice_GetDetails]", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsInvoice>(ds.Tables[0]);
                }
                else {
                    objEntity.strError = "No Client Assigned to Project. Please Assign Client to Project";
                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        #endregion
    }
}
