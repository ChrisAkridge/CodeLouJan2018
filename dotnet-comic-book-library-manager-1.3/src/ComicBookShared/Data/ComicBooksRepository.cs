using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShared.Models;

namespace ComicBookShared.Data
{
	public sealed class ComicBooksRepository : BaseRepository<ComicBook>
	{
		public ComicBooksRepository(Context context) : base(context) { }

		public override IList<ComicBook> GetList()
		{
			return Context.ComicBooks
				   .Include(cb => cb.Series)
				   .OrderBy(cb => cb.Series.Title)
				   .ThenBy(cb => cb.IssueNumber)
				   .ToList();
		}

		public ComicBook GetComicBookWithSeriesArtistAndRole(int id)
		{
			return Context.ComicBooks
					.Include(cb => cb.Series)
					.Include(cb => cb.Artists.Select(a => a.Artist))
					.Include(cb => cb.Artists.Select(a => a.Role))
					.Where(cb => cb.Id == id)
					.SingleOrDefault();
		}

		public ComicBook GetComicBookWithSeries(int id)
		{
			return Context.ComicBooks
				.Include(cb => cb.Series)
				.Where(cb => cb.Id == id)
				.SingleOrDefault();
		}

		public override ComicBook Get(int id, bool includeRelatedEntities)
		{
			return Context.ComicBooks.Where(cb => cb.Id == id).SingleOrDefault();
		}

		public ComicBook GetComicBookWithArtists(int id)
		{
			return Context.ComicBooks
				.Include(cb => cb.Artists)
				.Where(cb => cb.Id == id).SingleOrDefault();
		}

		public void Delete(ComicBook comicBook)
		{
			Context.Entry(comicBook).State = EntityState.Deleted;
			Context.SaveChanges();
		}

		public void DeleteArtistFromComicBook(ComicBook comicBook, ComicBookArtist cba)
		{
			Context.Entry(cba).State = EntityState.Deleted;
			Context.Entry(comicBook).State = EntityState.Modified;
			Context.SaveChanges();
		}
	}
}
