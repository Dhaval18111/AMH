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
    public class GalleryServices : AbstractGalleryServices
    {
        private AbstractGalleryDao abstractGalleryDao;

        public GalleryServices(AbstractGalleryDao abstractGalleryDao)
        {
            this.abstractGalleryDao = abstractGalleryDao;
        }

     
        public override SuccessResult<AbstractGallery> Gallery_ById(int Image_Id)
        {
            return this.abstractGalleryDao.Gallery_ById(Image_Id);
        }
        public override PagedList<AbstractGallery> Gallery_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractGalleryDao.Gallery_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractGallery> Gallery_Upsert(AbstractGallery abstractGallery)
        {
            return this.abstractGalleryDao.Gallery_Upsert(abstractGallery);
        }
        public override SuccessResult<AbstractGallery> Gallery_ActInact(int Image_Id, int Updatedby)
        {
            return this.abstractGalleryDao.Gallery_ActInact(Image_Id, Updatedby);
        }
        public override SuccessResult<AbstractGallery> Gallery_Delete(int Image_Id, int Deletedby)
        {
            return this.abstractGalleryDao.Gallery_Delete(Image_Id, Deletedby);
        }

    }
}