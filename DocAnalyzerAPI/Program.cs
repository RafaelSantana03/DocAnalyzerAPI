
using DocAnalyzerAPI.Data;
using DocAnalyzerAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocAnalyzerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite("Data Source=docanalyzer.db"));
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();  
            
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
