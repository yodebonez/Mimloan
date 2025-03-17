using Microsoft.EntityFrameworkCore;
using MimtestApi.DBlayer;
using MimtestApi.Models;
using MimtestApi.Service;
using MimtestApi.Service.Interfaces;
using Moq;
using Xunit;

namespace MimtestApi.Test
{
	public class LoanApplicationServiceTests
	{
		private readonly ILoanService _service;
		private readonly LoanDbContext _context;

		public LoanApplicationServiceTests()
		{
			var options = new DbContextOptionsBuilder<LoanDbContext>()
				.UseInMemoryDatabase(databaseName: "LoanTestDb")
				.Options;
			_context = new LoanDbContext(options);
			_service = new LoanService(_context, new Mock<ILogger<LoanService>>().Object);
		}

		public object Assert { get; private set; }

		[Fact]
		public async Task Can_Add_And_Get_Loan()
		{
			var loan = new Loan { ApplicantName = "John Doe", LoanAmount = 5000, LoanTerm = 12, InterestRate = 5 };
			await _service.AddAsync(loan);

			var loans = await _service.GetAllAsync();
			Assert.single(loan);

		     
		}
	}
}