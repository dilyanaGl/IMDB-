using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        private IMDBDbContext db = new IMDBDbContext();
        [HttpGet]
        [Route("")]
        public ActionResult Index(Film film)
        {
            var films = db.Films.OrderBy(p => p.Year).ThenBy(p => p.Name).ToList();
;            return View(films);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (film == null)
            {
                return RedirectToAction("Index");
            }

            db.Films.Add(film);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }


            var film = db.Films.Where(a => a.Id == id).First();

            if (film == null)
            {
                return HttpNotFound();
            }

            var model = new Film();
            model.Id = film.Id;
            model.Name = film.Name;
            model.Director = film.Director;
            model.Genre = film.Genre;
            model.Year = film.Year;
            
            return View(model);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, FilmModeView filmModel)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var film = db.Films.FirstOrDefault(f => f.Id == filmModel.Id);
            film.Name = filmModel.Name;
            film.Director = filmModel.Director;
            film.Year = filmModel.Year;
            film.Genre = filmModel.Genre;

            db.Entry(film).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }


            var film = db.Films.Where(a => a.Id == id).First();

            if (film == null)
            {
                return HttpNotFound();
            }

           
            return View(film);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var film = db.Films.FirstOrDefault(f => f.Id == filmModel.Id);

            db.Films.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}