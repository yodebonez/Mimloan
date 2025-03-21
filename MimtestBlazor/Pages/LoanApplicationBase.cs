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

		protected List<LoanApplication> PaginatedLoans = new();


		protected int CurrentPage { get; set; } = 1;
		protected int PageSize { get; set; } = 5;  
		protected int TotalPages { get; set; }



		protected override async Task OnInitializedAsync()
		{
			await LoadLoans();
		}

	

		protected async Task LoadLoans()
		{
			Loans = await LoanService.GetAllAsync();
			TotalPages = (int)Math.Ceiling((double)Loans.Count / PageSize);
			UpdatePagination();
		}


	

		protected void UpdatePagination()
		{
			PaginatedLoans = Loans
				.Skip((CurrentPage - 1) * PageSize)
				.Take(PageSize)
				.ToList();

			StateHasChanged(); 
		}

	

		protected void NextPage()
		{
			if (CurrentPage < TotalPages)
			{
				CurrentPage++;
				UpdatePagination();
			}
		}

		protected void PreviousPage()
		{
			if (CurrentPage > 1)
			{
				CurrentPage--;
				UpdatePagination();
			}
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

