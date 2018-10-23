using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projectthree.Models;

using Microsoft.AspNet.Identity;

namespace Projectthree.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehicles
        public ActionResult Index()
        {

            IList<Vehicle> VeichL = new List<Vehicle>();
            if (User.Identity.GetUserName() == "adminash@gmail.com")
            {
                return View(db.VehiclesTB.ToList());
            }
            else
            {
                var loggedinUser = User.Identity.GetUserName();

                var veh = (from me in db.Users
                           join e in db.CustomersTB
                           on me.Email equals e.Email
                           where me.Email.Equals(loggedinUser)
                           join v in db.VehiclesTB
                           on e.CustID equals v.CustID

                           select new { v.PolicyID, v.CustID, v.PDriverName, v.PDLicenceNum, v.SDriverName, v.SDLicenceNum, v.Make, v.Model, v.year, v.RegNum, v.VinNum, v.party3, v.Compre, v.Engineplan, v.writeoff, v.Pricex, v.Status }).ToList();



                foreach (var u in veh)
                {
                    VeichL.Add(new Vehicle()
                    {

                        PolicyID = u.PolicyID,
                        CustID = u.CustID,
                        PDriverName = u.PDriverName,
                        PDLicenceNum = u.PDLicenceNum,
                        SDriverName = u.SDriverName,
                        SDLicenceNum = u.SDLicenceNum,
                        Make = u.Make,
                        Model = u.Model,
                        year = u.year,
                        RegNum = u.RegNum,
                        VinNum = u.VinNum,
                        party3 = u.party3,
                        Compre = u.Compre,
                        Engineplan = u.Engineplan,
                        writeoff = u.writeoff,
                        Pricex = u.Pricex


                    });
                }
                return View(VeichL);
            }

    
       //      return View(db.VehiclesTB.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.VehiclesTB.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyID,CustID,PDriverName,PDLicenceNum,SDriverName,SDLicenceNum,Make,Model,year,RegNum,VinNum,party3,Compre,Engineplan,writeoff,Pricex,Status")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {


                vehicle.PolicyID = vehicle.determinkey();
                vehicle.Pricex = vehicle.getPrice();
                db.VehiclesTB.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.VehiclesTB.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyID,CustID,PDriverName,PDLicenceNum,SDriverName,SDLicenceNum,Make,Model,year,RegNum,VinNum,party3,Compre,Engineplan,writeoff,Pricex,Status")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.Pricex = vehicle.getPrice();
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.VehiclesTB.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.VehiclesTB.Find(id);
            db.VehiclesTB.Remove(vehicle);
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
