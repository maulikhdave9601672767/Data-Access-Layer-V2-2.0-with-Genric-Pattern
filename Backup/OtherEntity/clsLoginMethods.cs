using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer
{
    public partial class clsLogin : IPrcCommonMethods<clsLogin, bool, bool, IList<clsLogin>, clsLogin>
    {
        #region IPrcCommonMethods<clsLogin,bool,bool,IList<clsLogin>,clsLogin> Members

        public IList<clsLogin> Login(clsLogin objEntity)
        {
            Wraper objWrapper = null;

            IList<clsLogin> objRetList = null;
            List<SqlParameter> Collection = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pEMail", SqlDbType.VarChar, objEntity.EMail));
                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEntity.Password));
                ds = objWrapper.GetSQLDataSet("sp_Login", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsLogin>(ds.Tables[0]);

                }

            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList;
        }


        public bool InsertUpdate(clsLogin objEnitty)
        {
            return true;
        }

        public string Save(clsLogin objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            string strRet = "";
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
                    throw new ArgumentNullException("objEntity is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pLoginId", SqlDbType.Int, objEntity.loginId));
                Collection.Add(SQLDBParameter.CreateParameter("@pFName", SqlDbType.VarChar, objEntity.FName));
                Collection.Add(SQLDBParameter.CreateParameter("@pLName", SqlDbType.VarChar, objEntity.LName));
                Collection.Add(SQLDBParameter.CreateParameter("@pEMail", SqlDbType.VarChar, objEntity.EMail));
                Collection.Add(SQLDBParameter.CreateParameter("@pPassword", SqlDbType.VarChar, objEntity.Password));
                 
                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcLogin_Save]", Collection);
                strRet = pstrError.Value.ToString();
                return strRet;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return strRet;
        }



        public bool Delete(clsLogin objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pLoginId", SqlDbType.Int, objEntity.loginId));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcLogin_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsLogin objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pLoginIDs", SqlDbType.VarChar, objEntity.loginIds));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcLogin_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        
        public IList<clsLogin> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();
                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcLogin_ListAll", Collection);
                IList<clsLogin> objRetList = DataUtil.ConvertToList<clsLogin>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion



        #region IPrcCommonMethods<clsLogin,bool,bool,IList<clsLogin>,clsLogin> Members


        IList<clsLogin> IPrcCommonMethods<clsLogin, bool, bool, IList<clsLogin>, clsLogin>.GetAll()
        {
            throw new NotImplementedException();
        }

        public clsLogin SelectOne(clsLogin objEntity)
        {
            Wraper objWrapper = null;
            IList<clsLogin> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pLoginID", SqlDbType.Int, objEntity.loginId));
                ds = objWrapper.GetSQLDataSet("ProcLogin_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsLogin>(ds.Tables[0]);
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
