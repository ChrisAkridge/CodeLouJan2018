using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShared.Models;

namespace ComicBookShared.Data
{
	public sealed class ComicBookArtistsRepository : BaseRepository<ComicBookArtist>
	{

		public ComicBookArtistsRepository(Context context) : base(context) { }

		public ComicBookArtist Get(int comicBookId, int cbaId)
		{
			return Context.ComicBooks
				.Include(cb => cb.Series)
				.Include(cb => cb.Artists.Select(cba => cba.Artist))
				.Include(cb => cb.Artists.Select(cba => cba.Role))
				.Where(cb => cb.Id == comicBookId)
				.SingleOrDefault()
				.Artists.Where(cba => cba.Id == cbaId).SingleOrDefault();
		}

		public override ComicBookArtist Get(int id, bool includeRelatedEntities = true)
		{
			return Context.ComicBooks
				.Include(cb => cb.Series)
				.Include(cb => cb.Artists.Select(cba => cba.Artist))
				.Include(cb => cb.Artists.Select(cba => cba.Role))
				.SelectMany(cb => cb.Artists)
				.Where(cba => cba.Id == id)
				.SingleOrDefault();
		}

		public IList<ComicBookArtist> GetForComic(int id)
		{
			return Context.ComicBooks
					.Where(cb => cb.Id == id)
					.SingleOrDefault()
					.Artists.ToList();
		}

		public override IList<ComicBookArtist> GetList()
		{
			throw new NotImplementedException();
		}
	}
}
