using Microsoft.EntityFrameworkCore;

namespace MimtestBlazor.Models
{
	public class LoanDbContext : DbContext
	{
		public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }
		public DbSet<LoanApplication> LoanApplications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LoanApplication>()
				.HasKey(x => x.Id);


			//modelBuilder.Entity<LoanApplication>()
			//	.Property(x => x.Status)
			//	.HasConversion<string>();

			base.OnModelCreating(modelBuilder);
		}
	}
}
