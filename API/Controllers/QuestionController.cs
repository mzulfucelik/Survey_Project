using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Survey_Project.Core;
using Survey_Project.Core.DTOs;
using Survey_Project.Core.Services;
using Survey_Project.Service.Services;
using Survey_Project.API.Filters;
using Core.Models;
using Core.DTOs;

namespace Survey_Project.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class QuestionController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IQuestionService _services;


        public QuestionController(IGenericService<Question> service, IMapper mapper, IQuestionService questionService)

        {
            _mapper = mapper;
            _services = questionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuestion()
        {
            return CreateActionResult(await _services.GetApiAllQuestion());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var question = await _services.GetAllAsync();
            var questionDtos = _mapper.Map<List<QuestionDto>>(question.ToList());
            return CreateActionResult(CustomResponseDto<List<QuestionDto>>.Success(200, questionDtos));
        }

		[ServiceFilter(typeof(NotFoundFilter<Question>))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
        {
            var question = await _services.GetByIdAsync(id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            return CreateActionResult(CustomResponseDto<QuestionDto>.Success(200, questionDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(QuestionDto questionDto)
        {
            var question = await _services.AddAsync(_mapper.Map<Question>(questionDto ));
            var questionsDto = _mapper.Map<QuestionDto>(question);
            return CreateActionResult(CustomResponseDto<QuestionDto>.Success(201, questionDto)); //
        }



        [HttpPut]
        public async Task<IActionResult> Update(QuestionDto questionDto)
        {
            await _services.UpdateAsync(_mapper.Map<Question>(questionDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var question = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(question);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }
    }
}
