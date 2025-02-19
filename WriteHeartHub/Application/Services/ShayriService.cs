using Application.Interfaces;
using Core_Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ShayriService : IShayriService
    {
        private readonly IShayriRepository _shayriRepository;

        public ShayriService(IShayriRepository shayriRepository)
        {
            _shayriRepository = shayriRepository;
        }

        public async Task<List<Shayri>> GetAllShayriAsync()  // ✅ Correct return type
        {
            return await _shayriRepository.GetAllShayriAsync();
        }
    }
}
