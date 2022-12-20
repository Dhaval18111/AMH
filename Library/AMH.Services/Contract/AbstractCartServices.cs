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
    public abstract class AbstractCartServices
    {
       
        public abstract SuccessResult<AbstractCart> Cart_ById(int Cart_Id);
        public abstract PagedList<AbstractCart> Cart_All(PageParam pageParam, string search,int IsVisibleAll);
        public abstract SuccessResult<AbstractCart> Cart_Upsert(AbstractCart abstractCart);
        public abstract SuccessResult<AbstractCart> Cart_ActInact(int Cart_Id, int Updatedby);
        public abstract SuccessResult<AbstractCart> Cart_Delete(int Cart_Id, int Deleteby);


    }
}
