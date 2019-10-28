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
    public class MemberController : Controller
    {
        petcareEntities db = new petcareEntities();
        /// <summary>
        /// view the list of users who have registered
        /// </summary>
        /// <returns>list of users</returns>
        // GET: Members
        #region view members
        public ActionResult ViewMembers()
        {
            try
            {
                List<Tbl_User> user = db.Tbl_User.ToList();
                return View(user);
            }
            catch (Exception)
            {
                Response.Write("Cannot display the members");
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}