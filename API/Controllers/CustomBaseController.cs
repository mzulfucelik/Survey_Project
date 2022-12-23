using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Survey_Project.Core.DTOs;

namespace Survey_Project.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

    


        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                //dönen değer boş olsun.kodu al
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };


            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
