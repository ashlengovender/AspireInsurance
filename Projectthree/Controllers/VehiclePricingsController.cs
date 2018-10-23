using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projectthree.Models;

namespace Projectthree.Controllers
{
    public class VehiclePricingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VehiclePricings
        public ActionResult Index()
        {
           /* IList<VehiclePricing> VeichP = new List<VehiclePricing>();
            

            var veh = (from vp in db.VehiclePricingsTB
                       join v in db.VehiclesTB
                       on vp.Model equals v.Model
                       select new { v.PolicyID, v.CustID, v.PDriverName, v.PDLicenceNum, v.SDriverName, v.SDLicenceNum, v.Make, v.Model, v.year, v.RegNum, v.VinNum, v.party3, v.Compre, v.Engineplan, v.writeoff, v.Pricex }).ToList();



            foreach (var u in veh)
            {
                VeichP.Add(new VehiclePricing()
                {

                   
                    Make = u.Make,
                    Model = u.Model,
                    Pricex = u.Pricex


                });
            }
            return View(VeichP);
            */



              return View(db.VehiclePricingsTB.ToList());
        }

        // GET: VehiclePricings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclePricing vehiclePricing = db.VehiclePricingsTB.Find(id);
            if (vehiclePricing == null)
            {
                return HttpNotFound();
            }
            return View(vehiclePricing);
        }

        // GET: VehiclePricings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiclePricings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,Make,Model,year,Price")] VehiclePricing vehiclePricing)
        {
            if (ModelState.IsValid)
            {
                db.VehiclePricingsTB.Add(vehiclePricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclePricing);
        }

        // GET: VehiclePricings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclePricing vehiclePricing = db.VehiclePricingsTB.Find(id);
            if (vehiclePricing == null)
            {
                return HttpNotFound();
            }
            return View(vehiclePricing);
        }

        // POST: VehiclePricings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,Make,Model,year,Price")] VehiclePricing vehiclePricing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclePricing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclePricing);
        }

        // GET: VehiclePricings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclePricing vehiclePricing = db.VehiclePricingsTB.Find(id);
            if (vehiclePricing == null)
            {
                return HttpNotFound();
            }
            return View(vehiclePricing);
        }

        // POST: VehiclePricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehiclePricing vehiclePricing = db.VehiclePricingsTB.Find(id);
            db.VehiclePricingsTB.Remove(vehiclePricing);
            db.SaveChanges();
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
