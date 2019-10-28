using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pawfect.Models;

namespace Pawfect.Controllers
{
    public class Tbl_UserController : Controller
    {
        private PetCareEntities db = new PetCareEntities();
        
        // GET: Tbl_User
        public ActionResult Index()
        {
            return View(db.Tbl_User.ToList());
        }
        #region Details

        // GET: Tbl_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_User tbl_User = db.Tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }
#endregion

        #region Create
        // GET: Tbl_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Phone_No,UserAddress,Email,UserPassword,ConfirmPassword")] Tbl_User tbl_User)
        {
            if (string.IsNullOrEmpty(tbl_User.UserName))
            {
                ModelState.AddModelError("UserName", "Please enter your name");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbl_User.Add(tbl_User);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

             
            }
            catch(Exception e)
            {
                Response.Write("Error:{0}"+e);
            }
            return View(tbl_User);


        }
        #endregion

        #region Edit
        // GET: Tbl_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_User tbl_User = db.Tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // POST: Tbl_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Phone_No,UserAddress,Email,UserPassword,ConfirmPassword")] Tbl_User tbl_User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                Response.Write("Error : {0}" + e);
            }
           
            return View(tbl_User);
        }
#endregion

        #region Delete
        // GET: Tbl_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_User tbl_User = db.Tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // POST: Tbl_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_User tbl_User = db.Tbl_User.Find(id);
            db.Tbl_User.Remove(tbl_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

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
