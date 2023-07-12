using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using AutoMapper;
using DataSchemaLibrary.DataAccess;
using DataSchemaLibrary.Middleware;
using DataSchemaLibrary.Controllers;

namespace DataSchemaLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Регистрация класса контекста данных
            builder.Services.AddDbContext<DataSchemaLibraryDbContext>(options =>
                options.UseSqlite("YourConnectionString"));

            builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Program>();
                    fv.DisableDataAnnotationsValidation = true;
                });

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           

            app.Run();
        }
    }
}
