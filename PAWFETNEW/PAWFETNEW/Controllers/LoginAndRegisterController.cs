using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PAWFETNEW.Models;

namespace PAWFETNEW.Controllers
{
    [HandleError]
    public class LoginAndRegisterController : Controller
    {
        petcareEntities db = new petcareEntities();
        //GET: LoginAndRegister
        #region Login
        public ActionResult Login(string language)
        {
            try
            {
                ViewBag.message = "";
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                return View();
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
          
        }

        [HttpPost]

        public ActionResult Login(Tbl_User user, string language)
        {
            try
            {
                Tbl_User obj = new Tbl_User();
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                //string name = frm["username"];
                string mail = user.Email;

                string pass1 = user.UserPassword;

                //to validate wheather the user exist or not
               
               if(mail==null||pass1==null)
                {
                    ViewBag.message = PAWFETNEW.Resources.MyTexts.LoginErrorMessage;
                    Session["valid"] = "false";
                    return View();
                }
                else
                {
                    string pass = Security.HashSHA1(user.UserPassword);
                    var result = (from existinguser in db.Tbl_User
                                      //change to mail
                                  where existinguser.Email == mail && existinguser.UserPassword == pass
                                  select existinguser).ToList();

                    if (mail == obj.AdminMail && pass1 == obj.AdminPassword)
                    {
                        Session["Valid"] = "true";
                        Session["username"] = obj.AdminName;
                        Session["Authorize"] = "admin";
                        return RedirectToAction("List", "Pets");
                    }
                    else if (result.Count == 1)
                    {
                        var UserName = (from User in db.Tbl_User
                                        where User.Email == mail
                                        select User.UserName).Single();
                        var Userid = (from User in db.Tbl_User
                                      where User.Email == mail
                                      select User.UserID).Single();
                        //var UserDate = (from User in db.Tbl_User
                        //                where User.Email == mail
                        //                select User.date).Single();

                        Tbl_User u = db.Tbl_User.Find(Userid);
                        Session["amount"] = u.Wallet;
                        Session["date"] = user.date;
                        Session["id"] = Userid;
                        Session["Valid"] = "true";
                        Session["username"] = UserName;
                        Session["Authorize"] = "user";
                        return RedirectToAction("Index", "USER");
                    }

                    else
                    {
                        ViewBag.message = PAWFETNEW.Resources.MyTexts.LoginErrorMessage;
                        Session["valid"] = "false";
                        return View();
                    }
               

                }
                

            }
            catch (Exception e)
            {
                return View(e.Message);
            }
           
        }

        #endregion

        #region LogOff
        public ActionResult LogOff()
        {
            try
            {
                Session.Clear();
                return RedirectToAction("GLOBAL","PAWFET");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }

        }
        #endregion

        #region Register
        public ActionResult Register1(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register1(Tbl_User tbl_User)
        {
            if (IsExist(tbl_User.Email))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        tbl_User.ConfirmPassword = Security.HashSHA1(tbl_User.ConfirmPassword);
                        tbl_User.UserPassword = Security.HashSHA1(tbl_User.UserPassword);
                        tbl_User.Wallet = 1000;
                        db.Tbl_User.Add(tbl_User);
                        db.SaveChanges();
                        return View("Login");
                    }
                }
                catch (Exception e)
                {
                    return View(e.Message);
                }
            }
            else
            {
                ModelState.AddModelError("Email", "The email already exist");
            }

            return View(tbl_User);
        }
        #endregion

        #region List
        public ActionResult List()
        {
            return View();
        }
        #endregion
        #region IsExist
        public bool IsExist(string Email)
        {
            var result = (from user in db.Tbl_User
                          where user.Email== Email
                          select user).ToList();
            if (result.Count != 0)
                return false;
            else
                return true;
        }
        public JsonResult IsUserExist(string Email)
        {
            return IsExist(Email) ?
                Json(true, JsonRequestBehavior.AllowGet) :
                Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }


}