
using APICatalago.Context;
using APICatalago.Repositories;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Logging;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace APICatalago
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(options =>
            {
                //Add o filatro criado como filtro gloBal
                options.Filters.Add(typeof(ApiExceptionFilter));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //String de conexao BD

            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                                    options.UseMySql(mySqlConnection, 
                                    ServerVersion.AutoDetect(mySqlConnection)));

            builder.Services.AddScoped<ApiLoggingFilter>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            /*Desabilitando mecanismo de inferencia da infeção de dependecia dos controladores
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.DisableImplicitFromServicesParameters = true;
            });*/

            //Add o provedor de log personalizado(CustomLoggerProvider) ao sistmea de log ASP.NET Core,
            //Definindo o nivel minimo delog como LogLevel.Infomatiom
            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ConfigureExceptionsHandler();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
