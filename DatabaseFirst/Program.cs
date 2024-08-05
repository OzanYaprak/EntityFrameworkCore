using DatabaseFirst.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			DbContextInitilizer.Build();

			using (var _context = new AppDbContext())
			{
				var products =  _context.Products.ToList();

				products.ForEach(p =>
				{
					Console.WriteLine($"{p.Id} - Isim : {p.Name} Fiyat : {p.Price} Stok : {p.Stock}");
				});
			}
		}
	}
}
