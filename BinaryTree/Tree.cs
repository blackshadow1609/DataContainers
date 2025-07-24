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
			//if (Root.pLeft == null) return Root.Data;
			//else return MinValue(Root.pLeft);
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
	}
}
