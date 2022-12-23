﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Survey_Project.Core;
using System.Threading.Tasks;
using Survey_Project.Core.DTOs;
using Survey_Project.Service.Exceptions;
using System.Text.Json;
using System.Linq;

namespace Survey_Project.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
