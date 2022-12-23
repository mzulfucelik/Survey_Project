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
    public class AnswerService : GenericService<Answer>, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;


        public AnswerService(IGenericRepository<Answer> repository, IGenericUnitOfWork unitOfWork, IAnswerRepository answerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<AnswerDto>> GetWebAllAnswer()
        {
            var answer = await _answerRepository.GetWebAllAnswerAsync();
            var answerDtos = _mapper.Map<List<AnswerDto>>(answer);
            return answerDtos;
        }

        public async Task<CustomResponseDto<List<AnswerDto>>> GetApiAllAnswer()
        {
            var answer = await _answerRepository.GetApiAllAnswerAsync();
            var answerDtos = _mapper.Map<List<AnswerDto>>(answer);
            return CustomResponseDto<List<AnswerDto>>.Success(200, answerDtos);
        }
        

        public async Task<List<AnswerDto>> GetWebAllAnswerAsync()
        {
            var answer = await _answerRepository.GetWebAllAnswerAsync();
            var answerDtos = _mapper.Map<List<AnswerDto>>(answer);
            return answerDtos;
        }

     
    }

}

