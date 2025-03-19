using MimtestApi.Models;

namespace MimtestApi.Dto
{
	public class CreateLoanRequest
	{
		public string ApplicantName { get; set; } = string.Empty;
		public decimal LoanAmount { get; set; }
		public int LoanTerm { get; set; } // in months
		//public decimal InterestRate { get; set; }
		//public LoanStatus Status { get; set; } = LoanStatus.Pending;
	}

	public class CreateLoanResponse
	{

		public string ApplicantName { get; set; } = string.Empty;
		public decimal LoanAmount { get; set; }
		public int LoanTerm { get; set; } // in months
		public decimal InterestRate { get; set; }
		public LoanStatus Status { get; set; } = LoanStatus.Pending;

		// Computed Property to Return Status as String
		public string StatusDescription => Status.ToString();

	}
}
