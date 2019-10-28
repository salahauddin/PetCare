using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PAWFETNEW.Models;
using static PAWFETNEW.MvcApplication;

namespace WebApplication1.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class RankingController : Controller
    {
        petcareEntities db = new petcareEntities();

        #region Index  

        // GET: Ranking
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

        #region Show Pet1
        public ActionResult Show1()
        {
            try
            {
                Random r = new Random();
                int id1, id2;

                animals1 aa1;
                animals1 aa2;

                do
                {
                    id1 = r.Next(101, 117);
                    id2 = r.Next(101, 117);

                    aa1 = db.animals1.Find(id1);
                    aa2 = db.animals1.Find(id2);
                } while ((id1 == id2) || (aa1 == null) || (aa2 == null));


                //TempData["lcount"] = 0;
                //TempData["rcount"] = 0;

                TempData["id2"] = id2;
                TempData["id1"] = id1;


                Tbl_Pets a1 = db.Tbl_Pets.Find(aa1.pet_id);
                Tbl_Pets a2 = db.Tbl_Pets.Find(aa2.pet_id);




                TempData["message1"] = a1.img_location;
                TempData["message2"] = a2.img_location;





                return View();

            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            }

        #endregion

        #region Show Pet2
        public ActionResult Show2()
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

        #region Changeright1
        public ActionResult changeright1()
        {

            //int lcount = Convert.ToInt32(TempData["lcount"]);
            //TempData["rcount"] = 0;
            //lcount++;
            //TempData["lcount"] = lcount;
            //TempData["count"];
            try
            {

                int id1 = Convert.ToInt32(TempData["id1"]);
                int id2 = Convert.ToInt32(TempData["id2"]);
                int h = id2;
                animals1 aa1 = db.animals1.Find(id1);
                aa1.ranking++;
                db.SaveChanges();
                animals1 aa2;
                Random r = new Random();
                do
                {
                    id2 = r.Next(101, 117);
                    aa2 = db.animals1.Find(id2);
                } while ((id1 == id2) || (id2 == h) || (aa2 == null));


                Tbl_Pets p1 = db.Tbl_Pets.Find(aa1.pet_id);
                Tbl_Pets p2 = db.Tbl_Pets.Find(aa2.pet_id);



                TempData["message1"] = p1.img_location;
                TempData["id1"] = id1;

                TempData["message2"] = p2.img_location;
                TempData["id2"] = id2;
                return RedirectToAction("Show2");
            }

            catch(Exception e)
            {
                return View(e.Message);
            }

        }

        #endregion

        #region Changeleft1

        public ActionResult changeleft1()
        {
            try
            {
                int id1 = Convert.ToInt32(TempData["id1"]);
                int id2 = Convert.ToInt32(TempData["id2"]);
                int h = id1;
                animals1 aa2 = db.animals1.Find(id2);
                aa2.ranking++;
                db.SaveChanges();
                animals1 aa1;
                Random r = new Random();
                do
                {
                    id1 = r.Next(101, 106);
                    aa1 = db.animals1.Find(id1);
                } while ((id1 == id2) || (id1 == h) || (aa1 == null));

                aa1 = db.animals1.Find(id1);

                Tbl_Pets p1 = db.Tbl_Pets.Find(aa1.pet_id);
                Tbl_Pets p2 = db.Tbl_Pets.Find(aa2.pet_id);
                TempData["message1"] = p1.img_location;
                TempData["id1"] = id1;

                TempData["message2"] = p2.img_location;
                TempData["id2"] = id2;
                return RedirectToAction("Show2");
            }
            
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion

        #region TopList

        public ActionResult top()
        {
            try
            {
                dynamic res = db.proname();

                var result1 = db.proname();



                return View(db.proname().ToList());
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            
        }


    }
    #endregion
}