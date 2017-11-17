using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectDrawing : IPrcCommonMethods<clsProjectDrawing, bool, bool, IList<clsProjectDrawing>, clsProjectDrawing>
    {
        #region IPrcCommonMethods<clsProjectDrawing,bool,bool,IList<clsProjectDrawing>,clsProjectDrawing> Members

        public bool InsertUpdate(clsProjectDrawing objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDrawingName", SqlDbType.VarChar, objEnitty.DrawingName ));
                Collection.Add(SQLDBParameter.CreateParameter("@pDrawingFileName", SqlDbType.VarChar, objEnitty.DrawingFileName ));
                Collection.Add(SQLDBParameter.CreateParameter("@pUploadType", SqlDbType.VarChar, objEnitty.UploadType));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectDrawing_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectDrawing objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectDrawingID", SqlDbType.Int, objEnitty.ProjectDrawingID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectDrawing_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectDrawing> GetAllDrawing(clsProjectDrawing objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectDrawing_ListAll]", Collection);
                IList<clsProjectDrawing> objRetList = DataUtil.ConvertToList<clsProjectDrawing>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsProjectDrawing> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectDrawing SelectOne(clsProjectDrawing objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
