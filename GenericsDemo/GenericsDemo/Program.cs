using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
	class Program
	{
		public static bool IsOdd(int value) => value % 2 != 0;

		static void Main(string[] args)
		{
			var list1 = new List<int> { 1, 2, 3, 4, 5 };
			var list2 = new List<int> { 2, 4, 6, 8, 10 };
			var set1 = new HashSet<int> { 3, 6, 9, 12, 15 };
			var array1 = new[] { 4, 8, 12, 16, 20 };

			var ec = new EnumerableCompositor<int> { list1, list2, set1, array1 };

			Console.WriteLine("There are {0} odd numbers in our lists",
				ec.Count(i => IsOdd(i)));
			Console.ReadKey();
		}
	}
}
