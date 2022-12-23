using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Survey_Project.Core;
using Microsoft.AspNetCore.Mvc;
using Survey_Project.Core.Services;
using System.Threading.Tasks;
using Survey_Project.Core.DTOs;


namespace Survey_Project.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity //burada base entity var bu proje için ne olmalı
    {
        private readonly IGenericService<T> _service;
        public NotFoundFilter(IGenericService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }


            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) bulunamadı"));


        }

    }
}
