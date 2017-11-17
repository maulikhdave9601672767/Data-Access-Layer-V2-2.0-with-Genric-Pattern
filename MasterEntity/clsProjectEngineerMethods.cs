using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer;


namespace BussinessLayer
{
    public partial class clsProjectEngineer : IPrcCommonMethods<clsProjectEngineer, string, bool, IList<clsProjectEngineer>, clsProjectEngineer> //: IPrcCommonMethods<clsProjectEngineer, bool, bool, IList<clsProjectEngineer>, clsProjectEngineer>
    {
        public string InsertUpdate(clsProjectEngineer objEnitty)
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
                pstrError.Size = 250;
                pstrError.ParameterName = "@pstrError";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerID", SqlDbType.Int, objEnitty.ProjectEngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.VarChar, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.VarChar, objEnitty.EngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerCost", SqlDbType.VarChar, objEnitty.EngineerCost));
                //Collection.Add(SQLDBParameter.CreateParameter("@pOurPaymentTerms", SqlDbType.VarChar, objEnitty.OurPaymentTerms));
                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerPaymentTerms", SqlDbType.VarChar, objEnitty.EngineerPaymentTerms));
                //Collection.Add(SQLDBParameter.CreateParameter("@pIsWon", SqlDbType.VarChar, objEnitty.IsWon ));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Bit, objEnitty.CreatedBy));

                Collection.Add(pstrError);

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectEngineer_Save]", Collection);
                strRet = pstrError.Value.ToString();

                return strRet;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }

        }

        public bool DeleteMultiple(clsProjectEngineer objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerIDs", SqlDbType.VarChar, objEntity.ProjectEngineerIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectEngineer_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectEngineer objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerID", SqlDbType.Int, objEntity.ProjectEngineerID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectEngineer_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public bool ChangeStatus(clsProjectEngineer objEntity)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerID", SqlDbType.Int, objEntity.ProjectEngineerID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsWon", SqlDbType.VarChar, objEntity.IsWon));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectEngineer_ChangeStatus]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectEngineer> GetAll()
        {
            throw new NotImplementedException();
            
        }
        public IList<clsProjectEngineer> GetAllEngineerList(clsProjectEngineer objEntity)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();
                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectEngineer_ListAll]", Collection);
                IList<clsProjectEngineer> objRetList = DataUtil.ConvertToList<clsProjectEngineer>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsProjectEngineer SelectOne(clsProjectEngineer objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsProjectEngineer> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectEngineerID", SqlDbType.Int, objEnitty.ProjectEngineerID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectEngineer_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProjectEngineer>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        

    }
}
