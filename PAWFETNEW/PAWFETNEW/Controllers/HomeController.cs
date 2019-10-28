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
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
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
    }
}