using System;

namespace SampleHouseClient
{
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Threading;
	using SampleHouseDomain.Models;

	class Program
	{
		static string baseAddress = "http://localhost:9000/";

		static void Main(string[] args)
		{
			Thread.Sleep(TimeSpan.FromSeconds(5));
			GetAllHouses();

			CreateHouse();

			GetAllHouses();

			UpdateteHouse();

			GetAllHouses();

			DeleteHouse();

			GetAllHouses();

			Console.ReadLine();
		}

		private static void CreateHouse()
		{
			HttpClient client = new HttpClient();
			var item = new HouseDto()
			{
				City = "Istanbul",
				Street = "Pendik",
				ZipCode = 123123
			};
			var response = client.PostAsync(new Uri(baseAddress + "api/house/"),
				new ObjectContent(typeof(HouseDto), item, new JsonMediaTypeFormatter())).Result;
			Console.WriteLine(response);
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}
		private static void UpdateteHouse()
		{
			HttpClient client = new HttpClient();
			var item = new HouseDto()
			{
				City = "Ankara",
				Street = "Çankaya",
				ZipCode = 454545
			};
			var response = client.PutAsync(new Uri(baseAddress + "api/house/5"),
				new ObjectContent(typeof(HouseDto), item, new JsonMediaTypeFormatter())).Result;
			Console.WriteLine(response);
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}

		private static void DeleteHouse()
		{
			HttpClient client = new HttpClient();
			var item = new HouseDto()
			{
				City = "Ankara",
				Street = "Çankaya",
				ZipCode = 454545
			};
			var response = client.PostAsync(new Uri(baseAddress + "api/house/5"), item, new JsonMediaTypeFormatter()).Result;
			Console.WriteLine(response);
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}

		private static void GetAllHouses()
		{
			HttpClient client = new HttpClient();
			var response = client.GetAsync(baseAddress + "api/house/Get").Result;
			Console.WriteLine(response);
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
		}
	}
}
