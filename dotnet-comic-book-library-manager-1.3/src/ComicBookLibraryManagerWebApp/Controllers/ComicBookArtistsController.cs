using ComicBookLibraryManagerWebApp.ViewModels;
using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicBookShared.Data;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    /// <summary>
    /// Controller for adding/deleting comic book artists.
    /// </summary>
    public class ComicBookArtistsController : BaseController
    {
		private ComicBooksRepository comicBooksRepository = null;
		private ComicBookArtistsRepository comicBookArtistsRepository = null;

		public ComicBookArtistsController()
		{
			comicBooksRepository = new ComicBooksRepository(Context);
			comicBookArtistsRepository = new ComicBookArtistsRepository(Context);
		}

        public ActionResult Add(int comicBookId)
        {
			var comicBook = comicBooksRepository.GetComicBookWithSeries(comicBookId);

            if (comicBook == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ComicBookArtistsAddViewModel()
            {
                ComicBook = comicBook
            };

            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ComicBookArtistsAddViewModel viewModel)
        {
            ValidateComicBookArtist(viewModel);

            if (ModelState.IsValid)
            {
				var artist = Repository.GetArtist(viewModel.ArtistId);
				var role = Repository.GetRole(viewModel.RoleId);

				viewModel.ComicBook.AddArtist(artist, role);
				Repository.SaveChanges();

                TempData["Message"] = "Your artist was successfully added!";

                return RedirectToAction("Detail", "ComicBooks", new { id = viewModel.ComicBookId });
            }

            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Delete(int comicBookId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			// TODO Get the comic book artist.
			// Include the "ComicBook.Series", "Artist", and "Role" navigation properties.
			var comicBookArtist = comicBookArtistsRepository.Get(comicBookId, id.Value);

            if (comicBookArtist == null)
            {
                return HttpNotFound();
            }

            return View(comicBookArtist);
        }

        [HttpPost]
        public ActionResult Delete(int comicBookId, int id)
        {
			var comicBook = comicBooksRepository.GetComicBookWithArtists(comicBookId);
			var comicBookArtist = comicBook.Artists.Where(cba => cba.Id == id).SingleOrDefault();
			comicBook.Artists.Remove(comicBookArtist);

			comicBooksRepository.DeleteArtistFromComicBook(comicBook, comicBookArtist);

            TempData["Message"] = "Your artist was successfully deleted!";

            return RedirectToAction("Detail", "ComicBooks", new { id = comicBookId });
        }

        /// <summary>
        /// Validates a comic book artist on the server
        /// before adding a new record.
        /// </summary>
        /// <param name="viewModel">The view model containing the values to validate.</param>
        private void ValidateComicBookArtist(ComicBookArtistsAddViewModel viewModel)
        {
			// If there aren't any "ArtistId" and "RoleId" field validation errors...
			if (ModelState.IsValidField("ArtistId") &&
				ModelState.IsValidField("RoleId"))
			{
				// Then make sure that this artist and role combination 
				// doesn't already exist for this comic book.
				if (comicBookArtistsRepository.GetForComic(viewModel.ComicBookId)
					.Any(cba => (viewModel.ArtistId == cba.ArtistId) && (viewModel.RoleId == cba.RoleId)))
				{
					ModelState.AddModelError("ArtistId",
						"This artist and role combination already exists for this comic book.");
				}
			}
		}
	}
}