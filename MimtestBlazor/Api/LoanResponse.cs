

using Newtonsoft.Json;

namespace MimtestBlazor.Api
{
	public class LoanResponse
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("data")]
		public List<Loan> Data { get; set; }
	}
}
