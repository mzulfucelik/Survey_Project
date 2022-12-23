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
    public interface IAnswerService : IGenericService<Answer>
    {
        public Task<CustomResponseDto<List<AnswerDto>>> GetApiAllAnswer();
        public Task<List<AnswerDto>> GetWebAllAnswer();
        public Task<List<AnswerDto>> GetWebAllAnswerAsync();
    }
}
