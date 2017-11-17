using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BussinessLayer;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer;

namespace BussinessLayer
{
    public partial class clsProject : IPrcCommonMethods<clsProject, int, bool, IList<clsProject>, clsProject>
    {
        public int InsertUpdate(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;

            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            SqlParameter pstrProjectID = null;
            string strError = "";
            int intProjectID = 0;
            try
            {
                pstrError = new SqlParameter();

                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.Size = 250;
                pstrError.ParameterName = "@pstrError";

                pstrProjectID = new SqlParameter();
                pstrProjectID.Direction = ParameterDirection.Output;
                //pstrProjectID.Value = "";
                pstrProjectID.SqlDbType = SqlDbType.Int;
                pstrProjectID.ParameterName = "@pOutProjectID";


                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pOurPONo", SqlDbType.VarChar, objEnitty.OurPONo));

                Collection.Add(SQLDBParameter.CreateParameter("@pJobName", SqlDbType.VarChar, objEnitty.JobName));
                Collection.Add(SQLDBParameter.CreateParameter("@pJobAddress", SqlDbType.VarChar, objEnitty.Address));
                Collection.Add(SQLDBParameter.CreateParameter("@pJobCity", SqlDbType.VarChar, objEnitty.JobCity));
                Collection.Add(SQLDBParameter.CreateParameter("@pJobState", SqlDbType.VarChar, objEnitty.JobState));
                Collection.Add(SQLDBParameter.CreateParameter("@pJobZip", SqlDbType.VarChar, objEnitty.JobZip));
                Collection.Add(SQLDBParameter.CreateParameter("@pJobFloor", SqlDbType.VarChar, objEnitty.JobFloor));
                Collection.Add(SQLDBParameter.CreateParameter("@pOurPaymentTerms", SqlDbType.Int, objEnitty.OurPaymentTerms));
                
                Collection.Add(SQLDBParameter.CreateParameter("@pPODate", SqlDbType.DateTime, objEnitty.PODate));
                Collection.Add(SQLDBParameter.CreateParameter("@pStartDate", SqlDbType.DateTime, objEnitty.StartDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pReminders", SqlDbType.Int, objEnitty.Reminders));

                Collection.Add(SQLDBParameter.CreateParameter("@pStartBill", SqlDbType.Bit, objEnitty.StartBill));
                Collection.Add(SQLDBParameter.CreateParameter("@pIsClosed", SqlDbType.Bit, objEnitty.IsClosed));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectCloseDate", SqlDbType.DateTime, objEnitty.ProjectCloseDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pAdditionalInformation", SqlDbType.VarChar, objEnitty.AdditionalInformation));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                Collection.Add(SQLDBParameter.CreateParameter("@xmldoc", SqlDbType.VarChar, objEnitty.xmldoc));
                Collection.Add(SQLDBParameter.CreateParameter("@xmldocCont", SqlDbType.VarChar, objEnitty.xmldocCont));
                Collection.Add(SQLDBParameter.CreateParameter("@xmldocInt", SqlDbType.VarChar, objEnitty.xmldocInt));

                Collection.Add(pstrProjectID);
                Collection.Add(pstrError);
                

                blnIsSuccess = objWrapper.ExecuteSQL("ProcProject_Save", Collection);
                strError = pstrError.Value.ToString();
                intProjectID = Convert.ToInt32(pstrProjectID.Value.ToString());

                if (strError != "")
                {
                    throw new Exception(strError);
                }

            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return intProjectID;
        }

        public bool Delete(clsProject objEnitty)
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
                blnIsSuccess = objWrapper.ExecuteSQL("ProcProjectMaster_Delete", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public int MapContractor(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;
            SqlParameter pstrError = null;
            SqlParameter pstrProjectContractorID = null;
            int intProjectContractorID = 0;
            string strError = "";
            try
            {
                pstrError = new SqlParameter();
                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";

                pstrProjectContractorID = new SqlParameter();
                pstrProjectContractorID.Direction = ParameterDirection.Output;
                pstrProjectContractorID.Value = "";
                pstrProjectContractorID.SqlDbType = SqlDbType.Int;
                pstrProjectContractorID.ParameterName = "@pProjectContractorID";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEnitty.ContractorID));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(pstrError);
                Collection.Add(pstrProjectContractorID);
                blnIsSuccess = objWrapper.ExecuteSQL("ProcContractorProjectMapping", Collection);
                strError = pstrError.Value.ToString();
                intProjectContractorID = Convert.ToInt32(pstrProjectContractorID.Value.ToString());
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return intProjectContractorID;
        }
        public int MapClient(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;
            SqlParameter pstrError = null;
            SqlParameter pstrProjectClientID = null;
            int intProjectClientID = 0;
            string strError = "";
            try
            {
                pstrError = new SqlParameter();
                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";

                pstrProjectClientID = new SqlParameter();
                pstrProjectClientID.Direction = ParameterDirection.Output;
                pstrProjectClientID.Value = "";
                pstrProjectClientID.SqlDbType = SqlDbType.Int;
                pstrProjectClientID.ParameterName = "@pProjectClientID";

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEnitty.ClientID));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));
                Collection.Add(pstrError);
                Collection.Add(pstrProjectClientID);


                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClientProjectMapping]", Collection);
                strError = pstrError.Value.ToString();
                intProjectClientID = Convert.ToInt32(pstrProjectClientID.Value.ToString());
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return intProjectClientID;
        }

        public bool DeleteContractorMapping(clsProject objEnitty)
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
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcContractorProjectDeleteMapping]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public bool DeleteClientMapping(clsProject objEnitty)
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
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcClientProjectDeleteMapping]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public IList<clsProject> GetAll()
        {
            throw new Exception();
        }

        public IList<clsProject> ListAll(clsProject objEnitty)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pUserId", SqlDbType.Int, objEnitty.UserID));
                Collection.Add(SQLDBParameter.CreateParameter("@pUType", SqlDbType.VarChar, objEnitty.UserType));
                objWrapper = new Wraper();
                ds = objWrapper.GetSQLDataSet("ProcProjectMaster_ListAll", Collection);
                IList<clsProject> objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsProject SelectOne(clsProject objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsProject> objRetList = null;
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectMaster_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }

        public DataSet GetMappedContractor(clsProject objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[GetProjectContractorMapping]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return ds;
        }

        public DataSet GetMappedClient(clsProject objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[GetProjectClientMapping]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return ds;
        }
        public bool MappedClientDetails_InsertUpdate(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;

            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            SqlParameter pstrProjectID = null;
            string strError = "";

            try
            {
                pstrError = new SqlParameter();

                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";



                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pClientID", SqlDbType.Int, objEnitty.ClientID));

                Collection.Add(SQLDBParameter.CreateParameter("@pGCClientContact1", SqlDbType.VarChar, objEnitty.GCClientContact1));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCClientContact2", SqlDbType.VarChar, objEnitty.GCClientContact2));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCAddress", SqlDbType.VarChar, objEnitty.GCAddress));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCCity", SqlDbType.VarChar, objEnitty.GCCity));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCState", SqlDbType.VarChar, objEnitty.GCState));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCZip", SqlDbType.VarChar, objEnitty.GCZip));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCPhone", SqlDbType.VarChar, objEnitty.GCPhone));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCEmail", SqlDbType.VarChar, objEnitty.GCEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                Collection.Add(pstrError);


                blnIsSuccess = objWrapper.ExecuteSQL("[ProcMappedClient_InsertUpdate]", Collection);
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
            }
            return blnIsSuccess;
        }
        public bool MappedContractorDetails_InsertUpdate(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;

            List<SqlParameter> Collection = null;

            SqlParameter pstrError = null;
            SqlParameter pstrProjectID = null;
            string strError = "";

            try
            {
                pstrError = new SqlParameter();

                pstrError.Direction = ParameterDirection.Output;
                pstrError.Value = "";
                pstrError.SqlDbType = SqlDbType.VarChar;
                pstrError.ParameterName = "@pstrError";



                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pContractorID", SqlDbType.Int, objEnitty.ContractorID));

                Collection.Add(SQLDBParameter.CreateParameter("@pGCContractorContact1", SqlDbType.VarChar, objEnitty.GCContractorContact1));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCContractorContact2", SqlDbType.VarChar, objEnitty.GCContractorContact2));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCAddress", SqlDbType.VarChar, objEnitty.GCAddress));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCCity", SqlDbType.VarChar, objEnitty.GCCity));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCState", SqlDbType.VarChar, objEnitty.GCState));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCZip", SqlDbType.VarChar, objEnitty.GCZip));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCPhone", SqlDbType.VarChar, objEnitty.GCPhone));
                Collection.Add(SQLDBParameter.CreateParameter("@pGCEmail", SqlDbType.VarChar, objEnitty.GCEmail));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                Collection.Add(pstrError);


                blnIsSuccess = objWrapper.ExecuteSQL("[ProcMappedContractor_InsertUpdate]", Collection);
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
            }
            return blnIsSuccess;
        }
        public bool SaveProjectRebuttle(clsProject objEnitty)
        {

            Wraper objWrapper = null;
            bool blnIsSuccess = false;
            List<SqlParameter> Collection = null;
            SqlParameter pstrError = null;

            try
            {
                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is never Null");

                objWrapper = new Wraper();
                Collection = new List<SqlParameter>();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectRebuttleMgmtID", SqlDbType.Int, objEnitty.ProjectRebuttleMgmtID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pRebuttleStatus", SqlDbType.VarChar, objEnitty.RebuttleStatus));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectRebuttle_Save]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProject> GetProjectRebuttle(clsProject objEntity)
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
                ds = objWrapper.GetSQLDataSet("[ProcProjectRebuttle_ListAll]", Collection);
                IList<clsProject> objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public DataSet GetProjects_Search(clsProject objEntity)
        {

            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pSearchText", SqlDbType.VarChar, objEntity.SearchText));
                Collection.Add(SQLDBParameter.CreateParameter("@pFromPODate", SqlDbType.VarChar, objEntity.FromPODate));
                Collection.Add(SQLDBParameter.CreateParameter("@pToPODate", SqlDbType.VarChar, objEntity.ToPODate ));
                Collection.Add(SQLDBParameter.CreateParameter("@pFromStartDate", SqlDbType.VarChar, objEntity.FromStartDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pToStartDate", SqlDbType.VarChar, objEntity.ToStartDate ));
                
                Collection.Add(SQLDBParameter.CreateParameter("@pUserId", SqlDbType.Int, objEntity.UserID));
                Collection.Add(SQLDBParameter.CreateParameter("@pUType", SqlDbType.VarChar, objEntity.UserType));

                ds = objWrapper.GetSQLDataSet("[ProcProjectMaster_Search]", Collection);
                //IList<clsProject> objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);
                return ds;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public clsProject SelectOneProjectRebuttle(clsProject objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsProject> objRetList = null;
            DataSet ds = null;
            List<SqlParameter> Collection = null;
            try
            {

                if (objEnitty == null)
                    throw new ArgumentNullException("objEnitty is Never Null");
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectRebuttleMgmtID", SqlDbType.Int, objEnitty.ProjectRebuttleMgmtID));
                ds = objWrapper.GetSQLDataSet("[ProcGetProjectRebuttle_GetByID]", Collection);
                if (ds.Tables.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);

                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return objRetList.First();
        }
        public DataSet GetUploadedDocument(clsProject objEnitty)
        {
            Wraper objWrapper = null;
            IList<clsProject> objRetList = null;
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
                ds = objWrapper.GetSQLDataSet("[GetUpload]", Collection);
            }
            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return ds;
        }
        public bool DeleteProjectRebuttle(clsProject objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectRebuttleMgmtID", SqlDbType.Int, objEnitty.ProjectRebuttleMgmtID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectRebuttle_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;

        }
        public bool DeleteProjectRebuttleMultiple(clsProject objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectRebuttleMgmtIDs", SqlDbType.VarChar, objEnitty.ProjectRebuttleMgmtIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectRebuttle_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }
        public DataSet GetAllInventoryReport(clsProject objEntity)
        {
            Wraper objWrapper = null;

            DataSet ds = null;
            DataSet dsRet = null;
            List<SqlParameter> Collection = null;
            try
            {
                ds = new DataSet();
                dsRet = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pFromDate", SqlDbType.VarChar, objEntity.FromDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pToDate", SqlDbType.VarChar,objEntity.ToDate ));
                ds = objWrapper.GetSQLDataSet("[ProjectInventoryReport]", Collection);

                //DataTable dtYear = ds.Tables[0].DefaultView.ToTable(true, "JobName");
                //dtYear.TableName = "JobName";
                //dsRet.Tables.Add(dtYear);

                //DataTable dtDetails = ds.Tables[0].DefaultView.ToTable();
                //dtDetails.TableName = "dtDetails";
                //dsRet.Tables.Add(dtDetails);

                return ds;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeleteMultiple(clsProject objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectIDs", SqlDbType.VarChar, objEnitty.ProjectIDs));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProcProjectMaster_DeleteMultiple]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public clsProject GetClientDetails(clsProject objEntity)
        {

            Wraper objWrapper = null;

            DataSet ds = null;
            List<SqlParameter> Collection = null;
            IList<clsProject> objRetList = null;
            try
            {
                ds = new DataSet();
                Collection = new List<SqlParameter>();

                objWrapper = new Wraper();
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.VarChar, objEntity.ProjectID));
                ds = objWrapper.GetSQLDataSet("[GetClientDetailsByProjectID]", Collection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objRetList = DataUtil.ConvertToList<clsProject>(ds.Tables[0]);
                }
                else {
                    objEntity.strError = "No Client Assigned to Project. Please Assign Client to Project";
                    return objEntity;
                }
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
              
                  throw new Exception(ex.Message.ToString());
                 
            }
            return objRetList.First();
        }

        #region IPrcCommonMethods<clsProject,bool,bool,IList<clsProject>,clsProject> Members



        #endregion
    }
}
