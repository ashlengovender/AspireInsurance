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
    public class ClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Claims
        public ActionResult Index()
        {
            IList<Claim> EmailView = new List<Claim>();
            // ApplicationDbContext db = new ApplicationDbContext();

            //   if (Request.IsAuthenticated)
            //  {

            if (User.Identity.GetUserName() == "adminash@gmail.com")
            {
                return View(db.ClaimsTB.ToList());
            }
            else
            {

                var loggedinUser = User.Identity.GetUserName();

                var show1cust = (from p in db.Users
                                 join e in db.CustomersTB
                                 on p.Email equals e.Email
                                 where p.Email.Equals(loggedinUser)
                                 join me in db.ClaimsTB
                                 on e.CustID equals me.CustID
                                 // where me.CustID== e.CustID

                                 select new { me.ReportNum, e.CustID, me.ClaimPolicyID, me.DateOI, me.Location, me.DriverName, me.DamageDescription, me.Amount, me.Status }).ToList();

                //  var emailz = show1cust.ToList();
                foreach (var q in show1cust)
                {
                    EmailView.Add(new Claim()
                    {

                        ReportNum = q.ReportNum,
                        CustID = q.CustID,
                        ClaimPolicyID = q.ClaimPolicyID,
                        DateOI = q.DateOI,
                        Location = q.Location,
                        DriverName = q.DriverName,
                        DamageDescription = q.DamageDescription,
                        Amount = q.Amount,
                        Status=q.Status
                        



                    });
                }


                //   }


                return View(EmailView);

                // return View(db.ClaimsTB.ToList());
            }
        }

        // GET: Claims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.ClaimsTB.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportNum,CustID,ClaimPolicyID,,DateOI,Location,DriverName,DamageDescription,Amount,Status")] Claim claim)
        {

           

            if (ModelState.IsValid)
            {

                
                claim.ReportNum = claim.Determinkeyz();
                

                db.ClaimsTB.Add(claim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(claim);
        }



        




        // GET: Claims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.ClaimsTB.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportNum,CustID,ClaimPolicyID,,DateOI,Location,DriverName,DamageDescription,Amount,Status")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = db.ClaimsTB.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim = db.ClaimsTB.Find(id);
            db.ClaimsTB.Remove(claim);
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





        //code for AutoGenerate??

      














    }
}
