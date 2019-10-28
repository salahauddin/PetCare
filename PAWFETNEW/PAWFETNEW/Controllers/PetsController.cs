using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class PetsController : Controller
    {
        private petcareEntities db = new petcareEntities();
        Tbl_Pets tb = new Tbl_Pets();
       

        #region List
        public ActionResult List()
        {
            try
            {
                return View(db.Tbl_Pets.ToList());
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        // GET: Pets/Details/5

        #region Details
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Pets tbl_Pets = db.Tbl_Pets.Find(id);
                if (tbl_Pets == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Pets);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        // GET: Pets/Create

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

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Pets tbl_Pets, HttpPostedFileBase ImageUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    filename = filename + extension;
                    tbl_Pets.img_location = "~/Models/img/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Models/img/"), filename);
                    ImageUpload.SaveAs(filename);
                    db.Tbl_Pets.Add(tbl_Pets);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }


                return View(tbl_Pets);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }


        }
        #endregion

        // GET: Pets/Edit/5
        #region Edit
        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tbl_Pets tbl_Pets = db.Tbl_Pets.Find(id);
                if (tbl_Pets == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Pets);
            }
            catch (Exception e)
            {
                Response.Write("cannot edit");

            }
            return RedirectToAction("List");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Pets tbl_Pets, HttpPostedFileBase ImageUpload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUpload == null)
                    {
                        tb.PetID = tbl_Pets.PetID;
                        tb.Pet_Breed = tbl_Pets.Pet_Breed;
                        tb.Pet_Category = tbl_Pets.Pet_Category;
                        tb.Pet_Price = tbl_Pets.Pet_Price;
                        tb.Sex = tbl_Pets.Sex;
                        tb.Height = tbl_Pets.Height;
                        tb.Weights = tbl_Pets.Weights;

                        db.Entry(tbl_Pets).State = EntityState.Modified;
                        //db.SaveChanges();
                        return RedirectToAction("List");
                    }
                    else
                    {
                        string filename = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                        string extension = Path.GetExtension(ImageUpload.FileName);
                        filename = filename + extension;
                        tbl_Pets.img_location = "~/Images/" + filename;
                        tb.PetID = tbl_Pets.PetID;
                        tb.Pet_Breed = tbl_Pets.Pet_Breed;
                        tb.Pet_Category = tbl_Pets.Pet_Category;
                        tb.Pet_Price = tbl_Pets.Pet_Price;
                        tb.Sex = tbl_Pets.Sex;
                        tb.Height = tbl_Pets.Height;
                        tb.Weights = tbl_Pets.Weights;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        ImageUpload.SaveAs(filename);
                        db.Entry(tbl_Pets).State = EntityState.Modified;
                        //db.SaveChanges();
                        return RedirectToAction("List");
                    }
                }
                return View(tbl_Pets);
            }
            catch (Exception e)
            {
                Response.Write("cannot edit");
            }
            return RedirectToAction("List");
        }

        #endregion
        // GET: Pets/Delete/5
        #region Delete
        public ActionResult Delete1(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Tbl_Pets t = db.Tbl_Pets.Find(id);
                db.Tbl_Pets.Remove(t);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
       
    #endregion
}