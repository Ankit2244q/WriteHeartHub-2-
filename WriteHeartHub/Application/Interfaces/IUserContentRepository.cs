using Core_Doman;
using Core_Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Application.Interfaceses
namespace Application.Interfaces
{
    public interface IUserContentRepository
    {
        //   Task<IEnumerable<Shayri>> GetShayriListAsync();
        Task<List<UserContent>> GetAllContentAsync();
        Task<UserContent> AddUserContentAsync(string content, int type,int? Id);

        Task<UserContent> DeleteUserContentAsync(int id);

    }
}
