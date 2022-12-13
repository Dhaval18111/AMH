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
    public class AdminDao : AbstractAdminDao
    {

        public override bool Admin_SignOut(long Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Admin_SignOut, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }
            return result;

        }
        public override SuccessResult<AbstractAdmin> Admin_SignIn(string Email, string Password)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_SignIn, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }
        public override SuccessResult<AbstractAdmin> Admin_ChangePassword(long Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@OldPassword", OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@NewPassword", NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ConfirmPassword", ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ChangePassword, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }
        public override SuccessResult<AbstractAdmin> Admin_Upsert(AbstractAdmin AbstractAdmin)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractAdmin.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractAdmin.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractAdmin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", AbstractAdmin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MobileNumber", AbstractAdmin.MobileNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Gender", AbstractAdmin.Gender, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@AdminTypeId", AbstractAdmin.AdminTypeId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", AbstractAdmin.CreatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", AbstractAdmin.UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_Upsert, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_ById(long Id)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ById, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }
        public override PagedList<AbstractAdmin> Admin_All(PageParam pageParam, string search, string Name, string Email, string MobileNumber, long AdminTypeId, long IsActive)
        {
            PagedList<AbstractAdmin> Admin = new PagedList<AbstractAdmin>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Name", Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MobileNumber", MobileNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AdminTypeId", AdminTypeId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@IsActive", IsActive, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_All, param, commandType: CommandType.StoredProcedure);
                Admin.Values.AddRange(task.Read<Admin>());
                Admin.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return Admin;
        }

        public override SuccessResult<AbstractAdmin> Admin_ActInAct(long Id, long UpdatedBy)
        {
            SuccessResult<AbstractAdmin> Admin = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@UpdatedBy", UpdatedBy, dbType: DbType.Int64, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Admin_ActInAct, param, commandType: CommandType.StoredProcedure);
                Admin = task.Read<SuccessResult<AbstractAdmin>>().SingleOrDefault();
                Admin.Item = task.Read<Admin>().SingleOrDefault();
            }

            return Admin;
        }

        // Admin Type

        public override PagedList<AbstractAdminType> AdminType_All(PageParam pageParam, string search)
        {
            PagedList<AbstractAdminType> AdminType = new PagedList<AbstractAdminType>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int64, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.AdminType_All, param, commandType: CommandType.StoredProcedure);
                AdminType.Values.AddRange(task.Read<AdminType>());
                AdminType.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return AdminType;
        }
    }
}
