using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Tree
	{
		public Element Root { get; protected set; }
		public Tree()
		{
			Root = null;
			Console.WriteLine($"TConstructor: {GetHashCode()}");
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor: {GetHashCode()}");
		}

		public void Insert(int Data, Element Root)
		{
			if (this.Root == null) this.Root = new Element(Data);
			if (Root == null) return;
			if (Data < Root.Data)
			{
				if (Root.pLeft == null) Root.pLeft = new Element(Data);
				else Insert(Data, Root.pLeft);
			}
			else
			{
				if (Root.pRight == null) Root.pRight = new Element(Data);
				else Insert(Data, Root.pRight);
			}
		}
		public int MinValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pLeft == null ? Root.Data : MinValue(Root.pLeft);
		}
		public int MaxValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
		}
		public int Count(Element Root)
		{
			if (Root == null) return 0;
			return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
		}
		public int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
		}
		public void Print(Element Root)
		{
			if (Root == null) return;
			Print(Root.pLeft);
			Console.Write(Root.Data + "\t");
			Print(Root.pRight);
		}

		public void Insert(int Data) => Insert(Data, Root);
		public int MinValue() => MinValue(Root);
		public int MaxValue() => MaxValue(Root);
		public int Count() => Count(Root);
		public int Sum() => Sum(Root);
		public void Print() => Print(Root);

		public void Clear()
		{
			Clear(Root);
			Root = null;
		}

		private void Clear(Element node)
		{
			if (node == null) return;
			Clear(node.pLeft);
			Clear(node.pRight);
			node.pLeft = null;
			node.pRight = null;
		}

		public void Erase(int value)
		{
			Root = Erase(Root, value);
		}

		private Element Erase(Element node, int value)
		{
			if (node == null) return null;

			if (value < node.Data)
			{
				node.pLeft = Erase(node.pLeft, value);
			}
			else if (value > node.Data)
			{
				node.pRight = Erase(node.pRight, value);
			}
			else
			{
				if (node.pLeft == null) return node.pRight;
				if (node.pRight == null) return node.pLeft;

				node.Data = MinValue(node.pRight);
				node.pRight = Erase(node.pRight, node.Data);
			}
			return node;
		}

		public int Depth()
		{
			return Depth(Root);
		}

		private int Depth(Element node)
		{
			if (node == null) return 0;
			return Math.Max(Depth(node.pLeft), Depth(node.pRight)) + 1;
		}
	}
}