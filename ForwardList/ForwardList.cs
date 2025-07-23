using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	internal class ForwardList
	{
		Element Head { get; set; }
		public int Length { get; private set; }
		public ForwardList()
		{
			Head = null;
			Console.WriteLine($"LConstructor:\t{GetHashCode()}");
		}

		~ForwardList()
		{
			Head = null;
			Length = 0;
			Console.WriteLine($"LDestructor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			Head = null;
			Length = 0;
		}
		//				Adding Elements:
		public void PushFront(int Data)
		{
			//1) Создаём новый элемент:
			//Element New = new Element(Data);

			//2) Пристыковываем новый элемент к началу списка:
			//New.pNext = Head;

			//3) Смещаем Голову на новый элемент:
			//Head = New;

			Head = new Element(Data, Head);
			Length++;
		}
		public void PushBack(int Data)
		{
			//0) Проверяем, есть ли в списке элементы:
			if (Head == null)
			{
				PushFront(Data);
				return;
			}

			//1) Доходим до конца списка:
			Element Temp = Head; //Итератор
			while (Temp.pNext != null) Temp = Temp.pNext;

			//2) Создаем добавляемый элемент:
			Element New = new Element(Data);

			//3) Добавляем элемент в список:
			//Temp.pNext = New;
			Temp.pNext = new Element(Data);
			Length++;
		}

		public void Insert(int Data, int Index)
		{
			//0) Проверяем выход за пределы списка:
			if(Index > Length || Index < 0)
			{
				//Console.WriteLine($"Error: Выход за пределы списка");
				//return;
				throw new IndexOutOfRangeException("Error: Выход за пределы списка");
			}
			if(Index == 0)
			{
				PushFront(Data);
				return;
			}

			//1) Доходим до нужного элемента:
			Element Temp = Head;
			for (int i = 0; i < Index - 1; i++)
			{
				if (Temp.pNext == null) break;
				Temp = Temp.pNext;
			}

			//2) Добавляем элемент в список:
			Temp.pNext = new Element(Data, Temp.pNext);
			Length++;
		}

		//	Rempving elements:
		public void PopFront()
		{
			if (Head != null)
			{
				Head = Head.pNext;  //Исключаем элемент из списка, из памяти он будет удален GarbageCollector-ом
				Length--;
			}
		}
		public void PopBack()
		{
			//0) Проверяем, есть ли в списке элементы:
			if (Head == null || Head.pNext == null)
			{
				PopFront();
				return;
			}

			//1) Доходим до конца списка:
			Element Temp = Head;
			while (Temp.pNext.pNext != null) Temp = Temp.pNext;

			//2) Исключаем элемент из списка:
			Temp.pNext = null;
			Length--;
		}
		public void Print()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
				Console.Write($"{Temp.Data}\t");
				Console.WriteLine();
			Console.WriteLine($"Количество элементов списка: {Length}");
		}
	}
}
