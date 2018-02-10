using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;

namespace ComicBookGalleryModel
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new Context())
			{
				context.Database.Log = message => Debug.WriteLine(message);

				var comicBookId = 1;
				var comicBook1 = context.ComicBooks.Find(comicBookId);
				var comicBook2 = context.ComicBooks.Find(comicBookId);
			}

			Console.ReadKey(intercept: true);
		}
	}
}
