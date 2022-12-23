using Core.Models;
using Survey_Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<List<Question>> GetApiAllQuestionAsync();
        Task<List<Question>> GetWebAllQuestionAsync();
    }
}
