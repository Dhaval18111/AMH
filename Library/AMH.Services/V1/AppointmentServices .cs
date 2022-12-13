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
    public class AppointmentServices : AbstractAppointmentServices
    {
        private AbstractAppointmentDao abstractAppointmentDao;

        public AppointmentServices(AbstractAppointmentDao abstractAppointmentDao)
        {
            this.abstractAppointmentDao = abstractAppointmentDao;
        }
       
        public override SuccessResult<AbstractAppointment> Appointment_StatusChange(long Id,long Status)
        {
            return this.abstractAppointmentDao.Appointment_StatusChange(Id,Status);
        }
        public override SuccessResult<AbstractAppointment> Appointment_ChangeDate(long Id,string AppointmentDate)
        {
            return this.abstractAppointmentDao.Appointment_ChangeDate(Id, AppointmentDate);
        }
        public override SuccessResult<AbstractAppointment> Appointment_ById(long Id)
        {
            return this.abstractAppointmentDao.Appointment_ById(Id);
        }
        public override SuccessResult<AbstractAppointment> Appointment_Delete(long Id, long DeletedBy)
        {
            return this.abstractAppointmentDao.Appointment_Delete(Id, DeletedBy);
        }
        public override PagedList<AbstractAppointment> Appointment_All(PageParam pageParam, string search)
        {
            return this.abstractAppointmentDao.Appointment_All(pageParam, search);
        }
        public override SuccessResult<AbstractAppointment> Appointment_Upsert(AbstractAppointment abstractAppointment)
        {
            return this.abstractAppointmentDao.Appointment_Upsert(abstractAppointment);
        }
    }
    public class MasterAppointmentStatusServices : AbstractMasterAppointmentStatusServices
    {
        private AbstractMasterAppointmentStatusDao abstractMasterAppointmentStatusDao;

        public MasterAppointmentStatusServices(AbstractMasterAppointmentStatusDao abstractMasterAppointmentStatusDao)
        {
            this.abstractMasterAppointmentStatusDao = abstractMasterAppointmentStatusDao;
        }
        public override PagedList<AbstractMasterAppointmentStatus> MasterAppointmentStatus_All(PageParam pageParam, string search)
        {
            return this.abstractMasterAppointmentStatusDao.MasterAppointmentStatus_All(pageParam, search);
        }
    }
}