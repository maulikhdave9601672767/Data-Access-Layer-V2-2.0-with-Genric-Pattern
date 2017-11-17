using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectMissingDoc : IPrcCommonMethods<clsProjectMissingDoc, bool, bool, IList<clsProjectMissingDoc>, clsProjectMissingDoc>
    {
        #region IPrcCommonMethods<clsProjectMissingDoc,bool,bool,IList<clsProjectMissingDoc>,clsProjectMissingDoc> Members

        public bool InsertUpdate(clsProjectMissingDoc objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pMissingDocID", SqlDbType.Int, objEnitty.MissingDocID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pDueDate", SqlDbType.DateTime, objEnitty.DueDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsSendToClient", SqlDbType.Bit, objEnitty.IsSendToClient));
                Collection.Add(SQLDBParameter.CreateParameter("@pMissingDocName", SqlDbType.VarChar, objEnitty.MissingDocName));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsReceived", SqlDbType.Bit, objEnitty.IsReceived ));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectMissingDoc_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectMissingDoc objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pMissingDocID", SqlDbType.Int, objEnitty.MissingDocID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectMissingDoc_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectMissingDoc> GetAllMissingDoc(clsProjectMissingDoc objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectMissingDoc_ListAll]", Collection);
                IList<clsProjectMissingDoc> objRetList = DataUtil.ConvertToList<clsProjectMissingDoc>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public IList<clsProjectMissingDoc> GetAllMissingDocByDueDate()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                
                ds = objWrapper.GetSQLDataSet("[ProcProjectDocumentMissingDueDate_ListAll]", Collection);
                IList<clsProjectMissingDoc> objRetList = DataUtil.ConvertToList<clsProjectMissingDoc>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsProjectMissingDoc> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProjectMissingDoc SelectOne(clsProjectMissingDoc objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsProjectMissingDoc> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pMissingDocID", SqlDbType.Int, objEnitty.MissingDocID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectMissingDoc_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProjectMissingDoc>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }
        public bool DeleteProjectMissingDocMultiple(clsProjectMissingDoc  objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectMissingDocID", SqlDbType.VarChar, objEnitty.MissingDocIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectMissingDoc_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        #endregion
    }
}
