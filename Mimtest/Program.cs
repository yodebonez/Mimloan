using Microsoft.EntityFrameworkCore;
using MimtestApi.DBlayer;
using MimtestApi.Service;
using MimtestApi.Service.Interfaces;

namespace Mimtest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Logging.ClearProviders(); 
			builder.Logging.AddConsole(); 
			builder.Logging.AddDebug(); 

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();




			builder.Services.AddDbContext<LoanDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

			builder.Services.AddScoped<ILoanApplication, LoanApplicationService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
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
