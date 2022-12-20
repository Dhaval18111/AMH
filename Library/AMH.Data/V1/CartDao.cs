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
    public class CartDao : AbstractCartDao
    {

    
        public override SuccessResult<AbstractCart> Cart_Upsert(AbstractCart AbstractCart)
        {
            SuccessResult<AbstractCart> Cart = null;
            var param = new DynamicParameters();

            param.Add("@Cart_Id", AbstractCart.Cart_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Quantity", AbstractCart.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Date", AbstractCart.Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("@User_Id", AbstractCart.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Product_Id", AbstractCart.Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractCart.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractCart.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Cart_Upsert, param, commandType: CommandType.StoredProcedure);
                Cart = task.Read<SuccessResult<AbstractCart>>().SingleOrDefault();
                Cart.Item = task.Read<Cart>().SingleOrDefault();
            }

            return Cart;
        }

        public override SuccessResult<AbstractCart> Cart_ById(int Cart_Id)
        {
            SuccessResult<AbstractCart> Cart = null;
            var param = new DynamicParameters();

            param.Add("@Cart_Id",Cart_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Cart_ById, param, commandType: CommandType.StoredProcedure);
                Cart = task.Read<SuccessResult<AbstractCart>>().SingleOrDefault();
                Cart.Item = task.Read<Cart>().SingleOrDefault();
            }

            return Cart;
        }

        public override SuccessResult<AbstractCart> Cart_Delete(int Cart_Id,int Deletedby)
        {
            SuccessResult<AbstractCart> Cart = null;
            var param = new DynamicParameters();

            param.Add("@Cart_Id", Cart_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Cart_Delete, param, commandType: CommandType.StoredProcedure);
                Cart = task.Read<SuccessResult<AbstractCart>>().SingleOrDefault();
                Cart.Item = task.Read<Cart>().SingleOrDefault();
            }

            return Cart;
        }


        public override PagedList<AbstractCart> Cart_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractCart> Cart = new PagedList<AbstractCart>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Cart_All, param, commandType: CommandType.StoredProcedure);
                Cart.Values.AddRange(task.Read<Cart>());
                Cart.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Cart;
        }

        public override SuccessResult<AbstractCart> Cart_ActInact(int Cart_Id, int Updatedby)
        {
            SuccessResult<AbstractCart> Cart = null;
            var param = new DynamicParameters();

            param.Add("@Cart_Id", Cart_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Cart_ActInact, param, commandType: CommandType.StoredProcedure);
                Cart = task.Read<SuccessResult<AbstractCart>>().SingleOrDefault();
                Cart.Item = task.Read<Cart>().SingleOrDefault();
            }

            return Cart;
        }


        
    }
}
