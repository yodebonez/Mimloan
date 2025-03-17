using Microsoft.EntityFrameworkCore;
using MimtestApi.DBlayer;
using MimtestApi.Models;
using MimtestApi.Service.Interfaces;

namespace MimtestApi.Service
{
	public class LoanService : ILoanService
	{
		private readonly LoanDbContext _context;
		private readonly ILogger<LoanService> _logger;

		public LoanService(LoanDbContext context, ILogger<LoanService> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<List<Loan>> GetAllAsync()
			=> await _context.LoanApplications.ToListAsync();

		public async Task<Loan?> GetByIdAsync(int id)
			=> await _context.LoanApplications.FindAsync(id);

		public async Task AddAsync(Loan loan)
		{
			_context.LoanApplications.Add(loan);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Loan loan)
		{
			_context.LoanApplications.Update(loan);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var loan = await _context.LoanApplications.FindAsync(id);
			if (loan != null)
			{
				_context.LoanApplications.Remove(loan);
				await _context.SaveChangesAsync();
			}
		}
	}
}