using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projectthree.Models;
using System.ComponentModel;

using Microsoft.AspNet.Identity;

namespace Projectthree.Controllers
{
    public class CustomersController : Controller
    {
         ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers

       

        public ActionResult Index(string searchBy, string search)
        {

               IList<Customer> EmailView = new List<Customer>();
           
            if (User.Identity.GetUserName() == "adminash@gmail.com")
            {
                if (searchBy== "Status")
                {
                    return View(db.CustomersTB.Where(x=>x.Status==search || search==null).ToList());
                }
                else
                {
                    return View(db.CustomersTB.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
                }
              
               // return View(db.CustomersTB.ToList());
            }
            else
            {
                var loggedinUser = User.Identity.GetUserName();
                var show1cust = (from me in db.Users
                                 join e in db.CustomersTB
                                 on me.Email equals e.Email
                                 where me.Email.Equals(loggedinUser)

                                 select new { CustID = e.CustID, FirstName = e.FirstName, Surname = e.Surname, Email = me.Email, CellNum = e.CellNum, HomeNum = e.HomeNum, Address = e.Address, e.Status  }).ToList();
                
                foreach (var q in show1cust)
                {
                    EmailView.Add(new Customer()
                    {
                        
                        CustID = q.CustID,
                        FirstName = q.FirstName,
                        Surname = q.Surname,
                        Email = q.Email,
                        CellNum = q.CellNum,
                        HomeNum = q.HomeNum,
                        Address = q.Address,
                        Status = q.Status

                    });
                }
                
                return View(EmailView);
            }
            
        //      return View(db.CustomersTB.ToList());
    }


        public ActionResult AccVM()
        {
            
                ViewBag.Message = "Accountz Pages";
                List<AccountVM> alist = new List<AccountVM>();
                ApplicationDbContext db = new ApplicationDbContext();

                var loggedinUser = User.Identity.GetUserName();
                var VMb = (from c in db.CustomersTB
                           join v in db.VehiclesTB
                           on c.CustID equals v.CustID
                           where c.Email.Equals(loggedinUser)

                           //  join vp in db.VehiclePricingsTB
                           //   on v.Model equals vp.Model
                           select new { c.CustID, c.FirstName, v.Pricex }).ToList();


                // where c.Email.Equals(User.Identity.IsAuthenticated.ToString())

                //  where c.Email.Equals(User.Identity.IsAuthenticated)


                foreach (var q in VMb)
                {
                    // alist.Add(new AccountVM()

                    AccountVM n = new AccountVM();
                    {

                        n.CustID = q.CustID;
                        n.FirstName = q.FirstName;
                        n.Amount = q.Pricex;

                        alist.Add(n);
                    }


                }
                return View(alist);
           

        }







        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.CustomersTB.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
     /*   public ActionResult ShowEmail(string Em)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var show1cust = (from me in db.Users
                             join e in db.CustomersTB
                             on me.Email equals e.Email
                             select new { e.CustID, e.FirstName, e.Email }).FirstOrDefault();




            return View(show1cust);
        }*/




        public ActionResult Create([Bind(Include = "CustID,FirstName,Surname,Email,CellNum,HomeNum,Address, Status")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer.BuildEmailTemplate(customer.Email);
                db.CustomersTB.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.CustomersTB.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustID,FirstName,Surname,Email,CellNum,HomeNum,Address,Status")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            Customer customer = db.CustomersTB.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            Customer customer = db.CustomersTB.Find(id);
             db.CustomersTB.Add(customer);
            
            db.Entry(customer).State = EntityState.Modified;
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
