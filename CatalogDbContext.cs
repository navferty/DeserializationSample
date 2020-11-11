using Microsoft.EntityFrameworkCore;
using System;

namespace DeserializationSample
{
	public class CatalogDbContext : DbContext
	{
		//public CatalogDbContext(DbContextOptions options) : base(options)
		//{
		//}

		//public CatalogDbContext()
		//{
		//}

		public DbSet<CATALOG> Catalogs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SampleDeserializationDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CATALOG>()
				.Property(catalog => catalog.LoadedAt)
				.HasDefaultValue(DateTime.Parse("2020-01-01"));
		}
	}
}
