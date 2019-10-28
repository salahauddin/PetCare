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
    public class ServiceController : Controller
    {
        private petcareEntities db = new petcareEntities();

        // GET: Service
        #region Index
        public ActionResult Index()
        {
            try
            {
                return View(db.Tbl_Service.ToList());
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        // GET: Service/Details/5
        #region Details
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Service tbl_Service = db.Tbl_Service.Find(id);
                if (tbl_Service == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Service);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion

        // GET: Service/Create
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

        // POST: Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_Id,Service_Type,amount,Description")] Tbl_Service tbl_Service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tbl_Service.Add(tbl_Service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(tbl_Service);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        // GET: Service/Edit/5
        #region Edit
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Service tbl_Service = db.Tbl_Service.Find(id);
                if (tbl_Service == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Service);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_Id,Service_Type,amount,Description")] Tbl_Service tbl_Service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Service).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tbl_Service);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        // GET: Service/Delete/5
        #region Delete
        public ActionResult Delete(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Service tbl_Service = db.Tbl_Service.Find(id);
                if (tbl_Service == null)
                {
                    return HttpNotFound();
                }
                db.Tbl_Service.Remove(tbl_Service);
                db.SaveChanges();
                return View(tbl_Service);

            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }


        #endregion
    }
}