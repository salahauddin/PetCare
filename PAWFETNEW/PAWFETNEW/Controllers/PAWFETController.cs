using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWFETNEW.Models;

namespace PAWFETNEW.Controllers
{
    [HandleError]
    public class PAWFETController : Controller
    {
        petcareEntities db = new petcareEntities();
        // GET: PAWFET
        #region Global
        public ActionResult GLOBAL()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion

        #region About
        public ActionResult About()
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
        #endregion

        #region Contact
        public ActionResult Contact()
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
        #endregion

        #region Gallery
        //public ActionResult Gallery()
        //{
        //    try
        //    {
        //        List<Tbl_Pets> pets = db.Tbl_Pets.ToList();
        //        return View(pets);
        //    }
        //    catch (Exception e)
        //    {
        //        return View(e.Message);
        //    }
        //}
        public ActionResult Gallery1()
        {
            try
            {
                List<Tbl_Pets> pets = db.Tbl_Pets.ToList();
                return View(pets);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion

     
        #region donation
        public ActionResult Donation1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Donation1(Tbl_Donation donation)
        {
            
          if (ModelState.IsValid)
           {
                try
                {
                    db.Tbl_Donation.Add(donation);
                    db.SaveChanges();
                    TempData["DonationMessage"] = "Thank you for your Donation";
                }
                catch (Exception e)
                {
                    Response.Write(e.Message);
                }
                return View("GLOBAL");
            }
            else
            {
                return View();
            }
           






        }


    }
    #endregion
}