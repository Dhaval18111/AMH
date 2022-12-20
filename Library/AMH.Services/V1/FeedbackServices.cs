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
    public class FeedbackServices : AbstractFeedbackServices
    {
        private AbstractFeedbackDao abstractFeedbackDao;

        public FeedbackServices(AbstractFeedbackDao abstractFeedbackDao)
        {
            this.abstractFeedbackDao = abstractFeedbackDao;
        }

     
        public override SuccessResult<AbstractFeedback> Feedback_ById(int Id)
        {
            return this.abstractFeedbackDao.Feedback_ById(Id);
        }
        public override PagedList<AbstractFeedback> Feedback_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            return this.abstractFeedbackDao.Feedback_All(pageParam, search, IsVisibleAll);
        }
        public override SuccessResult<AbstractFeedback> Feedback_Upsert(AbstractFeedback abstractFeedback)
        {
            return this.abstractFeedbackDao.Feedback_Upsert(abstractFeedback);
        }
        public override SuccessResult<AbstractFeedback> Feedback_ActInact(int Id, int Updatedby)
        {
            return this.abstractFeedbackDao.Feedback_ActInact(Id, Updatedby);
        }
        public override SuccessResult<AbstractFeedback> Feedback_Delete(int Id, int Deletedby)
        {
            return this.abstractFeedbackDao.Feedback_Delete(Id, Deletedby);
        }

    }
}