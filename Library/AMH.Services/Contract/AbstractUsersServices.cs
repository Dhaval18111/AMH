using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
namespace AMH.Services.Contract
{
    public abstract class AbstractUsersServices
    {
       
        public abstract SuccessResult<AbstractUsers> Users_ById(int Users_Id);
        public abstract PagedList<AbstractUsers> Users_All(PageParam pageParam, string search, int IsVisibleAll, string FromDate,string ToDate);
        public abstract SuccessResult<AbstractUsers> Users_Upsert(AbstractUsers abstractUsers);
        public abstract SuccessResult<AbstractUsers> Users_ActInact(int Users_Id, int Updatedby);
        public abstract SuccessResult<AbstractUsers> Users_Delete(int Users_Id, int Deletedby);


    }
}
