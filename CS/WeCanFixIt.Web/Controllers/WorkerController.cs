using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeCanFixIt.Web.Models;

namespace WeCanFixIt.Web.Controllers
{
    [Authorize]
    public class WorkerController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Worker
        public async Task<ActionResult> Index()
        {
            return View(await _db.Workers.ToListAsync());
        }

        // GET: Worker/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await _db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            ViewBag.SkillList=new SelectList(_db.Jobs, "WorkType", "WorkType");
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Skills,HoursWorked,Rate")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Workers.Add(worker);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SkillList = new SelectList(_db.Jobs, "WorkType", "WorkType");

            return View(worker);
        }

        // GET: Worker/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await _db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }

            ViewBag.SkillList = new SelectList(_db.Jobs, "WorkType", "WorkType");

            return View(worker);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Skills,HoursWorked,Rate")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(worker).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SkillList = new SelectList(_db.Jobs, "WorkType", "WorkType");

            return View(worker);
        }

        // GET: Worker/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = await _db.Workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Worker worker = await _db.Workers.FindAsync(id);
            _db.Workers.Remove(worker);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
