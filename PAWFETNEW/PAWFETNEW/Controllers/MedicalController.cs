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
    public class MedicalController : Controller
    {
        petcareEntities db = new petcareEntities();
        /// <summary>
        /// admin can view the list of appointments made the user
        /// </summary>
        /// <returns>list of appointment</returns>
        #region list of  appoinment
        public ActionResult ApointmentList()
        {
            try
            {
                List<Tbl_MedicalAssistance> medical = db.Tbl_MedicalAssistance.ToList();

                return View(medical);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion




    }
}