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
    public class CartServices : AbstractCartServices
    {
        private AbstractCartDao abstractCartDao;

        public CartServices(AbstractCartDao abstractCartDao)
        {
            this.abstractCartDao = abstractCartDao;
        }

     
        public override SuccessResult<AbstractCart> Cart_ById(int Cart_Id)
        {
            return this.abstractCartDao.Cart_ById(Cart_Id);
        }
        public override PagedList<AbstractCart> Cart_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractCartDao.Cart_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractCart> Cart_Upsert(AbstractCart abstractCart)
        {
            return this.abstractCartDao.Cart_Upsert(abstractCart);
        }
        public override SuccessResult<AbstractCart> Cart_ActInact(int Cart_Id, int Updatedby)
        {
            return this.abstractCartDao.Cart_ActInact(Cart_Id, Updatedby);
        }
        public override SuccessResult<AbstractCart> Cart_Delete(int Cart_Id, int Deletedby)
        {
            return this.abstractCartDao.Cart_Delete(Cart_Id, Deletedby);
        }

    }
}