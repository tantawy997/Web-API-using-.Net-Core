using RepositoryPattern.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using RepositoryPatternBL;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var ConnectionString = builder.Configuration.GetConnectionString("co1");
        builder.Services.AddDbContext<AppDbContext>(optins => optins.UseSqlServer(ConnectionString));

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        builder.Services.AddScoped<IStudentRepo, StudentRepo>();
        builder.Services.AddScoped<IStudentManager, StudentManager>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        int counter = 0;
        app.Use(async (context, next) =>
        {
            counter++;
            //before request
            //context.RequestServices.;

            await next(context);
            //after request
        });
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


}
