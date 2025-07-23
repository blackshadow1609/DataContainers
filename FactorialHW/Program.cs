using System;
using System.Collections;
using System.Collections.Generic;

namespace Factorial
{
	public class Node
	{
		public int Data { get; set; }
		public Node Next { get; set; }
		public Node Previous { get; set; }

		public Node(int data)
		{
			Data = data;
		}
	}

	public class ForwardList : IEnumerable<int>
	{
		private Node head;
		private Node tail;

		public ForwardList() { }

		public ForwardList(IEnumerable<int> collection)
		{
			foreach (var item in collection)
			{
				Add(item);
			}
		}

		public void Add(int data)
		{
			Node newNode = new Node(data);
			if (head == null)
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				tail.Next = newNode;
				newNode.Previous = tail;
				tail = newNode;
			}
		}

		public IEnumerator<int> GetEnumerator()
		{
			Node current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class BigInteger
	{
		private List<int> digits = new List<int>();

		public BigInteger(long value)
		{
			if (value == 0)
			{
				digits.Add(0);
			}
			else
			{
				while (value > 0)
				{
					digits.Add((int)(value % 10));
					value /= 10;
				}
			}
		}

		public static BigInteger operator *(BigInteger a, int b)
		{
			BigInteger result = new BigInteger(0);
			int carry = 0;

			for (int i = 0; i < a.digits.Count; i++)
			{
				int product = a.digits[i] * b + carry;
				result.digits.Add(product % 10);
				carry = product / 10;
			}

			while (carry > 0)
			{
				result.digits.Add(carry % 10);
				carry /= 10;
			}

			return result;
		}

		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();
			for (int i = digits.Count - 1; i >= 0; i--)
			{
				sb.Append(digits[i]);
			}
			return sb.ToString();
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			// Работа списка
			ForwardList list = new ForwardList() { 3, 5, 8, 13, 21 };
			foreach (int i in list)
			{
				Console.Write($"{i}\t");
			}
			Console.WriteLine("\n");

			// Вычисление факториала с длинной арифметикой
			Console.Write("Введите число: ");
			int n = Convert.ToInt32(Console.ReadLine());

			BigInteger f = new BigInteger(1);
			for (int i = 1; i <= n; i++)
			{
				f = f * i;
				Console.WriteLine($"{i}! = {f};");
			}
		}
	}
}