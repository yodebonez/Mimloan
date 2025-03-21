using MimtestApi.Dto;
using MimtestApi.Models;

namespace MimtestApi.Service.Interfaces
{
	public interface ILoanApplication
	{
		Task<IEnumerable<LoanApplication>> GetAllLoansApplication();
		Task<LoanApplication?> GetLoanById(int id);
		Task <LoanApplication>  CreateLoan(CreateLoanRequest loan);
		Task <LoanApplication> UpdateLoan(int id, UpdateLoanRequest loan);
		Task DeleteLaon(int id);
	}
}
