using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TP_6.Models;

namespace TP_6.Controllers
{
    public class SamouraisController : Controller
    {
        private Context db = new Context();

        // GET: Samourais
        public async Task<ActionResult> Index()
        {
            return View(await db.Samourais.ToListAsync());
        }

        // GET: Samourais/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = await db.Samourais.FindAsync(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var viewModel = new SamouraiViewModel();
            viewModel.Armes = db.Armes.ToList();
            return View(viewModel);
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SamouraiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(viewModel.IdArmeChoisie.HasValue)
                {
                    viewModel.Samourai.Arme = await db.Armes.FirstOrDefaultAsync(x => x.Id == viewModel.IdArmeChoisie.Value);
                }
                db.Samourais.Add(viewModel.Samourai);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            viewModel.Armes = await db.Armes.ToListAsync();
            return View(viewModel);
        }

        // GET: Samourais/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = await db.Samourais.FindAsync(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SamouraiViewModel();
            viewModel.Armes = db.Armes.ToList();
            if (samourai.Arme != null)
            {
                viewModel.IdArmeChoisie = samourai.Arme.Id;
            }
            
            viewModel.Samourai = samourai;
            
            return View(viewModel);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SamouraiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var samourai = await db.Samourais.FindAsync(viewModel.Samourai.Id);
                samourai.Force = viewModel.Samourai.Force;
                samourai.Nom = viewModel.Samourai.Nom;
                samourai.Arme = null;
                if (viewModel.IdArmeChoisie.HasValue)
                {
                    samourai.Arme = await db.Armes.FirstOrDefaultAsync(x => x.Id == viewModel.IdArmeChoisie.Value);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel.Samourai);
        }

        // GET: Samourais/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = await db.Samourais.FindAsync(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Samourai samourai = await db.Samourais.FindAsync(id);
            db.Samourais.Remove(samourai);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
