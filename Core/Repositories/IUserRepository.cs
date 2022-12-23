using Core.Models;
using Survey_Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetApiAllUserAsync();
        Task<List<User>> GetWebAllUserAsync();
    }
}
