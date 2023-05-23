using DocVision.Dto.Validation;
using DocVision.WebApi.ExeptionHandlers;
using DocVision.WebApi.Extensions;
using FluentValidation.AspNetCore;
using DocVision.DataAccessLayer.DatabaseSetter;
using DocVision.Business.DependecyResolver;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.RegisterDataAccess(config);
builder.Services.RegisterBusinessServices(config);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.InitializeDatabase();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
