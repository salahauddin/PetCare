using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class DoctorController : Controller
    {
        private petcareEntities db = new petcareEntities();

        // GET: Tbl_Doctor
        #region Index
        public ActionResult Index()
        {
            try
            {
                return View(db.Tbl_Doctor.ToList());
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion
        // GET: Tbl_Doctor/Details/5
        #region Details
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Doctor tbl_Doctor = db.Tbl_Doctor.Find(id);
                if (tbl_Doctor == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Doctor);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion
        // GET: Tbl_Doctor/Create
        #region Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Doctor tbl_Doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbl_Doctor.Add(tbl_Doctor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(tbl_Doctor);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion
        // GET: Tbl_Doctor/Edit/5
        #region Edit
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Doctor tbl_Doctor = db.Tbl_Doctor.Find(id);
                if (tbl_Doctor == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Doctor);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Doctor tbl_Doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Doctor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tbl_Doctor);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion
        // GET: Tbl_Doctor/Delete/5
        #region Delete
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Doctor tbl_Doctor = db.Tbl_Doctor.Find(id);
                if (tbl_Doctor == null)
                {
                    return HttpNotFound();
                }
                db.Tbl_Doctor.Remove(tbl_Doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        #endregion
    }
}