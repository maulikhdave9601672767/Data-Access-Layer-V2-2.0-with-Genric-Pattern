using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data;
namespace BussinessLayer
{
    public partial class clsOurProposal : IPrcCommonMethods<clsOurProposal, bool, bool, IList<clsOurProposal>, clsOurProposal>
    {
        #region IPrcCommonMethods<clsOurProposal,bool,bool,IList<clsOurProposal>,clsOurProposal> Members

        public bool InsertUpdate(clsOurProposal objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectOurProposalID", SqlDbType.Int, objEnitty.ProjectOurProposalID));
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectID", SqlDbType.Int, objEnitty.ProjectID));
                Collection.Add(SQLDBParameter.CreateParameter("@pReceiveDate", SqlDbType.DateTime, objEnitty.ReceiveDate));
                Collection.Add(SQLDBParameter.CreateParameter("@pDocumentName", SqlDbType.VarChar, objEnitty.DocumentName));
                Collection.Add(SQLDBParameter.CreateParameter("@pOurProposalFileName", SqlDbType.VarChar, objEnitty.OurProposalFileName));
                Collection.Add(SQLDBParameter.CreateParameter("@pUploadType", SqlDbType.VarChar, objEnitty.UploadType));
                Collection.Add(SQLDBParameter.CreateParameter("@pCreatedBy", SqlDbType.Int, objEnitty.CreatedBy));



                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectOurProposal_InsertUpdate]", Collection);


            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public bool Delete(clsOurProposal objEnitty)
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
                Collection.Add(SQLDBParameter.CreateParameter("@pProjectOurProposalID", SqlDbType.Int, objEnitty.ProjectOurProposalID));
                blnIsSuccess = objWrapper.ExecuteSQL("[ProjectOurProposal_Delete]", Collection);
            }
            catch (Exception ex)
            {
                // Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
            return blnIsSuccess;
        }

        public IList<clsOurProposal> GetAll()
        {
            throw new NotImplementedException();
        }
        public IList<clsOurProposal> GetAllProjectOurProposal(clsOurProposal objEnitty)
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
                ds = objWrapper.GetSQLDataSet("[ProjectOurProposal_GetAll]", Collection);
                IList<clsOurProposal> objRetList = DataUtil.ConvertToList<clsOurProposal>(ds.Tables[0]);
                return objRetList;
            }

            catch (Exception ex)
            {
                //Logger.Write(ex.Message.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }
        public clsOurProposal SelectOne(clsOurProposal objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPrcCommonMethods<clsOurProposal,bool,bool,IList<clsOurProposal>,clsOurProposal> Members

        bool IPrcCommonMethods<clsOurProposal, bool, bool, IList<clsOurProposal>, clsOurProposal>.InsertUpdate(clsOurProposal objEnitty)
        {
            throw new NotImplementedException();
        }

        bool IPrcCommonMethods<clsOurProposal, bool, bool, IList<clsOurProposal>, clsOurProposal>.Delete(clsOurProposal objEnitty)
        {
            throw new NotImplementedException();
        }

        IList<clsOurProposal> IPrcCommonMethods<clsOurProposal, bool, bool, IList<clsOurProposal>, clsOurProposal>.GetAll()
        {
            throw new NotImplementedException();
        }

        clsOurProposal IPrcCommonMethods<clsOurProposal, bool, bool, IList<clsOurProposal>, clsOurProposal>.SelectOne(clsOurProposal objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
