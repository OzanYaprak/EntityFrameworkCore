using CodeFirst.DataAccessLayer;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Initilizer.Build();

			using (var _context = new AppDbContext())
			{
				#region DbContext (ChangeTracker / ContextId / Database)

				_context.Products.Add(new() { Name = "Defter", Price = 100, Stock = 5, Barcode = 123 });
				_context.Products.Add(new() { Name = "Kalem", Price = 100, Stock = 5, Barcode = 123 });
				_context.Products.Add(new() { Name = "Oyuncak", Price = 100, Stock = 5, Barcode = 123 });

                //Console.WriteLine($"Context Id = {_context.ContextId}");

                _context.SaveChanges();


				//var products = _context.Products.AsNoTracking().ToList(); // AsNoTracking() sql den gelen datanin Efcore tarafindan memory de track edilmemesini sagliyor.

				//products.ForEach(x => {
				//Console.WriteLine($"{x.Id} - {x.Name} {x.Price} {x.Stock}");
				//});

				#endregion
				#region DbContext States

				//var newProduct = new Product { Name = "Defter", Price = 200, Stock = 20, Barcode = 123 };
				//var updateProduct = _context.Products.First();

				//Console.WriteLine($"Ilk State : {_context.Entry(updateProduct).State}");

				//updateProduct.Name = "Klavye";
				//updateProduct.Price = 555;
				//updateProduct.Stock = 0;

				//// _context.Add(newProduct); // Kod buraya geldiginde artik ef core tarafindan memory de track edilmeye baslaniyor ve state artik Added olarak degisiyor
				//_context.Update(updateProduct);
				////_context.Remove(updateProduct);

				//Console.WriteLine($"Ikinci State : {_context.Entry(newProduct).State}"); // State Added

				//_context.SaveChanges();

				//Console.WriteLine($"Son State : {_context.Entry(newProduct).State}");

				#endregion
				#region Eski kod
				//var products = _context.Products.ToList();

				//products.ForEach(p => 
				//{
				//	var efCoreState = _context.Entry(p).State; // EfCore tarafindan tract edilen p entitysinin state bilgisini verir.

				//	Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock} / State: {efCoreState}"); 
				//});
				#endregion
			}
		}
	}
}


// State Detached anlami, ef core tarafindan memoryde track edilmiyor demek
// Veritabanindaki data ile burada bulunan data bir birine esit oldugu icin State Unchanged oluyor.