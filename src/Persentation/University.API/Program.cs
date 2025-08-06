using Uninversity.Infarstructure;
using Uninversity.Infarstructure.Repositories;
using University.Application.Students;
using University.Domain.Interfaces;
using System.Data;
using Microsoft.EntityFrameworkCore;
using University.Application;
using Microsoft.AspNetCore.Diagnostics;
using University.Domain.Abstractions;
using University.Application.Semesters.Contracts;
using University.Application.Semesters;
using University.Application.Teachers.Contracts;
using University.Application.Teachers;
using University.Application.Courses.Contracts;
using University.Application.Courses;
using University.Application.Classes.Contracts;
using University.Application.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("UniversityConnectionString"));
});

builder.Services.AddScoped<IStudentRepository, EfStudentRepository>();
builder.Services.AddScoped<ISemesterRepository, EfSemesterRepository>();
builder.Services.AddScoped<ITeacherRepository, EfTeacherRepository>();
builder.Services.AddScoped<ICourseRepository, EfCourseRepository>();
builder.Services.AddScoped<IClassRepository, EfClassRepository>();

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IClassService, ClassService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler(async ex =>
    {
        ex.Run(async context =>
        {
            var exeption = context.Features.Get<IExceptionHandlerPathFeature>();

            if (exeption.Error is BusinessException)
            {
                var exTitle = exeption.Error.GetType().Name
                .ToString().Replace("Exception", "");
                await context.Response.WriteAsync(exTitle);
            }
        });
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
