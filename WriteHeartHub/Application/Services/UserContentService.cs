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
        private readonly IUserContentRepository _userRepository;

        public UserContentService(IUserContentRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserContent> AddUserContentAsync(string post, int type,int Id)
        {
          return await _userRepository.AddUserContentAsync(post, type,Id);
        }

        public async Task<List<UserContent>> GetAllContentAsync()  // ✅ Correct return type
        {
            return await _userRepository.GetAllContentAsync();
        }

        public async Task<UserContent> DeleteUserContentAsync(int id) 
        {
            return await _userRepository.DeleteUserContentAsync(id);
        }

    
    }
}
