using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class DonationController : Controller
    {
        petcareEntities db = new petcareEntities();
        // GET: Donation
        /// <summary>
        /// getting the user and donated amount list
        /// </summary>
        /// <returns></returns>
    #region DonationList
        public ActionResult DonationList()
        {
            
            try
            {

                List<Tbl_Donation> donation = db.Tbl_Donation.ToList();

                return View(donation);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
           
        }
        #endregion

    #region DonationDetails
        public ActionResult DonationDetails(int id)
        {
            try
            {
                Tbl_Donation donation = db.Tbl_Donation.Find(id);
                return View(donation);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            
        }
        #endregion

    }
}