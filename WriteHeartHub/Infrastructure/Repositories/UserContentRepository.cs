using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Doman.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Infrastructure.Repositories
{
    public class UserContentRepository : IUserContentRepository
    {
        private readonly IConfiguration _configuration;

        public UserContentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public async Task<List<UserContent>> GetAllShayriAsync()  // ✅ Ensure correct return type
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.QueryAsync<UserContent>("SELECT * FROM UserContent WHERE Content IS NOT NULL");
                return result.ToList(); // ✅ Convert to List<Shayri>
            }
        }

        Task<UserContent> IUserContentRepository.AddUserShayriAsync(string content, int type)
        {
            throw new NotImplementedException();
        }
    }
}
