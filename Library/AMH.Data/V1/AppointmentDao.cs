using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Data.Contract;
using AMH.Entities.Contract;
using AMH.Entities.V1;
using Dapper;

namespace AMH.Data.V1
{
    public class AppointmentDao : AbstractAppointmentDao
    {
        public override SuccessResult<AbstractAppointment> Appointment_Upsert(AbstractAppointment AbstractAppointment)
        {
            SuccessResult<AbstractAppointment> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractAppointment.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CustomerId", AbstractAppointment.CustomerId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@AssignedTo", AbstractAppointment.AssignedTo, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@ServiceName", AbstractAppointment.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Ammount", AbstractAppointment.Ammount, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Duration", AbstractAppointment.Duration, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@AppointmentDate", AbstractAppointment.AppointmentDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AppointmentTime", AbstractAppointment.AppointmentTime, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", AbstractAppointment.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", AbstractAppointment.UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_Upsert, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAppointment>>().SingleOrDefault();
                Address.Item = task.Read<Appointment>().SingleOrDefault();
            }

            return Address;
        }


        public override PagedList<AbstractAppointment> Appointment_All(PageParam pageParam, string search)
        {
            PagedList<AbstractAppointment> Address = new PagedList<AbstractAppointment>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<Appointment>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
       
        public override SuccessResult<AbstractAppointment> Appointment_ById(long Id)
        {
            SuccessResult<AbstractAppointment> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_ById, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAppointment>>().SingleOrDefault();
                Address.Item = task.Read<Appointment>().SingleOrDefault();
            }

            return Address;
        }

        public override SuccessResult<AbstractAppointment> Appointment_Delete(long Id, long DeletedBy)
        {
            SuccessResult<AbstractAppointment> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@DeletedBy", DeletedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_Delete, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAppointment>>().SingleOrDefault();
                Address.Item = task.Read<Appointment>().SingleOrDefault();
            }

            return Address;
        }

        public override SuccessResult<AbstractAppointment> Appointment_StatusChange(long Id, long Status)
        {
            SuccessResult<AbstractAppointment> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Status", Status, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_StatusChange, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAppointment>>().SingleOrDefault();
                Address.Item = task.Read<Appointment>().SingleOrDefault();
            }

            return Address;
        }
        public override SuccessResult<AbstractAppointment>Appointment_ChangeDate (long Id,string AppointmentDate)
        {
            SuccessResult<AbstractAppointment> Address = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@AppointmentDate", AppointmentDate, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Appointment_ChangeDate, param, commandType: CommandType.StoredProcedure);
                Address = task.Read<SuccessResult<AbstractAppointment>>().SingleOrDefault();
                Address.Item = task.Read<Appointment>().SingleOrDefault();
            }

            return Address;
        }
    }
    public class MasterAppointmentStatusDao : AbstractMasterAppointmentStatusDao
    {
        public override PagedList<AbstractMasterAppointmentStatus> MasterAppointmentStatus_All(PageParam pageParam, string search)
        {
            PagedList<AbstractMasterAppointmentStatus> Address = new PagedList<AbstractMasterAppointmentStatus>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterAppointmentStatus_All, param, commandType: CommandType.StoredProcedure);
                Address.Values.AddRange(task.Read<MasterAppointmentStatus>());
                Address.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Address;
        }
    }
}
