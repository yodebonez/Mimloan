using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MimtestBlazor.Models;
using MimtestBlazor.Services;
using MimtestBlazor.Services.Interfaces;

namespace MimtestBlazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
       
		builder.Logging.ClearProviders();
		builder.Logging.AddConsole();
		builder.Logging.AddDebug();
		// builder.Services.AddScoped<ILoanApplicationService,LoanApplicationService>();

		builder.Services.AddDbContext<LoanDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

		builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();


		//builder.Services.AddHttpClient<ILoanApplicationService, LoanApplicationService>(client =>
		//{
		//	client.BaseAddress = new Uri("https://localhost:7272/");
		//});

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
