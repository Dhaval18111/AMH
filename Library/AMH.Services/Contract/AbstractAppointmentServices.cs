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
    public abstract class AbstractAppointmentServices
    {
        public abstract SuccessResult<AbstractAppointment> Appointment_Upsert(AbstractAppointment abstractAppointment);
        public abstract PagedList<AbstractAppointment> Appointment_All(PageParam pageParam, string search);
        public abstract SuccessResult<AbstractAppointment> Appointment_ById(long Id);
        public abstract SuccessResult<AbstractAppointment> Appointment_StatusChange(long Id,long Status);
        public abstract SuccessResult<AbstractAppointment> Appointment_ChangeDate(long Id,string AppointmentDate);
        public abstract SuccessResult<AbstractAppointment> Appointment_Delete(long Id, long DeletedBy);
    }
    public abstract class AbstractMasterAppointmentStatusServices
    {
        public abstract PagedList<AbstractMasterAppointmentStatus> MasterAppointmentStatus_All(PageParam pageParam, string search);
    }

}
