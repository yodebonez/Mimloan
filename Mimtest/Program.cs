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

            builder.Services.AddControllers();

			builder.Services.AddDbContext<LoanDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<ILoanService, LoanService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
