using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
	public class Initilizer
	{
		public static IConfigurationRoot Configuration;

		public static void Build()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true , true);

			Configuration = builder.Build();
		}
	}
}
