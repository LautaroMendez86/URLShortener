
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using URLShortener.Data;
using URLShortener.Data.Service.Implementations;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Data.Service.Repository;

namespace URLShortener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<UrlShortenerContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:AgendaAPIDBConnectionString"]));
            builder.Services.AddScoped<IXYZRepository, XYZRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<XYZService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}