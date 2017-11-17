using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BussinessLayer 
{
    public partial class clsInspectionScheduleMapping : IPrcCommonMethods<clsInspectionScheduleMapping, bool, bool, IList<clsInspectionScheduleMapping>, clsInspectionScheduleMapping>
    {
        #region IPrcCommonMethods<clsInspectionScheduleMapping,bool,bool,IList<clsInspectionScheduleMapping>,clsInspectionScheduleMapping> Members


        public bool InsertUpdate(clsInspectionScheduleMapping objEntity)
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

                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionID", SqlDbType.Int, objEntity.ProjectInspectionID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEntity.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionName", SqlDbType.VarChar, objEntity.InspectionName));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionDate", SqlDbType.DateTime, objEntity.InspectionDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionResultDoc", SqlDbType.VarChar, objEntity.InspectionResultDoc)); 
                
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEntity.CreatedBy));
                Collection.Add(SQLDBParameter.CreateParameter("@pUpdatedBy", SqlDbType.Int, objEntity.UpdatedBy));
                Collection.Add(pstrError);
                blnIsSuccess = objWrapper.ExecuteSQL("ProcInspectionScheduleMapping_InsertUpdate", Collection);
                strError = pstrError.Value.ToString();
                if (strError != "")
                {
                    throw new Exception(strError);
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
                blnIsSuccess = false;
            }
            return blnIsSuccess;
        }

        public bool DeleteMultiple(clsInspectionScheduleMapping objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;
            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionIDs", SqlDbType.VarChar , objEntity.ProjectInspectionIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcInspectionScheduleMapping_DeleteMultiple", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsInspectionScheduleMapping objEntity)
        {
            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;
            try
            {
                if (objEntity == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionID", SqlDbType.Int, objEntity.ProjectInspectionID));
                blnIsSuccess = objWrapper.ExecuteSQL("ProcInspectionScheduleMapping_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsInspectionScheduleMapping> GetAllScheduleI(clsInspectionScheduleMapping objEntity)
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
                ds = objWrapper.GetSQLDataSet("ProcInspectionScheduleMapping_ListAll", Collection);
                IList<clsInspectionScheduleMapping> objRetList = DataUtil.ConvertToList<clsInspectionScheduleMapping>(ds.Tables[0]);
                return objRetList;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public IList<clsInspectionScheduleMapping> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();
                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcInspectionScheduleMapping_ListAll", Collection);
                IList<clsInspectionScheduleMapping> objRetList = DataUtil.ConvertToList<clsInspectionScheduleMapping>(ds.Tables[0]);
                return objRetList;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsInspectionScheduleMapping SelectOne(clsInspectionScheduleMapping objEntity)
        {
            Wraper objWrapper = null;
            IList<clsInspectionScheduleMapping> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEntity == null)
                    throw new ArgumentNullException("objEntity is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectInspectionID", SqlDbType.Int, objEntity.ProjectInspectionID));
                ds = objWrapper.GetSQLDataSet("ProcInspectionScheduleMapping_GetByID", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsInspectionScheduleMapping>(ds.Tables[0]);
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
