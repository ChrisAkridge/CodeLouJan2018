using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicBookGallery.Data;
using ComicBookGallery.Models;

namespace ComicBookGallery.Controllers
{
	public class ComicBooksController : Controller
	{
		public ActionResult Detail(int? id) =>
			(id == null) ? HttpNotFound() : (ActionResult)View(ComicBookRepository.GetComicBook(id.Value));

		public ActionResult Index() => View(ComicBookRepository.GetComicBooks());
	}
}