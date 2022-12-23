using Survey_Project.Core;
using Survey_Project.Core.DTOs;
using Survey_Project.Core.Repositories;
using Survey_Project.Core.Services;
using Survey_Project.Core.UnitOfWorks;
using System;
using AutoMapper;
using Core.Repositories;
using Core.Models;
using Core.DTOs;


namespace Survey_Project.Service.Services
{
    public class QuestionService : GenericService<Question>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;


        public QuestionService(IGenericRepository<Question> repository, IGenericUnitOfWork unitOfWork, IQuestionRepository questionRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionDto>> GetWebAllQuestion()
        {
            var question = await _questionRepository.GetWebAllQuestionAsync();
            var questionDtos = _mapper.Map<List<QuestionDto>>(question);
            return questionDtos;
        }

        public async Task<CustomResponseDto<List<QuestionDto>>> GetApiAllQuestion()
        {
            var question = await _questionRepository.GetApiAllQuestionAsync();
            var questionDtos = _mapper.Map<List<QuestionDto>>(question);
            return CustomResponseDto<List<QuestionDto>>.Success(200, questionDtos);
        }
        

        public async Task<List<QuestionDto>> GetWebAllQuestionAsync()
        {
            var question = await _questionRepository.GetWebAllQuestionAsync();
            var questionDtos = _mapper.Map<List<QuestionDto>>(question);
            return questionDtos;
        }

     
    }

}

