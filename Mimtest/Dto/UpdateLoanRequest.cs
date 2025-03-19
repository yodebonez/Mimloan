using MimtestApi.Models;

namespace MimtestApi.Dto
{
	public class UpdateLoanRequest
	{
		
		public string ApplicantName { get; set; } = string.Empty;
		public decimal LoanAmount { get; set; }
		public int LoanTerm { get; set; } // in months
		public decimal InterestRate { get; set; }
		public LoanStatus Status { get; set; } 

	}

	public class UpdateLaonResponse
	{
	
		public string ApplicantName { get; set; } = string.Empty;
		public decimal LoanAmount { get; set; }
		public int LoanTerm { get; set; } // in months
		public decimal InterestRate { get; set; }
		public LoanStatus Status { get; set; } 

	}
}
