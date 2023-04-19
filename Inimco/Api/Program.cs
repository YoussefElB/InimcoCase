using Api;
using Application.CommandHandlers.PersonHandlers;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Inimco Demo App",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "somemail@mailerd.inimco",
                        Name = "Deweloper Yusup @ inimco",
                        Url = new Uri("https://chat.openai.com/")
                    }
                });
        });

        //using SQLite, the database is a file as requested but atleast we can use EF on it like in most production environments
        builder.Services.AddDbContext<InimcoDbContext>();

        builder.Services.AddMediatR(typeof(AddPersonCommandHandler).Assembly);

        builder.Services.RegisterServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("*");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}