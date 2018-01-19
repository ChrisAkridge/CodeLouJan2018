using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
	public class ComicBook
	{
		public int Id { get; set; }
		public string SeriesTitle { get; set; }
		public int IssueNumber { get; set; }
		public string DescriptionHTML { get; set; }
		public Artist[] Artists { get; set; }
		public bool Favorite { get; set; }

		public string DisplayText => SeriesTitle + " #" + IssueNumber;

		public string CoverImageFileName => SeriesTitle.Replace(' ', '-').ToLowerInvariant()
			+ "-" + IssueNumber + ".jpg";
	}
}