using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsProjectScopeWork : IPrcCommonMethods<clsProjectScopeWork, bool, bool, IList<clsProjectScopeWork>, clsProjectScopeWork>
    {
        #region IPrcCommonMethods<clsProjectScopeWork,int,bool,IList<clsProjectScopeWork>,clsProjectScopeWork> Members

        public bool InsertUpdate(clsProjectScopeWork objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentTitle", SqlDbType.VarChar, objEnitty.DocumentTitle ));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentFileName", SqlDbType.VarChar , objEnitty.DocumentFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectScopeWork_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectScopeWork objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectScopeID", SqlDbType.Int, objEnitty.ProjectScopeID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectScopeWork_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsProjectScopeWork> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsProjectScopeWork> GetAllScopeWork(clsProjectScopeWork objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectScopeWork_ListAll]", Collection);
                IList<clsProjectScopeWork> objRetList = DataUtil.ConvertToList<clsProjectScopeWork>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsProjectScopeWork SelectOne(clsProjectScopeWork objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
