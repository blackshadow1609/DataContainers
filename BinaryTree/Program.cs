﻿//BinaryTree
//#define TREE_1
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
#if TREE_1
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Random rand = new Random(0);
			Tree tree = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree.Insert(rand.Next(100), tree.Root);
			}
			//tree.Print(tree.Root);
			Console.WriteLine();
			//Console.WriteLine($"Минимальное значение в дереве:	{tree.MinValue(tree.Root)}");
			//Console.WriteLine($"Максимальное значение в дереве: {tree.MaxValue(tree.Root)}");
			//Console.WriteLine($"Количество элементов дерева:	{tree.Count(tree.Root)}");
			//Console.WriteLine($"Сумма элементов дерева:			{tree.Sum(tree.Root)}");

			TreePerformance<int>.Measure("Минимальное значение в дереве: ", tree.MinValue);
			TreePerformance<int>.Measure("Минимальное значение в дереве: ", tree.MaxValue);
			TreePerformance<int>.Measure("Количество элементов дерева: ", tree.Count);
			TreePerformance<int>.Measure("Сумма элементов дерева: ", tree.Sum);
			TreePerformance<double>.Measure("Среднее-арифметическое элементов дерева: ", tree.Avg);

			UniqueTree u_tree = new UniqueTree();
			for (int i = 0; i < n; i++)
			{
				u_tree.Insert(rand.Next(100), u_tree.Root);
			}
			u_tree.Print(u_tree.Root);
			Console.WriteLine();
			Console.WriteLine($"Минимальное значение в дереве:	{u_tree.MinValue()}");
			Console.WriteLine($"Максимальное значение в дереве: {u_tree.MaxValue()}");
			Console.WriteLine($"Количество элементов дерева:	{u_tree.Count()}");
			Console.WriteLine($"Сумма элементов дерева:			{u_tree.Sum()}"); 
#endif


			//Tree tree = new Tree() { 50, 25, 75, 16, 32, 70, 80 };
			Tree tree = new Tree();
			tree.Insert(50);
			tree.Insert(25);
			tree.Insert(75);
			tree.Insert(16);
			tree.Insert(32);
			tree.Insert(70);
			tree.Insert(80);
			tree.Print();
			Console.WriteLine("\n-------------------------------------------------------\n");

			//tree.DepthPrint(2);

			tree.TreePrint();
		}

	}
}
