using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Element
	{
		public int Data { get; set; }
		public Element pLeft { get; set; }
		public Element pRight { get; set; }

		public Element(int Data, Element pLeft = null, Element pRight = null)
		{
			this.Data = Data;
			this.pLeft = pLeft;
			this.pRight = pRight;
		}
		~Element()
		{
			//Console.WriteLine($"EDestructor: {GetHashCode()}");
		}
	}
}
