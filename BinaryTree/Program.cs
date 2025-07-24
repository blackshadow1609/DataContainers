//BinaryTree
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Random rand = new Random(0);
			Tree tree = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree.Insert(rand.Next(100), tree.Root);
			}
			tree.Print(tree.Root);
			Console.WriteLine();
			Console.WriteLine($"Минимальное значение в дереве:	{tree.MinValue(tree.Root)}");
			Console.WriteLine($"Максимальное значение в дереве: {tree.MaxValue(tree.Root)}");
			Console.WriteLine($"Количество элементов дерева:	{tree.Count(tree.Root)}");
			Console.WriteLine($"Сумма элементов дерева:			{tree.Sum(tree.Root)}");

			UniqueTree u_tree = new UniqueTree();
			for (int i = 0; i < n; i++)
			{
				u_tree.Insert(rand.Next(100), u_tree.Root);
			}
			u_tree.Print(u_tree.Root);
			Console.WriteLine();
			Console.WriteLine($"Минимальное значение в дереве:	{u_tree.MinValue(u_tree.Root)}");
			Console.WriteLine($"Максимальное значение в дереве: {u_tree.MaxValue(u_tree.Root)}");
			Console.WriteLine($"Количество элементов дерева:	{u_tree.Count(u_tree.Root)}");
			Console.WriteLine($"Сумма элементов дерева:			{u_tree.Sum(u_tree.Root)}");

		}
	}
}
