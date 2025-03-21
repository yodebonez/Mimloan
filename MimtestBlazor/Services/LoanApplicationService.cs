using MimtestBlazor.Api;
using MimtestBlazor.Models;
using MimtestBlazor.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Security;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace MimtestBlazor.Services
{
	public class LoanApplicationService : ILoanApplicationService
	{

		//private readonly HttpClient httpClient;

		
		//public LoanApplicationService(HttpClient httpClient) { 
		
		//   this.httpClient = httpClient;
		//}

		//public async Task<IEnumerable<LoanApplication>> GetLoanApplication()
		//{
		//	ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


		//	ServicePointManager.ServerCertificateValidationCallback = new
		//	RemoteCertificateValidationCallback
		//	(
		//	   delegate { return true; }
		//	);

		//	return await httpClient.GetFromJsonAsync<IEnumerable<LoanApplication>>("/api/Loan/getallloans")
		// ?? new List<LoanApplication>(); 

		//}


		private readonly LoanDbContext _context;
    private readonly ILogger<LoanApplicationService> _logger;

    public LoanApplicationService(LoanDbContext context, ILogger<LoanApplicationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<LoanApplication>> GetAllAsync() => await _context.LoanApplications.ToListAsync();
    
    public async Task<LoanApplication?> GetByIdAsync(int id) => await _context.LoanApplications.FindAsync(id);
    
    public async Task AddAsync(LoanApplication loan)
    {
        _context.LoanApplications.Add(loan);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Loan application added: {loan.Id}");
    }
    
    public async Task UpdateAsync(LoanApplication loan)
    {
        _context.LoanApplications.Update(loan);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Loan application updated: {loan.Id}");
    }
    
    public async Task DeleteAsync(int id)
    {
        var loan = await _context.LoanApplications.FindAsync(id);
        if (loan != null)
        {
            _context.LoanApplications.Remove(loan);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Loan application deleted: {id}");
        }
    }

		
	}
}
