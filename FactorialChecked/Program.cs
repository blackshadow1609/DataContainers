using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialChecked
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
			long f = 1;
			checked
			{
				try
				{
					for (int i = 1; i <= n; i++)
					{
						f *= i;
						Console.WriteLine($"{i} != {f};");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				} 
			}
		}
	}
}
