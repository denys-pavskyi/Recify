
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
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
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4200"));
            });

            builder.Services.AddDbContext<RecifyDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MsSqlServer"]));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

            var accessKey = builder.Configuration["AWS:AccessKey"];
            var secretKey = builder.Configuration["AWS:SecretKey"];
            AWSOptions awsOptions = new AWSOptions
            {
                Credentials = new BasicAWSCredentials(accessKey, secretKey),
                Region = RegionEndpoint.EUCentral1
            };
            builder.Services.AddDefaultAWSOptions(awsOptions);
            builder.Services.AddAWSService<IAmazonS3>();

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

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}
