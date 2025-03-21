using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimtestBlazor.Api;
using MimtestBlazor.Models;
using MimtestBlazor.Services.Interfaces;


namespace MimtestBlazor.Pages
{
	public class LoanApplicationBase : ComponentBase
	{

		

		[Inject] protected ILoanApplicationService LoanService { get; set; }
		[Inject] protected NavigationManager Navigation { get; set; }

		protected List<LoanApplication> Loans = new();
		protected LoanApplication LoanApplication = new();

		protected override async Task OnInitializedAsync()
		{
			await LoadLoans();
		}

		protected async Task LoadLoans()
		{
			Loans = await LoanService.GetAllAsync();
		}

		protected void NavigateToCreate() => Navigation.NavigateTo("/loan-applications/create");

		protected void NavigateToEdit(int id) => Navigation.NavigateTo($"/loan-applications/edit/{id}");

		
		


		protected async Task RejectLoan(int id)
		{
			var loan = await LoanService.GetByIdAsync(id);
			if (loan != null)
			{
				loan.Status = LoanStatus.Rejected;
				await LoanService.UpdateAsync(loan);
				await LoadLoans();
			}
		}

		protected async Task ApproveLoan(int id)
		{
			var loan = await LoanService.GetByIdAsync(id); 
			if (loan != null)
			{
				loan.Status = LoanStatus.Approved; 
				await LoanService.UpdateAsync(loan); 
				await LoadLoans(); 
			}
		}


		protected async Task DeleteLoan(int id)
		{
			await LoanService.DeleteAsync(id);
			await LoadLoans();
		}

		protected async Task CreateLoan()
		{
			LoanApplication.ApplicationDate = DateTime.Now;
			LoanApplication.Status = LoanStatus.Pending;
			await LoanService.AddAsync(LoanApplication);
			Navigation.NavigateTo("/loan-applications");
		}

		

		protected async Task UpdateLoan()
		{
			await LoanService.UpdateAsync(LoanApplication); 
			Navigation.NavigateTo("/loan-applications"); 
		}

		protected async Task LoadLoanById(int id)
		{
			LoanApplication = await LoanService.GetByIdAsync(id);
		}


	}





}

