using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicBookGallery.Models;

namespace ComicBookGallery.Data
{
	public static class ComicBookRepository
	{
		private static ComicBook[] comicBooks = new ComicBook[]
		{
			new ComicBook()
			{
				Id = 0,
				SeriesTitle = "The Amazing Spider-Man",
				IssueNumber = 700,
				DescriptionHTML = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives...<strong>will Peter Parker?</strong></p>",
				Artists = new Artist[]
				{
					new Artist() { Name = "Dan Slott", Role = "Script" },
					new Artist() { Name = "Humberto Ramos", Role = "Pencils" },
					new Artist() { Name = "Victor Olazaba", Role = "Inks" },
					new Artist() { Name = "Edgar Delgado", Role = "Colors" },
					new Artist() { Name = "Chris Eliopoulos", Role = "Letters" },
				},
				Favorite = false
			},
			new ComicBook()
			{
				Id = 1,
				SeriesTitle = "The Amazing Spider-Man",
				IssueNumber = 657,
				DescriptionHTML = "<p><strong>FF: THREE TIE-IN.</strong> Spider-Man visits the FF for a very private wake--just for family.</p>",
				Artists = new Artist[]
				{
					new Artist() { Name = "Dan Slott", Role = "Script" },
					new Artist() { Name = "Marcos Martin", Role = "Pencils" },
					new Artist() { Name = "Marcos Martin", Role = "Inks" },
					new Artist() { Name = "Muntsa Vicente", Role = "Colors" },
					new Artist() { Name = "Joe Caramagna", Role = "Letters" }
				},
				Favorite = false
			},
			new ComicBook()
			{
				Id = 2,
				SeriesTitle = "Bone",
				IssueNumber = 50,
				DescriptionHTML = "<p><strong>The Dungeon & The Parapet, Part 1.</strong> Thorn is discovered by Lord Tarsil and the corrupted Stickeaters and thrown into a dungeon with Fone Bone. As she sleeps, a message comes to her about the mysterious \"Crown of Horns\".</p>",
				Artists = new Artist[]
				{
					new Artist() { Name = "Jeff Smith", Role = "Script" },
					new Artist() { Name = "Jeff Smith", Role = "Pencils" },
					new Artist() { Name = "Jeff Smith", Role = "Inks" },
					new Artist() { Name = "Jeff Smith", Role = "Letters" }
				},
				Favorite = false
			}
		};

		public static ComicBook[] GetComicBooks() => comicBooks;
		public static ComicBook GetComicBook(int id) => comicBooks.First(c => c.Id == id);
	}
}