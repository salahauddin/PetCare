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
    public class AdoptionController : Controller
    {
        petcareEntities db = new petcareEntities();
        // GET: Adoption
        /// <summary>
        /// returns the list of data adoption
        /// </summary>
        /// <returns></returns>
        public ActionResult AdoptionList()
        {
            try
            {
                List<Tbl_Adoption> list = db.Tbl_Adoption.ToList();
                return View(list);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
           
        }
    }
}