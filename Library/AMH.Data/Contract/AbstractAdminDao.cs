using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;

namespace AMH.Data.Contract
{
    public abstract class  AbstractAdminDao: AbstractBaseDao

    {
        public abstract bool Admin_SignOut(long Id);
        public abstract SuccessResult<AbstractAdmin> Admin_ChangePassword(long Id, string OldPassword, string NewPassword, string ConfirmPassword);
        public abstract SuccessResult<AbstractAdmin>Admin_SignIn (string Email, string Password);
        public abstract SuccessResult<AbstractAdmin> Admin_Upsert(AbstractAdmin abstractAdmin);
        public abstract SuccessResult<AbstractAdmin> Admin_ById(long Id);
        public abstract SuccessResult<AbstractAdmin> Admin_ActInAct(long Id, long UpdatedBy);
        public abstract PagedList<AbstractAdmin> Admin_All(PageParam pageParam, string Search,string Name,string Email,string MobileNumber,long AdminTypeId,long IsActive);
        public abstract PagedList<AbstractAdminType> AdminType_All(PageParam pageParam, string Search);
    }
}
