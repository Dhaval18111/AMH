using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Data.Contract;
using AMH.Entities.Contract;
using AMH.Services.Contract;

namespace AMH.Services.V1
{
    public class AdminServices : AbstractAdminServices
    {
        private AbstractAdminDao abstractAdminDao;
        public AdminServices(AbstractAdminDao abstractAdminDao)
        {
            this.abstractAdminDao = abstractAdminDao;
        }

        public override bool Admin_SignOut(long Id)
        {
            return this.abstractAdminDao.Admin_SignOut(Id);
        }
        public override SuccessResult<AbstractAdmin> Admin_SignIn(string Email, string Password)
        {
            return this.abstractAdminDao.Admin_SignIn(Email, Password);
        }
        public override SuccessResult<AbstractAdmin> Admin_ChangePassword(long Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            return this.abstractAdminDao.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
        }

        public override SuccessResult<AbstractAdmin> Admin_ById(long Id)
        {
            return this.abstractAdminDao.Admin_ById(Id);
        }
        public override PagedList<AbstractAdmin> Admin_All(PageParam pageParam, string search, string Name, string Email, string MobileNumber, long AdminTypeId, long IsActive)
        {
            return this.abstractAdminDao.Admin_All(pageParam, search, Name,Email,MobileNumber,AdminTypeId,IsActive);
        }
        public override SuccessResult<AbstractAdmin> Admin_Upsert(AbstractAdmin abstractAdmin)
        {
            return this.abstractAdminDao.Admin_Upsert(abstractAdmin);
        }
        public override SuccessResult<AbstractAdmin> Admin_ActInAct(long Id, long UpdatedBy)
        {
            return this.abstractAdminDao.Admin_ActInAct(Id, UpdatedBy);
        }

        // Admin Type
        public override PagedList<AbstractAdminType> AdminType_All(PageParam pageParam, string search)
        {
            return this.abstractAdminDao.AdminType_All(pageParam, search);
        }
    }
}