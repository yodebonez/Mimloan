using MimtestBlazor.Api;
using MimtestBlazor.Models;

namespace MimtestBlazor.Services.Interfaces
{
	public interface ILoanApplicationService
	{
		Task<List<LoanApplication>> GetAllAsync();
		Task<LoanApplication?> GetByIdAsync(int id);
		Task AddAsync(LoanApplication loan);
		Task UpdateAsync(LoanApplication loan);
		Task DeleteAsync(int id);
	}
}
