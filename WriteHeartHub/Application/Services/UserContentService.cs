using Application.Interfaces;
using Core_Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserContentService : IUserContentService
    {
        private readonly IUserContentRepository _shayriRepository;

        public UserContentService(IUserContentRepository shayriRepository)
        {
            _shayriRepository = shayriRepository;
        }

        public async Task<List<UserContent>> GetAllShayriAsync()  // ✅ Correct return type
        {
            return await _shayriRepository.GetAllShayriAsync();
        }
    }
}
