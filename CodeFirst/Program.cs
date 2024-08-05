using CodeFirst.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Initilizer.Build();

			using (var _context = new AppDbContext())
			{
				var products = _context.Products.ToList();

				products.ForEach(p => { Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock}"); });
			}
		}
	}
}
