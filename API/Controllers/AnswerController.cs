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

    public class AnswerController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IAnswerService _services;


        public AnswerController(IGenericService<Answer> service, IMapper mapper, IAnswerService answerService)

        {
            _mapper = mapper;
            _services = answerService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAnswer()
        {
            return CreateActionResult(await _services.GetApiAllAnswer());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var answer = await _services.GetAllAsync();
            var answerDtos = _mapper.Map<List<AnswerDto>>(answer.ToList());
            return CreateActionResult(CustomResponseDto<List<AnswerDto>>.Success(200, answerDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Answer>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var answer = await _services.GetByIdAsync(id);
            var answerDto = _mapper.Map<AnswerDto>(answer);
            return CreateActionResult(CustomResponseDto<AnswerDto>.Success(200, answerDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(AnswerDto answerDto)
        {
            var answer = await _services.AddAsync(_mapper.Map<Answer>(answerDto ));
            var answersDto = _mapper.Map<AnswerDto>(answer);
            return CreateActionResult(CustomResponseDto<AnswerDto>.Success(201, answerDto)); //
        }



        [HttpPut]
        public async Task<IActionResult> Update(AnswerDto answerDto)
        {
            await _services.UpdateAsync(_mapper.Map<Answer>(answerDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var answer = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(answer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }
    }
}
