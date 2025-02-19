using Core_Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShayriService
    {
        Task<List<Shayri>> GetAllShayriAsync();
    }
}
