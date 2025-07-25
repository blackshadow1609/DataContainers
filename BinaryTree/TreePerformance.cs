using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
	internal class TreePerformance<T>
	{
		public delegate T Method();	//Объявление делегата
									//Делегат - это указатель на функцию
		public static void Measure(string message, Method method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			T value = method();
			sw.Stop();
			Console.WriteLine($"{message} {value}, вычисленно за {sw.Elapsed.ToString("ss\\.fffffff")} секунд.");
		}
	}
}
