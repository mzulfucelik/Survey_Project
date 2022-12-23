using Core.DTOs;
using Core.Models;
using Survey_Project.Core.Services;
using Survey_Project.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_Project.Core.Services
{
    public interface IQuestionService : IGenericService<Question>
    {
        public Task<CustomResponseDto<List<QuestionDto>>> GetApiAllQuestion();
        public Task<List<QuestionDto>> GetWebAllQuestion();
        public Task<List<QuestionDto>> GetWebAllQuestionAsync();
    }
}
