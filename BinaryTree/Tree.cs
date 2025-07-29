using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Tree
	{
		static readonly int BASE_INTERVAL = 3;
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

		public void Insert(int Data)
		{
			Insert(Data, Root);
		}
		void Insert(int Data, Element Root)
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
		public void Erase(int Data)
		{
			Element Root = this.Root;
			Erase(Data, Root, null);
		}

		void Erase(int Data, Element Root, Element Parent)
		{
			if (Root == null) return;
			Erase(Data, Root.pLeft, Root);
			Erase(Data, Root.pRight, Root);
			if (Data == Root.Data)
			{
				if (Root.pLeft == Root.pRight)
				{
					if (Root.Equals(Parent.pLeft)) Parent.pLeft = null;
					if (Root.Equals(Parent.pRight)) Parent.pRight = null;
				}
				else
				{
					if (Count(Root.pLeft) > Count(Root.pRight))
					{
						Root.Data = MaxValue(Root.pLeft);
						Erase(MaxValue(Root.pLeft), Root.pLeft, Root);
					}
					else
					{
						Root.Data = MinValue(Root.pRight);
						Erase(MinValue(Root.pRight), Root.pRight, Root);
					}
				}
			}
			//if (Root != null) Erase(Data, Root.pLeft);
			//if (Root != null) Erase(Data, Root.pRight);
		}
		public void Balance()
		{
			Balance(Root);
		}
		void Balance(Element Root)
		{
			if (Root == null) return;
			//Balance(Root.pLeft);
			//Balance(Root.pRight);
			if (Math.Abs(Count(Root.pLeft) - Count(Root.pRight)) < 2) return;
				if (Count(Root.pLeft) > Count(Root.pRight))
				{
					if (Root.pRight == null) Root.pRight = new Element(Root.Data);
					else Insert(Root.Data, Root.pRight);
					Root.Data = MaxValue(Root.pLeft);
					Erase(MaxValue(Root.pLeft), Root.pLeft, Root);
				}
				else
				{
					if (Root.pLeft == null) Root.pLeft = new Element(Root.Data);
					else Insert(Root.Data, Root.pLeft);
					Root.Data = MinValue(Root.pRight);
					Erase(MinValue(Root.pRight), Root.pRight, Root);
				}

			Balance(Root.pLeft);
			Balance(Root.pRight);
			Balance(Root);

		}
		public int MinValue()
		{
			return MinValue(Root);
		}
		int MinValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pLeft == null ? Root.Data : MinValue(Root.pLeft);
			//if (Root.pLeft == null) return Root.Data;
			//else return MinValue(Root.pLeft);
		}
		public int MaxValue()
		{
			return MaxValue(Root);
		}
		int MaxValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
		}
		public int Count()
		{
			return Count(Root);
		}
		int Count(Element Root)
		{
			if (Root == null) return 0;
			return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
		}
		public int Sum()
		{
			return Sum(Root);
		}
		int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
		}
		public double Avg()
		{
			return (double)Sum(Root) / Count();
		}

		public int Depth()
		{
			return Depth(Root);
		}
		int Depth(Element Root)
		{
			if (Root == null) return 0;
			int lDepth = Depth(Root.pLeft);
			int rDepth = Depth(Root.pRight);
			return (lDepth > rDepth ? lDepth : rDepth) + 1;
		}

		public void DepthPrint(int Depth)
		{
			DepthPrint(Root, Depth);
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
		}
		void DepthPrint(Element Root, int Depth)
		{
			int interval = BASE_INTERVAL * (this.Depth(this.Root) - Depth);
			if (Root == null)
			{
				//Console.Write("".PadLeft(interval));
				return;
			}
			if (Depth == 0)
			{
				Console.Write(Root.Data.ToString().PadLeft(interval));
			}
			else
			{
				DepthPrint(Root.pLeft, Depth - 1);
				DepthPrint(Root.pRight, Depth - 1);
			}
		}
		public void TreePrint(int Depth = 0)
		{
			if (Root == null) return;
			if (this.Depth(this.Root) - Depth == 0) return;
			int interval = BASE_INTERVAL * (this.Depth() - Depth);
			Console.Write("".PadLeft(interval));
			PrintInterval(this.Depth(this.Root) - Depth);
			DepthPrint(Depth);
			TreePrint(Depth + 1);
		}
		void PrintInterval(int count)
		{
			for (int i = 0; i < count; i++) Console.Write("    ");
		}
		public void Print()
		{
			Print(Root);
			Console.WriteLine();
		}
		void Print(Element Root)
		{
			if (Root == null) return;
			Print(Root.pLeft);
			Console.Write(Root.Data + "\t");
			Print(Root.pRight);
		}
	}
}
