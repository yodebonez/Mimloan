using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimtestBlazor.Api;
using MimtestBlazor.Models;
using MimtestBlazor.Services.Interfaces;


namespace MimtestBlazor.Pages
{
	public class LoanApplicationBase : ComponentBase
	{

		//[Inject]
		//public ILoanApplicationService LoanService { get; set; }

		//[Inject]
		// public  NavigationManager Navigation { get; set; }

		////public IEnumerable<LoanApplication> loans { get; set; }

		//public List<LoanApplication>? loanApplications;


		//protected void NavigateToCreate() => Navigation.NavigateTo("/loan-applications/create");
		//protected void NavigateToEdit(int id) => Navigation.NavigateTo($"/loan-applications/edit/{id}");




		//protected override async Task OnInitializedAsync()
		//{
		//	loanApplications = await LoanService.GetAllAsync();
		//}

		//protected async Task ApproveLoan(int id)
		//{
		//	var loan = await LoanService.GetByIdAsync(id);
		//	if (loan != null)
		//	{
		//		loan.Status = LoanStatus.Approved;
		//		await LoanService.UpdateAsync(loan);
		//		loanApplications = await LoanService.GetAllAsync();
		//	}
		//}

		//protected async Task RejectLoan(int id)
		//{
		//	var loan = await LoanService.GetByIdAsync(id);
		//	if (loan != null)
		//	{
		//		loan.Status = LoanStatus.Rejected;
		//		await LoanService.UpdateAsync(loan);
		//		loanApplications = await LoanService.GetAllAsync();
		//	}
		//}

		//protected void EditLoan(int id)
		//{
		//	// Navigate to edit page
		//}

		//protected async Task DeleteLoan(int id)
		//{
		//	await LoanService.DeleteAsync(id);
		//	loanApplications = await LoanService.GetAllAsync();
		//}


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
			var loan = await LoanService.GetByIdAsync(id); // Retrieve the loan application
			if (loan != null)
			{
				loan.Status = LoanStatus.Approved; // Update status
				await LoanService.UpdateAsync(loan); // Pass the updated object
				await LoadLoans(); // Refresh list
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

		//protected async Task UpdateLoan(int id)
		//{
		//	await LoanService.UpdateAsync(LoanApplication);
		//	Navigation.NavigateTo("/loan-applications");
		//}

		protected async Task UpdateLoan()
		{
			await LoanService.UpdateAsync(LoanApplication); // Assuming UpdateAsync takes LoanApplication
			Navigation.NavigateTo("/loan-applications"); // Redirect after update
		}

		protected async Task LoadLoanById(int id)
		{
			LoanApplication = await LoanService.GetByIdAsync(id);
		}


	}





}

