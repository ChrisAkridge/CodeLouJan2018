using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
	public static class EnumerableCompositor
	{
		public static EnumerableCompositor<T> Create<T>(params IEnumerable<T>[] collections)
		{
			return new EnumerableCompositor<T>(collections);
		}
	}

	public sealed class EnumerableCompositor<T> : IEnumerable<T>
	{
		private List<IEnumerable<T>> collections;

		public EnumerableCompositor()
		{
			collections = new List<IEnumerable<T>>();
		}

		public EnumerableCompositor(IEnumerable<IEnumerable<T>> collections)
		{
			this.collections = collections.ToList();
		}

		public void Add(IEnumerable<T> collection) => collections.Add(collection);

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var collection in collections)
			{
				foreach (var item in collection)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
