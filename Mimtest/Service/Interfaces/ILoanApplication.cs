using MimtestApi.Dto;
using MimtestApi.Models;

namespace MimtestApi.Service.Interfaces
{
	public interface ILoanApplication
	{
		Task<Response<List<LoanApplication>>> GetAllLoansApplication();
		Task<Response<LoanApplication?>> GetLoanById(int id);
		Task <Response<CreateLoanResponse>>  CreateLoan(CreateLoanRequest loan);
		Task <Response<UpdateLaonResponse>> UpdateLoan(int id, UpdateLoanRequest loan);
		Task DeleteLaon(int id);
	}
}
