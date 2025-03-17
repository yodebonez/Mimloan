using Microsoft.EntityFrameworkCore;
using MimtestApi.Models;

namespace MimtestApi.DBlayer
{
	public class LoanDbContext : DbContext
	{

		public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }

		public DbSet<Loan> LoanApplications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Loan>().HasKey(x => x.Id);
		}
	}
}
