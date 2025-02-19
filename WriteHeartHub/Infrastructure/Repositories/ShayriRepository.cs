using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Core_Doman;
using Core_Doman.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Infrastructure.Repositories
{
    public class ShayriRepository : IShayriRepository
    {
        private readonly IConfiguration _configuration;

        public ShayriRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Shayri>> GetAllShayriAsync()  // ✅ Ensure correct return type
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.QueryAsync<Shayri>("SELECT * FROM Tbl_Shayrimsg  WHERE IsDelete = 0");
                return result.ToList(); // ✅ Convert to List<Shayri>
            }
        }
    }
}
