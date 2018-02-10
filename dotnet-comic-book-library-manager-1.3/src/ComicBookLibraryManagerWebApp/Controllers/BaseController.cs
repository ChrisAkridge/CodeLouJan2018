using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicBookShared.Data;

namespace ComicBookLibraryManagerWebApp.Controllers
{
	public abstract class BaseController : Controller
	{
		private bool disposed = false;
		protected Context Context { get; private set; } = null;

		protected Repository Repository { get; private set; }

		public BaseController()
		{
			Context = new Context();
			Repository = new Repository(Context);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposed) { return; }
			if (disposing) { Context.Dispose(); }
			disposed = true;
			base.Dispose(disposing);
		}
	}
}