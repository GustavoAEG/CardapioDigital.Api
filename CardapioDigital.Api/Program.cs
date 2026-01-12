
using CardapioDigital.Api.Authorization;
using CardapioDigital.Application.DTOs.CardapioDigital.Application.Settings;
using CardapioDigital.Application.Services;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(conn));

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITableTokenService, TableTokenService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<JwtSettings>(
            builder.Configuration.GetSection("Jwt"));

            builder.Services.AddScoped<IJWTService, JwtService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            builder.Services.AddAuthorization(options =>
            {
                Policies.AddPolicies(options);
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
