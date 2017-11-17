using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;

namespace BussinessLayer
{
    public partial class clsRebuttleMgmtMethods : IPrcCommonMethods<clsProject, int, bool, IList<clsProject>, clsProject>
    {

        #region IPrcCommonMethods<clsProject,int,bool,IList<clsProject>,clsProject> Members

        public int InsertUpdate(clsProject objEnitty)
        {
            throw new NotImplementedException();
        }

        public bool Delete(clsProject objEnitty)
        {
            throw new NotImplementedException();
        }

        public IList<clsProject> GetAll()
        {
            throw new NotImplementedException();
        }

        public clsProject SelectOne(clsProject objEnitty)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
