using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAWFETNEW.Models;
using System.Data.Entity;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class DayCareController : Controller
    {
        private petcareEntities db = new petcareEntities();

        // GET: Tbl_DayCare
        #region Index
        public ActionResult Index()
        {
            try
            {
                var tbl_DayCare = db.Tbl_DayCare.Include(t => t.Tbl_Service).Include(t => t.Tbl_User);
                return View(tbl_DayCare.ToList());
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion

        // GET: Tbl_DayCare/Delete/5
        #region delete
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_DayCare tbl_DayCare = db.Tbl_DayCare.Find(id);
                if (tbl_DayCare == null)
                {
                    return HttpNotFound();
                }

                db.Tbl_DayCare.Remove(tbl_DayCare);
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