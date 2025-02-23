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
using System.Data;

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
        #region  

        //public async Task<UserContent> AddUserShayriAsync(string content, int type)
        // {

        //     using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         connection.OpenAsync();
        //         using (var command = new SqlCommand("usp_AddUserPost", connection))
        //         {
        //             command.CommandType = CommandType.StoredProcedure;

        //             command.Parameters.AddWithValue("@UserId", "123");
        //             command.Parameters.AddWithValue("@Type", type);
        //             command.Parameters.AddWithValue("@Content", content);

        //             var newId = Convert.ToInt32(await command.ExecuteScalarAsync());

        //             return new UserContent
        //             {
        //                 Id = newId,
        //                 UserId = "123",
        //                 Type = type, 
        //                 Content = content,
        //                 CreatedAt = DateTime.UtcNow
        //             };
        //         }
        //     }
        // }
        // 
        #endregion

        /*--------- This method use for Insert Vs Update User Content -----------*/
        public async Task<UserContent> AddUserShayriAsync(string content, int type, int? id = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync(); // Await to ensure connection opens properly

                using (var command = new SqlCommand("usp_AddUserPost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Pass Id (Nullable: If null, SP inserts; if not null, SP updates)
                    command.Parameters.AddWithValue("@Id", (object?)id ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UserId", "123");
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Content", content);

                    var newId = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return new UserContent
                    {
                        Id = newId,
                        UserId = "123",
                        Type = type,
                        Content = content,
                        CreatedAt = DateTime.UtcNow // Ensure proper date handling
                    };
                }
            }
        }

        public async Task<UserContent> DeleteUserContentAsync(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                // Retrieve the record before deleting
                var existingContent = await connection.QueryFirstOrDefaultAsync<UserContent>(
                    "SELECT * FROM UserContent WHERE Id = @Id", new { Id = id });

                if (existingContent == null)
                    return null; // No record found to delete

                // Delete the record
                await connection.ExecuteAsync("DELETE FROM UserContent WHERE Id = @Id", new { Id = id });

                return existingContent; // Return the deleted record
            }
        }



    }
}
