﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DocVision.Business.Services;
using DocVision.Business.Interfaces;

namespace DocVision.Business.DependecyResolver;

public static class RegisterBusiness
{
    public static void RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IMailService, MailService>();
    }
}