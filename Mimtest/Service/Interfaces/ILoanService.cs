using MimtestApi.Models;

namespace MimtestApi.Service.Interfaces
{
	public interface ILoanService
	{
		Task<List<Loan>> GetAllAsync();
		Task<Loan?> GetByIdAsync(int id);
		Task AddAsync(Loan loan);
		Task UpdateAsync(Loan loan);
		Task DeleteAsync(int id);
	}
}
