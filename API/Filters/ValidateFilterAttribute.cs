using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Survey_Project.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Survey_Project.Core.Services;
using System.Threading.Tasks;
using Survey_Project.Core.DTOs;

namespace Survey_Project.API.Filters
{
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors =  context.ModelState.Values.SelectMany(x=> x.Errors).Select(x=> x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
            }
        }
    }
}
