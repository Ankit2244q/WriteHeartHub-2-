﻿using Core_Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserContentService
    {
        Task<List<UserContent>> GetAllShayriAsync();
        Task<UserContent> AddContentAsync(string post , int type,int Id);

        Task<UserContent> DeleteUserContentAsync(int id);

    }
}
