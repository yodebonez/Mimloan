using Microsoft.AspNetCore.Components;

namespace MimtestBlazor.Pages
{
	public class LoanApplicationBase : ComponentBase 
	{

		private List<LoanApplicationBase> loans = new();

		//protected override async Task OnInitializedAsync()
		//{
		//	loans = await LoanS.GetAllAsync();
		//}

		//private async Task DeleteLoan(int id)
		//{
		//	await LoanService.DeleteAsync(id);
		//	loans = await LoanService.GetAllAsync();
		//}



	}
}
