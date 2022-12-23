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

    public class UserController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IUserService _services;


        public UserController(IGenericService<User> service, IMapper mapper, IUserService userService)

        {
            _mapper = mapper;
            _services = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser()
        {
            return CreateActionResult(await _services.GetApiAllUser());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await _services.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(user.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _services.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _services.AddAsync(_mapper.Map<User>(userDto ));
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userDto)); //
        }



        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _services.UpdateAsync(_mapper.Map<User>(userDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }
    }
}
