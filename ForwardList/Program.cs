using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер списка: ");
			int n = Convert.ToInt32(Console.ReadLine());

			Random rand = new Random(0);

			ForwardList list = new ForwardList();
			list.PushFront(123);
			list.PopBack();
			for (int i = 0; i < n; i++)
			{
				list.PushFront(rand.Next(100));
				//list.PushBack(rand.Next(100));
			}
			//list.PushBack(234);
			list.Print();
			//list.PopBack();
			bool inputError;
			do
			{
				inputError = false;
				//repeat:
				Console.Write("Введите индекс добавляемого элемента: ");
				int index = Convert.ToInt32(Console.ReadLine());
				Console.Write("Введите значение добавляемого элемента: ");
				int value = Convert.ToInt32(Console.ReadLine());
				//list.Length = 123;
				try
				{
					list.Insert(value, index);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("\n---------------------------------------\n");
					//goto repeat;
					inputError = true;
				} 
			} while (inputError);
			list.Print();
		}
	}
}
