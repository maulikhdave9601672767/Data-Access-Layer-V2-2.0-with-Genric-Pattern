using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsPaymentMade : IPrcCommonMethods<clsPaymentMade, string, bool, IList<clsPaymentMade>, clsPaymentMade>
    {

        #region IPrcCommonMethods<clsPaymentMade,bool,bool,IList<clsPaymentMade>,clsPaymentMade> Members

        public string InsertUpdate(clsPaymentMade objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectPaymentID", SqlDbType.Int, objEnitty.ProjectPaymentID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectId", SqlDbType.Int, objEnitty.ProjectId));
                Collection.Add(SQLDBParameter.CreateParameter("@pPaidTo", SqlDbType.VarChar, objEnitty.PaidTo));
                Collection.Add(SQLDBParameter.CreateParameter("@pPaidAmt", SqlDbType.Decimal, objEnitty.PaidAmt));
                Collection.Add(SQLDBParameter.CreateParameter("@pPaidDate", SqlDbType.DateTime, objEnitty.PaidDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceNumber", SqlDbType.VarChar, objEnitty.InvoiceNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pCheckNumber", SqlDbType.VarChar, objEnitty.CheckNumber));
                Collection.Add(SQLDBParameter.CreateParameter("@pPaymentMadeImageURL", SqlDbType.VarChar, objEnitty.PaymentMadeImageURL));
                Collection.Add(SQLDBParameter.CreateParameter("@pAmountPercent", SqlDbType.NVarChar, objEnitty.AmountPercent));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Int, objEnitty.UpdatedBy));
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("ProcPaymentMade_InsertUpdate", Collection);
                strError = pstrError.Value.ToString();
                

            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strError;

            
        }

        public bool DeleteMultiple(clsPaymentMade objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pPaymentMadeIDs", SqlDbType.VarChar, objEnitty.ProjectPaymentIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcPaymentMade_DeleteMultiple", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsPaymentMade objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pPaymentMadeID", SqlDbType.Int, objEnitty.ProjectPaymentID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcPaymentMade_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsPaymentMade> GetAllPayment(clsPaymentMade objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectId));
                ds = objWrapper.GetSQLDataSet("ProcPaymentMade_ListAll", Collection);
                IList<clsPaymentMade> objRetList = DataUtil.ConvertToList<clsPaymentMade>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsPaymentMade> GetAll()
        {
            throw new Exception();
        }

        public clsPaymentMade SelectOne(clsPaymentMade objEntity)
        {
            Wraper objWrapper = null;
            IList<clsPaymentMade> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectPaymentID", SqlDbType.Int, objEntity.ProjectPaymentID));
                ds = objWrapper.GetSQLDataSet("ProcPayementMade_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsPaymentMade>(ds.Tables[0]);
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
