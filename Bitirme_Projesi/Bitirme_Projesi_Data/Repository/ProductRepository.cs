using Bitirme_Projesi_Data.Models;
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
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly DapperDbContext _dapperDbContext;
        public ProductRepository(IConfiguration configuration)
        {
            //_dapperDbContext = dapperDbContext;
            _configuration = configuration;
        }

       

        public async Task<Product> AddProduct(ProductResponse product)
        {
            var sql = "INSERT INTO public.product(productname,explanation,categoryid,color,brand,usingstatus,image,price,offer)" +
                "VALUES (@productname,@explanation,@categoryid,@color,@brand,@usingstatus,@image,@price,@offer)";
            var parameters = new DynamicParameters();
            parameters.Add("productname", product.ProductName, DbType.String);
            parameters.Add("explanation", product.Explanation, DbType.String);
            parameters.Add("categoryid", product.CategoryId, DbType.Int32);
            parameters.Add("color", product.Color, DbType.String);
            parameters.Add("brand", product.Brand, DbType.String);
            parameters.Add("usingstatus", product.UsingStatus, DbType.Boolean);
            parameters.Add("image", product.Image, DbType.Byte);
            parameters.Add("offer", product.Offer, DbType.Boolean);
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, parameters);
                var addproduct = new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Explanation = product.Explanation,
                    CategoryId = product.CategoryId,
                    Color = product.Color,
                    Brand= product.Brand,
                    Image= product.Image,
                    Offer= product.Offer
                };
                return addproduct;

            }
        }
    }
}
