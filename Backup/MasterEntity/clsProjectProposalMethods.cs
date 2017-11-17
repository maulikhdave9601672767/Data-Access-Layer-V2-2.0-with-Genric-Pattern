using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLayer
{
    public partial class clsProjectProposal : IPrcCommonMethods<clsProjectProposal, bool, bool, IList<clsProjectProposal>, clsProjectProposal>
    {
        

        #region IPrcCommonMethods<clsProjectProposal,bool,bool,IList<clsProjectProposal>,clsProjectProposal> Members

        public bool InsertUpdate(clsProjectProposal objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectProposalID", SqlDbType.Int, objEnitty.ProjectProposalID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));                
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentName", SqlDbType.VarChar, objEnitty.DocumentName));
                Collection.Add(SQLDBParameter.CreateParameter("@pProposalFileName", SqlDbType.VarChar, objEnitty.ProposalFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pUploadType", SqlDbType.VarChar, objEnitty.UploadType));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));

                Collection.Add(SQLDBParameter.CreateParameter("@pEngineerID", SqlDbType.Int, objEnitty.EngineerID));


                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectProposal_InsertUpdate]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsProjectProposal objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectProposalID", SqlDbType.Int, objEnitty.ProjectProposalID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectProposal_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsProjectProposal> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsProjectProposal> GetAllProjectProposal(clsProjectProposal objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProjectProposal_GetAll]", Collection);
                IList<clsProjectProposal> objRetList = DataUtil.ConvertToList<clsProjectProposal>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public clsProjectProposal SelectOne(clsProjectProposal objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
