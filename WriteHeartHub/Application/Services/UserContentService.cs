﻿using Application.Interfaces;
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

        public async Task<UserContent> AddContentAsync(string post, int type)
        {
          return await _userRepository.AddUserShayriAsync(post, type);
        }

        public async Task<List<UserContent>> GetAllShayriAsync()  // ✅ Correct return type
        {
            return await _userRepository.GetAllShayriAsync();
        }
    }
}
