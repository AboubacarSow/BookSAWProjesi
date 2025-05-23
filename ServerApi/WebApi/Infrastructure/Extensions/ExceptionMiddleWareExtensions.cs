﻿using Entities.ErrorModels;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;

namespace WebApi.Infrastructure.Extensions
{
    public static class ExceptionMiddleWareExtensions
    {

        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature?.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong : {contextFeature?.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode=context.Response.StatusCode,
                            Message=contextFeature?.Error.Message
                        }.ToString());

                    }
                });
            });
        }
    }
}
