using Bitirme_Projesi_Data.Context;
using Bitirme_Projesi_Data.Models;
using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace Bitirme_Projesi_Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly DapperDbContext _dapperDbContext;
        public UserRepository(IConfiguration configuration)
        {
            //_dapperDbContext = dapperDbContext;
            _configuration = configuration;
        }

        public async Task<AddUserResponse> AddUserAsync(User user)
        {
           
            var sql = "INSERT INTO public.users(email, password) " +
                "VALUES (@email, @password)";
            var parameters = new DynamicParameters();
            parameters.Add("email", user.Email, DbType.String);
            parameters.Add("password", user.Password, DbType.String);

          
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, parameters);

                    AddUserResponse response = new AddUserResponse();

                    response.EmailAddress = user.Email;

                    return response;

                }
                catch 
                {

                    connection.Close();
                    return null;
                }

                
            }
            





        }

        public async Task<LoginResponse> LoginUser(User user)
            
        {

            var password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var query = "SELECT email,password FROM public.users WHERE email=@email and password=@password";

            var parameters = new DynamicParameters();

            parameters.Add("email", user.Email, DbType.String);
            parameters.Add("password", password, DbType.String);


            LoginResponse response = new LoginResponse();
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(query, parameters);

                    //  bool isValidPassword = BCrypt.Net.BCrypt.Verify(oUser.Password, oUser.Password)

                    response.EmailAddress = user.Email;

                    return response;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }


            }
           
        }
    }
}
