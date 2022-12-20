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
    public class UsersServices : AbstractUsersServices
    {
        private AbstractUsersDao abstractUsersDao;

        public UsersServices(AbstractUsersDao abstractUsersDao)
        {
            this.abstractUsersDao = abstractUsersDao;
        }

     
        public override SuccessResult<AbstractUsers> Users_ById(int Users_Id)
        {
            return this.abstractUsersDao.Users_ById(Users_Id);
        }
        public override PagedList<AbstractUsers> Users_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractUsersDao.Users_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractUsers> Users_Upsert(AbstractUsers abstractUsers)
        {
            return this.abstractUsersDao.Users_Upsert(abstractUsers);
        }
        public override SuccessResult<AbstractUsers> Users_ActInact(int Users_Id, int Updatedby)
        {
            return this.abstractUsersDao.Users_ActInact(Users_Id, Updatedby);
        }
        public override SuccessResult<AbstractUsers> Users_Delete(int Users_Id, int Deletedby)
        {
            return this.abstractUsersDao.Users_Delete(Users_Id, Deletedby);
        }

    }
}