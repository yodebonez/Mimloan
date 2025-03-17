namespace MimtestApi.Models
{
	public class Loan
	{
		public int Id { get; set; }
		public string ApplicantName { get; set; } = string.Empty;
		public decimal LoanAmount { get; set; }
		public int LoanTerm { get; set; } // in months
		public decimal InterestRate { get; set; }
		public LoanStatus Status { get; set; } = LoanStatus.Pending;
		public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
	}
}
