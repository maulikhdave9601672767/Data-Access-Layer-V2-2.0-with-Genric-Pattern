using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectSignOn : IPrcCommonMethods<clsProjectSignOn, bool, bool, IList<clsProjectSignOn>, clsProjectSignOn>
    {

        #region IPrcCommonMethods<clsProjectSignOn,bool,bool,IList<clsProjectSignOn>,clsProjectSignOn> Members

        public bool InsertUpdate(clsProjectSignOn objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectSignOnID", SqlDbType.Int, objEnitty.ProjectSignOnID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentTitle", SqlDbType.VarChar, objEnitty.DocumentTitle));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentFileName", SqlDbType.VarChar, objEnitty.DocumentFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectSignOn_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectSignOn objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectSignOnID", SqlDbType.Int, objEnitty.ProjectSignOnID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectSignOn_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsProjectSignOn> GetAllSignOnWork(clsProjectSignOn objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProjectSignOn_GetAll]", Collection);
                IList<clsProjectSignOn> objRetList = DataUtil.ConvertToList<clsProjectSignOn>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsProjectSignOn> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectSignOn SelectOne(clsProjectSignOn objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
