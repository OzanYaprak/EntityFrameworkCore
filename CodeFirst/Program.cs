using CodeFirst.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
	internal class Program
	{
		static async void Main(string[] args)
		{
			Initilizer.Build();

			using (var _context = new AppDbContext())
			{
				var products = await _context.Products.ToListAsync();

				products.ForEach(p => { Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock}"); });

				//test
			}
		}
	}
}
