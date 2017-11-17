using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectInspectionMapping : IPrcCommonMethods<clsProjectInspectionMapping, bool, bool, IList<clsProjectInspectionMapping>, clsProjectInspectionMapping>
    {
        #region IPrcCommonMethods<clsProjectInspectionMapping,bool,bool,IList<clsProjectInspectionMapping>,clsProjectInspectionMapping> Members

        public bool InsertUpdate(clsProjectInspectionMapping objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pGeneratedInspectionID", SqlDbType.Int, objEnitty.GeneratedInspectionID));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionTypeID", SqlDbType.Int, objEnitty.InspectionTypeID));
                Collection.Add(SQLDBParameter.CreateParameter("@pPriceTag", SqlDbType.NVarChar, objEnitty.PriceTag));
                Collection.Add(SQLDBParameter.CreateParameter("@pPriceValue", SqlDbType.VarChar, objEnitty.PriceValue ));
                Collection.Add(SQLDBParameter.CreateParameter("@pCustomUpload", SqlDbType.VarChar, objEnitty.CustomUpload));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectInspectionMaster_Save]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public bool SaveGeneratedInspection(clsProjectInspectionMapping objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pGeneratedInspectionID", SqlDbType.Int, objEnitty.GeneratedInspectionID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pFileName", SqlDbType.NVarChar, objEnitty.GeneratedFileName));
                
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcGeneratedInspection_AddEdit]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        //Added by Vijay 23 March 2012
        public int SaveGeneratedInspectionInt(clsProjectInspectionMapping objEnitty)
        {
            Wraper objWrapper = null;
            int GeneratedInspectionID = 0;
            List<SqlParameter> Collection = null;


            try
            {
                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pGeneratedInspectionID", SqlDbType.Int, objEnitty.GeneratedInspectionID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pFileName", SqlDbType.NVarChar, objEnitty.GeneratedFileName));
                
                DataSet ds = objWrapper.GetSQLDataSet("[ProcGeneratedInspection_AddEdit]", Collection);
                if (ds != null)
                {
                    GeneratedInspectionID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return GeneratedInspectionID;
        }

        public DataSet GetMappedInspection(clsProjectInspectionMapping objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                ds = objWrapper.GetSQLDataSet("[ProcProjectInspection_GetMapped]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return ds;
        }
        public IList<clsProjectInspectionMapping> GetAllGeneratedInspections(clsProjectInspectionMapping objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                ds = objWrapper.GetSQLDataSet("[ProcGeneratedInspection_ListAll]", Collection);
                IList<clsProjectInspectionMapping> objRetList = DataUtil.ConvertToList<clsProjectInspectionMapping>(ds.Tables[0]);
                return objRetList;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            
        }
        public bool Delete(clsProjectInspectionMapping objEnitty)
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
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectInspectionMapping_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public bool DeleteGeneratedInvoice(clsProjectInspectionMapping objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pGeneratedInspectionID", SqlDbType.Int, objEnitty.GeneratedInspectionID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcGeneratedInspection_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectInspectionMapping> GetAll()
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcInspectionMaster_ListAll", Collection);
                IList<clsProjectInspectionMapping> objRetList = DataUtil.ConvertToList<clsProjectInspectionMapping>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool SaveInspectionMaster(clsProjectInspectionMapping objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionTypeID", SqlDbType.Int, objEnitty.InspectionTypeID ));
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionTypeName", SqlDbType.VarChar, objEnitty.InspectionTypeName));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProcInspectionMaster_AddEdit]", Collection);
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public bool DeleteInspection(clsProjectInspectionMapping objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pInspectionTypeID", SqlDbType.Int, objEnitty.InspectionTypeID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcInspectionMaster_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public clsProjectInspectionMapping SelectOne(clsProjectInspectionMapping objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
