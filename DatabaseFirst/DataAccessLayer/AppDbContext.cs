using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.DataAccessLayer
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		// Default Constructor
		public AppDbContext() { }

		public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(DbContextInitilizer.Configuration.GetConnectionString("SQLConnection"));
		}


	}
}
