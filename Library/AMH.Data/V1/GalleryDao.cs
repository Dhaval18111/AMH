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
    public class GalleryDao : AbstractGalleryDao
    {

    
        public override SuccessResult<AbstractGallery> Gallery_Upsert(AbstractGallery AbstractGallery)
        {
            SuccessResult<AbstractGallery> Gallery = null;
            var param = new DynamicParameters();

            param.Add("@Image_Id", AbstractGallery.Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractGallery.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Product_Id", AbstractGallery.Product_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Createdby", AbstractGallery.Createdby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", AbstractGallery.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Gallery_Upsert, param, commandType: CommandType.StoredProcedure);
                Gallery = task.Read<SuccessResult<AbstractGallery>>().SingleOrDefault();
                Gallery.Item = task.Read<Gallery>().SingleOrDefault();
            }

            return Gallery;
        }

        public override SuccessResult<AbstractGallery> Gallery_ById(int Image_Id)
        {
            SuccessResult<AbstractGallery> Gallery = null;
            var param = new DynamicParameters();

            param.Add("@Image_Id",Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Gallery_ById, param, commandType: CommandType.StoredProcedure);
                Gallery = task.Read<SuccessResult<AbstractGallery>>().SingleOrDefault();
                Gallery.Item = task.Read<Gallery>().SingleOrDefault();
            }

            return Gallery;
        }

        public override SuccessResult<AbstractGallery> Gallery_Delete(int Image_Id,int Deletedby)
        {
            SuccessResult<AbstractGallery> Gallery = null;
            var param = new DynamicParameters();

            param.Add("@Image_Id", Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Deletedby", Deletedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Gallery_Delete, param, commandType: CommandType.StoredProcedure);
                Gallery = task.Read<SuccessResult<AbstractGallery>>().SingleOrDefault();
                Gallery.Item = task.Read<Gallery>().SingleOrDefault();
            }

            return Gallery;
        }


        public override PagedList<AbstractGallery> Gallery_All(PageParam pageParam, string search,int IsVisibleAll)
        {
            PagedList<AbstractGallery> Gallery = new PagedList<AbstractGallery>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsVisibleAll", IsVisibleAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Gallery_All, param, commandType: CommandType.StoredProcedure);
                Gallery.Values.AddRange(task.Read<Gallery>());
                Gallery.TotalRecords = task.Read<int>().SingleOrDefault();
            }
            return Gallery;
        }

        public override SuccessResult<AbstractGallery> Gallery_ActInact(int Image_Id, int Updatedby)
        {
            SuccessResult<AbstractGallery> Gallery = null;
            var param = new DynamicParameters();

            param.Add("@Image_Id", Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Updatedby", Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Gallery_ActInact, param, commandType: CommandType.StoredProcedure);
                Gallery = task.Read<SuccessResult<AbstractGallery>>().SingleOrDefault();
                Gallery.Item = task.Read<Gallery>().SingleOrDefault();
            }

            return Gallery;
        }


        
    }
}
