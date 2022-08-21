using Bitirme_Projesi_Data.Context;
using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Dto.Dtos;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        // private readonly DapperDbContext _dapperDbContext;
        public CategoryRepository(IConfiguration configuration)
        {
            //_dapperDbContext = dapperDbContext;
            _configuration = configuration;
        }

        public async Task<Category> AddCategory(CategoryDto category)
        {
            var sql = "INSERT INTO public.category(categoryname) VALUES (@categoryname)";
            var parameters = new DynamicParameters();
            parameters.Add("categoryname", category.CategoryName, DbType.String);

            AddCategoryResponse addCategory = new AddCategoryResponse();



            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
    
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, parameters);
                    var addcategory = new Category();
                    addcategory.CategoryName = category.CategoryName;

                    return addcategory;

                }
                catch (Exception ex)
                {

                    connection.Close();

                    throw new Exception("AddCategory error" + ex.Message);
                }

            }
            
        }
        public async Task<IEnumerable<Category>>  GetAll()
        {
            var sql = "SELECT * FROM public.category";

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Category>(sql);

                    return result.ToList();

                }
                catch
                {

                    connection.Close();

                    throw new Exception("GetAll error");
                }
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
           
            var sql = "UPDATE public.category SET categoryname=@categoryname WHERE categoryid=@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("categoryid", category.CategoryId, DbType.Int32);
            parameters.Add("categoryname", category.CategoryName, DbType.String);
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
               await connection.ExecuteAsync(sql,parameters);

                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, parameters);
                    var catRes = new Category();
                    catRes.CategoryName = category.CategoryName;
                    catRes.CategoryId = category.CategoryId;


                    return catRes;
                }
                catch
                {
                    connection.Close();
                    throw new Exception("UpdateCategory error");
                }


            }
            
        }

      
    }
}
