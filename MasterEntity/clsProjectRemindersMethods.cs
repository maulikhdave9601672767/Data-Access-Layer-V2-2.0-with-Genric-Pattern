using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;
namespace BussinessLayer
{
    public partial class clsProjectReminders : IPrcCommonMethods<clsProjectReminders, bool, bool, IList<clsProjectReminders>, clsProjectReminders>
    {

        public bool InsertUpdate(clsProjectReminders objEntity)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;

            List<SqlParameter> Collection = null;


            string strError = "";
            try
            {


                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectReminderID", SqlDbType.Int, objEntity.ProjectReminderID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInvoiceDays", SqlDbType.VarChar, objEntity.InvoiceDays));
                Collection.Add(SQLDBParameter.CreateParameter("@pPaymentMadeDays", SqlDbType.VarChar, objEntity.PaymentMadeDays));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentMissingDays", SqlDbType.VarChar, objEntity.DocumentMissingDays));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Bit, objEntity.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectReminders_Save]", Collection);

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



        public bool Delete(clsProjectReminders objEntity)
        {
            throw new NotImplementedException();
        }


        public IList<clsProjectReminders> GetAll()
        {
            throw new NotImplementedException();
            //Wraper objWrapper = null;

            //DataSet ds = null;
            //List<SqlParameter> Collection = null;
            //try
            //{
            //    ds = new DataSet();
            //    Collection = new List<SqlParameter>();

            //    objWrapper = new Wraper();
            //    ds = objWrapper.GetSQLDataSet("[ProcProjectReminders_GetByID]", Collection);
            //    IList<clsProjectReminders> objRetList = DataUtil.ConvertToList<clsProjectReminders>(ds.Tables[0]);
            //    return objRetList;
            //}

            //catch (Exception ex)
            //{
            //    //Logger.Write(ex.Message.ToString());
            //    throw new Exception(ex.Message.ToString());
            //}
        }

        public clsProjectReminders SelectOne(clsProjectReminders objEntity)
        {
            Wraper objWrapper = null;
            IList<clsProjectReminders> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();

                ds = objWrapper.GetSQLDataSet("ProcProjectReminders_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProjectReminders>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            if (objRetList == null)
            {
                return objEntity;
            }
            else
            {
                return objRetList.First();
            }
        }


    }
}
