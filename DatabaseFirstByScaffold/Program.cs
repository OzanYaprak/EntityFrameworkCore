using DatabaseFirst.DataAccessLayer;
using DatabaseFirstByScaffold.Models;

namespace DatabaseFirstByScaffold
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DbContextInitilizer.Build();
			
			using var DbContext = new UdemyEFCoreDatabaseFirstDbContext();

			var products = DbContext.Products.ToList();

			products.ForEach(p =>
			{
				Console.WriteLine($"{p.Id} - Isim : {p.Name} Fiyat : {p.Price} Stok : {p.Stock}");
			});
		}
	}
}

