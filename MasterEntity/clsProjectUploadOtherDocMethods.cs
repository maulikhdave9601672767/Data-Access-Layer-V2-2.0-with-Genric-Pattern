using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsProjectUploadOtherDoc : IPrcCommonMethods<clsProjectUploadOtherDoc, bool, bool, IList<clsProjectUploadOtherDoc>, clsProjectUploadOtherDoc>

    {

        #region IPrcCommonMethods<clsProjectUploadOtherDoc,bool,bool,IList<clsProjectUploadOtherDoc>,clsProjectUploadOtherDoc> Members

        public bool InsertUpdate(clsProjectUploadOtherDoc objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectOtherDocID", SqlDbType.Int, objEnitty.ProjectOtherDocID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentTitle", SqlDbType.VarChar, objEnitty.DocumentTitle));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentFileName", SqlDbType.VarChar, objEnitty.DocumentFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectOtherDocument_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectUploadOtherDoc objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectOtherDocID", SqlDbType.Int, objEnitty.ProjectOtherDocID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectOtherDocument_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsProjectUploadOtherDoc> GetAllProjectOtherDoc(clsProjectUploadOtherDoc objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProjectOtherDocument_GetAll]", Collection);
                IList<clsProjectUploadOtherDoc> objRetList = DataUtil.ConvertToList<clsProjectUploadOtherDoc>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsProjectUploadOtherDoc> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectUploadOtherDoc SelectOne(clsProjectUploadOtherDoc objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
