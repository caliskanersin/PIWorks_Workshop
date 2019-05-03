namespace SampleHouseWepApi
{
	using System;
	using Microsoft.Owin.Hosting;

	class Program
	{
		static void Main(string[] args)
		{
			string baseAddress = "http://localhost:9000/";
			Console.WriteLine("House web api service :" + baseAddress);
			WebApp.Start<Startup>(url: baseAddress);
			Console.ReadLine();
		}
	}
}
