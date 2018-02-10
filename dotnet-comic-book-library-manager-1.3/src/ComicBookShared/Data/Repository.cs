using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShared.Models;

namespace ComicBookShared.Data
{
	public class Repository
	{
		private Context context = null;

		public Repository(Context context)
		{
			this.context = context;
		}

		public IList<Series> GetSeries()
		{
			return context.Series.ToList();
		}

		public Artist GetArtist(int id)
		{
			return context.Artists
					.Include(a => a.ComicBooks)
					.Where(a => a.Id == id)
					.SingleOrDefault();
		}

		public IList<Artist> GetArtists()
		{
			return context.Artists.ToList();
		}

		public IList<Role> GetRoles()
		{
			return context.Roles.ToList();
		}

		public Role GetRole(int id)
		{
			return context.Roles
					.Where(r => r.Id == id)
					.SingleOrDefault();
		}

		public void SaveChanges() => context.SaveChanges();

		public Series GetSeries(int id)
		{
			return context.Series
				.Include(s => s.ComicBooks)
				.Where(s => s.Id == id)
				.SingleOrDefault();
		}

		public void AddSeries(Series series)
		{
			context.Series.Add(series);
			SaveChanges();
		}

		public void EditSeries(Series series)
		{
			context.Entry(series).State = EntityState.Modified;
			SaveChanges();
		}

		public void DeleteSeries(int id)
		{
			var series = new Series() { Id = id };
			context.Entry(series).State = EntityState.Deleted;
			SaveChanges();
		}

		public bool IsSeriesTitleUnique(string title)
		{
			return !context.Series.Any(s => s.Title == title);
		}

		public void AddArtist(Artist artist)
		{
			context.Artists.Add(artist);
			SaveChanges();
		}

		public bool IsArtistNameUnique(string name)
		{
			return !context.Artists.Any(a => a.Name == name);
		}

		public void DeleteArtist(int id)
		{
			var artist = new Artist() { Id = id };
			context.Entry(artist).State = EntityState.Deleted;
			SaveChanges();
		}

		public void EditArtist(Artist artist)
		{
			context.Entry(artist).State = EntityState.Modified;
			SaveChanges();
		}
	}
}
