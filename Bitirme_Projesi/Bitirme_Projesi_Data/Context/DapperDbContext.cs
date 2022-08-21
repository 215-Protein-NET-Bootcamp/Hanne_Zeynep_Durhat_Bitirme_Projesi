using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.Context
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly string databaseType;
        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            databaseType = configuration.GetConnectionString("DbType");
            connectionString = GetConnectionString();
        }
        private string GetConnectionString()
        {
            switch (databaseType)
            {
                case "SQL":
                    return this.configuration.GetConnectionString("DefaultConnection");
                case "PostgreSQL":
                    return this.configuration.GetConnectionString("PostgreSqlConnection");
                default:
                    return this.configuration.GetConnectionString("DefaultConnection");
            }
        }
        public IDbConnection CreateConnection()
        {




            switch (databaseType)
            {
                case "SQL":
                    return new SqlConnection(connectionString);
                case "PostgreSQL":
                    return new NpgsqlConnection(connectionString);
                default:
                    return new SqlConnection(connectionString);
            }
        }
    }
}
