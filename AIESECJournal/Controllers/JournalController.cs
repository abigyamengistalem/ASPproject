using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIESECJournal.Models;


namespace AIESECJournal.Controllers
{
    public class JournalController : Controller
    {
        // GET: Journal
        public ActionResult Index()
        {
            using(DbModels dbModel=new DbModels()) {

                return View(dbModel.JournalDailies.ToList());

            }



            
        }

        // GET: Journal/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {

                return View(dbModel.JournalDailies.Where(x => x.Id==id).FirstOrDefault());
            }
        }

        // GET: Journal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journal/Create
        [HttpPost]
        public ActionResult Create(JournalDaily journaldaily )
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.JournalDailies.Add(journaldaily);
                    dbModel.SaveChanges();
                    
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Journal/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {

                return View(dbModel.JournalDailies.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Journal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, JournalDaily journaldaily)
        {
            try
            {
                using (DbModels dbModel=new DbModels()) {

                    dbModel.Entry(journaldaily).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Journal/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {

                return View(dbModel.JournalDailies.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Journal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    JournalDaily journaldaily= dbModel.JournalDailies.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.JournalDailies.Remove(journaldaily);
                    dbModel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
