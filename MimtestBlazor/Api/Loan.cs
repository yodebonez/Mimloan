

using Newtonsoft.Json;

namespace MimtestBlazor.Api
{
	public class Loan
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("applicantName")]
		public string ApplicantName { get; set; }

		[JsonProperty("loanAmount")]
		public decimal LoanAmount { get; set; }

		[JsonProperty("loanTerm")]
		public int LoanTerm { get; set; }

		[JsonProperty("interestRate")]
		public decimal InterestRate { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("applicationDate")]
		public DateTime ApplicationDate { get; set; }

		[JsonProperty("dateUpdated")]
		public DateTime? DateUpdated { get; set; }
	}
}
