using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsProjectUploadInspection : IPrcCommonMethods<clsProjectUploadInspection, bool, bool, IList<clsProjectUploadInspection>, clsProjectUploadInspection>
    {

        #region IPrcCommonMethods<clsProjectUploadInspection,bool,bool,IList<clsProjectUploadInspection>,clsProjectUploadInspection> Members

        public bool InsertUpdate(clsProjectUploadInspection objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionID", SqlDbType.Int, objEnitty.ProjectInspectionID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionDate", SqlDbType.DateTime, objEnitty.InspectionDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentTitle", SqlDbType.VarChar, objEnitty.DocumentTitle));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentFileName", SqlDbType.VarChar, objEnitty.DocumentFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectInspection_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectUploadInspection objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionID", SqlDbType.Int, objEnitty.ProjectInspectionID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectInspection_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsProjectUploadInspection> GetAllInspectionWork(clsProjectUploadInspection objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProjectInspection_GetAll]", Collection);
                IList<clsProjectUploadInspection> objRetList = DataUtil.ConvertToList<clsProjectUploadInspection>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsProjectUploadInspection> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectUploadInspection SelectOne(clsProjectUploadInspection objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
