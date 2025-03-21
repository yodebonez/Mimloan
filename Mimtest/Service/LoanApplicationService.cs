using Microsoft.EntityFrameworkCore;
using MimtestApi.DBlayer;
using MimtestApi.Dto;
using MimtestApi.Models;
using MimtestApi.Service.Interfaces;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MimtestApi.Service
{
	public class LoanApplicationService : ILoanApplication
	{
		private readonly LoanDbContext _context;
		private readonly ILogger<LoanApplicationService> _logger;

		public LoanApplicationService(LoanDbContext context, ILogger<LoanApplicationService> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<LoanApplication> CreateLoan(CreateLoanRequest loan)
		{
			LoanApplication createloan = new LoanApplication
			{
				ApplicantName = loan.ApplicantName,
				LoanTerm = loan.LoanTerm,
				LoanAmount = loan.LoanAmount,
				Status = LoanStatus.Pending,
				InterestRate = CalculateLoanInterest(loan.LoanTerm)

			};

		  var result =	await _context.LoanApplications.AddAsync(createloan);
			await _context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task DeleteLaon(int id)
		{
			var result = await _context.LoanApplications
				.FirstOrDefaultAsync(e => e.Id == id);
			if (result != null)
			{
				_context.LoanApplications.Remove(result);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<LoanApplication>> GetAllLoansApplication()
		{
			return await _context.LoanApplications.ToListAsync();
		}

		public async Task<LoanApplication?> GetLoanById(int id)
		{
			return await _context.LoanApplications
			  .FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<LoanApplication> UpdateLoan(int id, UpdateLoanRequest loan)
		{
			var AvailableLoan = await _context.LoanApplications.FindAsync(id);
			if (AvailableLoan != null)
			{
				AvailableLoan.DateUpdated = DateTime.UtcNow;
				AvailableLoan.ApplicantName = loan.ApplicantName;
				AvailableLoan.LoanTerm = loan.LoanTerm;
				AvailableLoan.InterestRate = CalculateLoanInterest(loan.LoanTerm);
				AvailableLoan.Status = loan.Status;


				await _context.SaveChangesAsync();

				return AvailableLoan;


			}

			return null;

		}

		private decimal CalculateLoanInterest(int loanTerm)
		{
			return loanTerm < 6 ? 10m : 15m;
		}

		
	}
}