using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    //[Authorize]
    [NoDirectAccess]
    [HandleError]
    public class UserController : Controller
    {
        petcareEntities db = new petcareEntities();
        // GET: User
      
        public ActionResult Index()
        {
            
                return View();
            
            
        }

        #region Adoption
        public ActionResult adopt( int id )
        {
            try
            {
                Tbl_Pets p = db.Tbl_Pets.Find(id);
                int cost = Convert.ToInt32(p.Pet_Price);
                int userid = Convert.ToInt32(Session["id"]);
                Tbl_User u = db.Tbl_User.Find(userid);

                int h = u.Wallet-cost;
                


                if ((h ) > 0)
                {
                    db.taken(p.PetID);
                    db.amount(u.UserID, h);

                    Session["amount"] = h;
                    ViewBag.SuccessMessage = "Thank You for Your Adoption!The amount has been debited from your Wallet";
                    Session["SuccessMessage"] = "Thank You for Your Adoption!The amount has been debited from your Wallet";
                    TempData["SuccessMessage"]= "Thank You for Your Adoption!The amount has been debited from your Wallet";
                    return RedirectToAction("Index", "USER");

                }
                ViewBag.FailureMessage = "Sorry You dont have sufficient balance. Please recharge and try again";
               Session["FailureMessage"] = "Sorry You dont have sufficient balance. Please recharge and try again";
                TempData["FailureMessage"] = "Sorry You dont have sufficient balance. Please recharge and try again";
                return RedirectToAction("Recharge");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
           
        }


        public ActionResult Adoption()
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

        #region Adoption_Dog
        public ActionResult Adoption_Dog()
        {
            Tbl_Pets pets = new Tbl_Pets();
            Tbl_User user = new Tbl_User();
            var userid=Session["id"];
            user = db.Tbl_User.Find(userid);
            ViewBag.Amount=Convert.ToUInt32(user.Wallet);
            string[] category = new string[] { "dog", "Dogs" };

            try
            {
                var result = (from cat in db.Tbl_Pets
                             where cat.Pet_Category == "Dog" || cat.Pet_Category == "Dogs" || cat.Pet_Category == "dogs" || cat.Pet_Category == "dog"
                            && cat.taken == "Not"
                             select cat);
                return View(result.ToList());

            }
            catch (Exception)
            {
                Response.Write("Something went wrong");
            }
            return View();
        }
        #endregion

        #region Adoption_Cat
        public ActionResult Adoption_Cat()
        {
            Tbl_Pets pets = new Tbl_Pets();
            string[] category = new string[] { "cat", "Cat" };

            try
            {
                var result = from cat in db.Tbl_Pets
                             where cat.Pet_Category == "cat" || cat.Pet_Category == "Cat" || cat.Pet_Category == "Cats" || cat.Pet_Category == "cats"
                            && cat.taken == "Not"
                             select cat;
                return View(result.ToList());

            }
            catch (Exception)
            {
                Response.Write("Something went wrong");
            }
            return View();
        }
        #endregion

        #region Adoption_Fish
        public ActionResult Adoption_Fish()
        {
            Tbl_Pets pets = new Tbl_Pets();
            string[] category = new string[] { "fish", "Fish" };

            try
            {
                var result = from cat in db.Tbl_Pets
                             where cat.Pet_Category == "fish" || cat.Pet_Category == "Fish" && cat.taken == "Not"
                             select cat;
                return View(result.ToList());

            }
            catch (Exception)
            {
                Response.Write("Something went wrong");
            }
            return View();
        }
        #endregion

        #region Adoption_Birds
        public ActionResult Adoption_Birds()
        {
            Tbl_Pets pets = new Tbl_Pets();
            string[] category = new string[] { "birds", "Birds" };

            try
            {
                var result = from cat in db.Tbl_Pets
                             where cat.Pet_Category == "Birds" || cat.Pet_Category == "Bird" || cat.Pet_Category == "bird" || cat.Pet_Category == "birds"
                             && cat.taken == "Not"
                             select cat;
                return View(result.ToList());

            }
            catch (Exception)
            {
                Response.Write("Something went wrong");
            }
            return View();
        }
        #endregion

        #region DayCare
        public ActionResult DayCare()
        {
            //var item = Session["username"];
            //var id = (from user in db.Tbl_User
            //          where user.UserName == item
            //          select user).Single();
            try
            {
                ViewBag.data = (from p in db.Tbl_Pets

                                select p.Pet_Category).Distinct().ToList();
           

                ViewBag.ServiceType = (from p in db.Tbl_Service
                                       select p.Service_Type).ToList();

                ViewBag.ServiceDescriptionNormal = (from service1 in db.Tbl_Service
                                              where service1.Service_Id==1000
                                   select service1.Description).Single();
                ViewBag.ServiceDescriptionSpecial = (from service1 in db.Tbl_Service
                                                    where service1.Service_Id == 1001
                                                    select service1.Description).Single();

            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DayCare(Tbl_DayCare tbl_DayCare, FormCollection frm)
        {
            var category = frm["PetCategory"].ToString();
            var service = frm["Service_id"].ToString();

            //if (string.IsNullOrEmpty(frm["PetCategory"])|| string.IsNullOrEmpty(frm["Service_id"]))
            //{
            //    ModelState.AddModelError("PetCategory", "Please select some pet category");
            //    ModelState.AddModelError("Service_id", "Please select some services");
            //}
            if (category == "" || service == "")
            {
                ModelState.AddModelError("PetCategory", "Please select some pet category");
                ModelState.AddModelError("Service_id", "Please select some services");

            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        //var category = frm["PetCategory"].ToString();
                        //var service = frm["Service_id"].ToString();
                        tbl_DayCare.PetCategory = category;

                        ViewBag.Service_id = new SelectList(db.Tbl_Service, "Service_Id", "Service_Type", tbl_DayCare.Service_id);
                        ViewBag.UserID = new SelectList(db.Tbl_User, "UserID", "UserName", tbl_DayCare.UserID);

                       
                        var servicetype = (from servicetable in db.Tbl_Service
                                           where servicetable.Service_Type == service
                                           select servicetable.Service_Id).Single();


                        tbl_DayCare.Service_id = servicetype;
                        var Userid = Convert.ToInt32(Session["id"]);
                        tbl_DayCare.UserID = Userid;
                        db.Tbl_DayCare.Add(tbl_DayCare);
                        db.SaveChanges();
                        return RedirectToAction("Index");


                    }
                    catch (Exception e)
                    {
                        return View(e.Message);
                    }
                }
            }
            return View();


        }
        #endregion

        #region Medical Asssistance

        public ActionResult MedicalAssistance1()
        {
            ViewBag.DoctorId = new SelectList(db.Tbl_Doctor, "DoctorID", "Doctor_Name");
            ViewBag.UserID = new SelectList(db.Tbl_User, "UserID", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult MedicalAssistance1( Tbl_MedicalAssistance tbl_MedicalAssistance)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var item = Session["username"].ToString();

                    var Userid = (from User in db.Tbl_User
                                  where User.UserName == item
                                  select User.UserID).Single();
                    int userid = Convert.ToInt32(Session["id"]);
                    Tbl_User u = db.Tbl_User.Find(userid);

                    int h = u.Wallet - 100;

                    Session["amount"] = h;
                    db.amount(userid,h);


                    tbl_MedicalAssistance.UserID = Userid;
                db.Tbl_MedicalAssistance.Add(tbl_MedicalAssistance);
                db.SaveChanges();


                
                    ///mail meassage object


                }
                catch (Exception e)
                {
                    Console.WriteLine("Please Enter valid EmailID");

                }
                return RedirectToAction("Index", "USER");
            }

            ViewBag.DoctorId = new SelectList(db.Tbl_Doctor, "DoctorID", "Doctor_Name", tbl_MedicalAssistance.DoctorId);
            ViewBag.UserID = new SelectList(db.Tbl_User, "UserID", "UserName", tbl_MedicalAssistance.UserID);
            return View(tbl_MedicalAssistance);
        }
        #endregion


        #region Recharge
        public ActionResult Recharge()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Recharge(Tbl_User user1)
        {

            var item = Session["username"].ToString();

            var Userid = (from User in db.Tbl_User
                          where User.UserName == item
                          select User.UserID).Single();
            int amount = user1.Wallet;

           amount= Convert.ToInt32(Session["amount"]) + amount;

            Session["amount"] = amount;

            int id = Convert.ToInt32(Userid);

            db.amount(id, amount);

            return RedirectToAction("Index");

        }
        #endregion
    }





}