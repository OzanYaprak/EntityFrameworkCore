using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DataAccessLayer
{
	public class AppDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			Initilizer.Build();
			optionsBuilder.UseSqlServer(Initilizer.Configuration.GetConnectionString("SQLConnection"));
		}
		public DbSet<Product> Products { get; set; }

		public override int SaveChanges()
		{
			ChangeTracker.Entries().ToList().ForEach(x =>
			{
				if (x.Entity is Product product)
				{
					if (x.State == EntityState.Added)
					{
						product.CreatedDate = DateTime.Now;
					}
				}

			});

			return base.SaveChanges();
		}

	}
}
