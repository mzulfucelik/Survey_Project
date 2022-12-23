using Core.DTOs;
using Core.Models;
using Core.DTOs;
using Survey_Project.Core.DTOs;
using Survey_Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_Project.Core.Services
{
    public interface IUserService : IGenericService<User>
    {
        public Task<CustomResponseDto<List<UserDto>>> GetApiAllUser();
        public Task<List<UserDto>> GetWebAllUser();
        public Task<List<UserDto>> GetWebAllUserAsync();
    }
}
