using Microsoft.EntityFrameworkCore;
using MimtestApi.DBlayer;
using MimtestApi.Dto;
using MimtestApi.Models;
using MimtestApi.Service.Interfaces;
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





		public async Task<Response<List<LoanApplication>>> GetAllLoansApplication()
		{
			var Loan = await _context.LoanApplications.ToListAsync();

			return new Response<List<LoanApplication>>
			{
				Data = Loan,
				Success = true,
				Message = "sucessful"
			};
		}

		public async Task<Response<LoanApplication?>> GetLoanById(int id)
		{
			var Loan = await _context.LoanApplications.FindAsync(id);

			if (Loan == null)
				return new Response<LoanApplication?>
				{

					Success = false,
					Message = "Loan is not available"
				};


			return new Response<LoanApplication?>
			{
				Data = Loan,
				Success = true,
				Message = "Succesful"
			};

		}

		public async Task<Response<CreateLoanResponse>> CreateLoan(CreateLoanRequest loan)
		{
			if (loan.LoanTerm < 1)
				return new Response<CreateLoanResponse>
				{

					Success = false,
					Message = "Laon terms cannot be less than 1 month"
				};

			if (loan.LoanAmount < 0)
				return new Response<CreateLoanResponse>
				{

					Success = false,
					Message = "Laon ammount must be greater than zero"
				};
			LoanApplication createloan = new LoanApplication
			{
				ApplicantName = loan.ApplicantName,
				LoanTerm = loan.LoanTerm,
				LoanAmount = loan.LoanAmount,
				Status = LoanStatus.Pending,
				InterestRate = CalculateLoanInterest(loan.LoanTerm)

			};

			await _context.LoanApplications.AddAsync(createloan);
			await _context.SaveChangesAsync();

			CreateLoanResponse response = new CreateLoanResponse
			{
				ApplicantName = createloan.ApplicantName,
				InterestRate = createloan.InterestRate,
				LoanAmount = createloan.LoanAmount,
								
			};

			return new Response<CreateLoanResponse>
			{

				Success = true,
				Message = "Laon application Created succefully",
				Data = response
			};


		}

		public async Task<Response<UpdateLaonResponse>> UpdateLoan(int id, UpdateLoanRequest update)
		{
			var loan = await _context.LoanApplications.FindAsync(id);
			if (loan == null)
				return new Response<UpdateLaonResponse>
				{

					Success = false,
					Message = "The loan is not available"
				};
			loan.Status = update.Status;
			loan.LoanTerm = update.LoanTerm;
			loan.LoanAmount = update.LoanAmount;
			loan.DateUpdated = DateTime.UtcNow;

			await _context.SaveChangesAsync();

			return new Response<UpdateLaonResponse>
			{

				Success = true,
				Message = "The loan Updated Sucessfully"


			};
		}

		public async Task DeleteLaon(int id)
		{
			var loan = await _context.LoanApplications.FindAsync(id);
			if (loan != null)
			{
				_context.LoanApplications.Remove(loan);
				await _context.SaveChangesAsync();
			}
		}

		private decimal CalculateLoanInterest(int loanTerm)
		{
			return loanTerm < 6 ? 10m : 15m;
		}

		
	}
}