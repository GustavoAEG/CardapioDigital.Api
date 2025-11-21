using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.IO;

namespace CardapioDigital.Infrastructure.Persistence
{
    // Design-time factory used by dotnet-ef to create the DbContext
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Build configuration: assumes you run the commands from the solution root or the Api project folder.
            // Adjust the relative path if your solution layout is different.
            var basePath = Directory.GetCurrentDirectory();

            // If commands are run from the Infrastructure folder, try to go up to Api
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Path.Combine("..", "CardapioDigital.Api", "appsettings.json"), optional: true)
                .AddJsonFile(Path.Combine("..", "CardapioDigital.Api", "appsettings.Development.json"), optional: true)
                .AddEnvironmentVariables()
                .Build();

            var conn = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(conn))
            {
                // fallback: try parent/parent (if you run from solution root)
                config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(basePath, ".."))
                    .AddJsonFile(Path.Combine("CardapioDigital.Api", "appsettings.json"), optional: true)
                    .AddJsonFile(Path.Combine("CardapioDigital.Api", "appsettings.Development.json"), optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                conn = config.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'. Check your appsettings files and paths.");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(conn, sql => sql.EnableRetryOnFailure());

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
