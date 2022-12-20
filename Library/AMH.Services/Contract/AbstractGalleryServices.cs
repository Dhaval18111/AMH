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
    public abstract class AbstractGalleryServices
    {
       
        public abstract SuccessResult<AbstractGallery> Gallery_ById(int Image_Id);
        public abstract PagedList<AbstractGallery> Gallery_All(PageParam pageParam, string search,int IsVisibleAll);
        public abstract SuccessResult<AbstractGallery> Gallery_Upsert(AbstractGallery abstractGallery);
        public abstract SuccessResult<AbstractGallery> Gallery_ActInact(int Image_Id, int Updatedby);
        public abstract SuccessResult<AbstractGallery> Gallery_Delete(int Image_Id, int Deleteby);


    }
}
