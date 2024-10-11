
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using BLL.Validation;
using DAL.Data;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace RecifyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddDbContext<RecifyDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MsSqlServer"]));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());


            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IUploadCsvService, UploadCsvService>();
            builder.Services.AddScoped<ILinkedDatabaseService, LinkedDatabaseService>();
            builder.Services.AddScoped<IRecommenderConfigurationService, RecommenderConfigurationService>();
            builder.Services.AddScoped<IRecommenderToUploadedCsvService, RecommenderToUploadedCsvService>();


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
