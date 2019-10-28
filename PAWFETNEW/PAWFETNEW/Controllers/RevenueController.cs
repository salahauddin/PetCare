using PAWFETNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAWFETNEW.Models;
using System.Dynamic;
using Newtonsoft.Json;
using static PAWFETNEW.MvcApplication;

namespace PAWFETNEW.Controllers
{
    [NoDirectAccess]
    [HandleError]
    public class RevenueController : Controller
    {

        petcareEntities db = new petcareEntities();
        // GET: Revenue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Daycare_revenue()
        {

            var model = new Class1();


            model.sum11 = 10000;
            model.sum21 = 10000;
            model.sum31 = 0;
            model.sum41 = 1000;


            int result = db.Tbl_Doctor.Count();



            String start = "2019-08-01", end = "2019-08-31";

            dynamic day = new ExpandoObject();
            dynamic Doc = new ExpandoObject();
            dynamic donate = new ExpandoObject();
            dynamic adopt = new ExpandoObject();



            day = db.Tbl_DayCare_revenue(start, end).ToList();
            Doc = db.Tbl_Doctor_revenue(start, end).ToList();
            donate = db.Tbl_Donation_revenue(start, end).ToList();
            adopt = db.Tbl_Doctor_adoption(start, end).ToList();

            foreach (var h in day)
            {
                Tbl_Service s = db.Tbl_Service.Find(h.Service_id);
                model.sum11 = model.sum11 + (Convert.ToInt32(h.Duration) * Convert.ToInt32(s.amount));

            }

            //foreach(var h in Doc)
            //{
            //  model.sum21= (result*100)-h;

            //}

            foreach (var h in donate)
            {
                model.sum31 = model.sum31 + Convert.ToInt32(h);

            }

            foreach (var h in adopt)
            {
                model.sum41 = model.sum41 + Convert.ToInt32(h);

            }







            model.sum12 = 100;
            model.sum22 = 100;
            model.sum32 = 100;
            model.sum42 = 100;

            start = "2019-09-01"; end = "2019-09-30";
            Doc = db.Tbl_Doctor_revenue(start, end);
            donate = db.Tbl_Donation_revenue(start, end).ToList();
            adopt = db.Tbl_Doctor_adoption(start, end).ToList();

            day = db.Tbl_DayCare_revenue(start, end);

            foreach (var h in day)
            {
                Tbl_Service s = db.Tbl_Service.Find(h.Service_id);
                model.sum12 = model.sum12 + (Convert.ToInt32(h.Duration) * Convert.ToInt32(s.amount));

            }

            //foreach(var h in Doc)

            //     model.sum22 = (result * 100) - h;

            foreach (var h in donate)
            {
                model.sum32 = model.sum32 + Convert.ToInt32(h);

            }

            foreach (var h in adopt)
            {
                model.sum42 = model.sum42 + Convert.ToInt32(h);

            }



            model.sum13 = 100;
            model.sum23 = 100;
            model.sum33 = 100;
            model.sum43 = 100;

            start = "2019-10-01"; end = "2019-10-31";
            Doc = db.Tbl_Doctor_revenue(start, end);
            donate = db.Tbl_Donation_revenue(start, end).ToList();
            adopt = db.Tbl_Doctor_adoption(start, end).ToList();

            day = db.Tbl_DayCare_revenue(start, end);

            foreach (var h in day)
            {

                if (h.Service_id == 1000)
                    model.sum13 = model.sum13 + (Convert.ToInt32(h.Duration) * 50);


                else
                    model.sum13 = model.sum13 + (Convert.ToInt32(h.Duration) * 100);

            }

            //foreach (var h in Doc)

            //    model.sum23 = (result * 100) - h;

            foreach (var h in donate)
            {
                model.sum33 = model.sum33 + Convert.ToInt32(h);

            }

            foreach (var h in adopt)
            {
                model.sum43 = model.sum43 + Convert.ToInt32(h);

            }

            TempData["1"] = model.sum11 + model.sum21 + model.sum31 + model.sum41;
            TempData["2"] = model.sum12 + model.sum22 + model.sum32 + model.sum42;
            TempData["3"] = model.sum13 + model.sum23 + model.sum33 + model.sum43;
            //List<Tbl_DayCare> tb = db.Tbl_DayCare.ToList();

            // foreach(Tbl_DayCare tb1 in tb )
            // {
            //     Tbl_Service s = db.Tbl_Service.Find(tb1.Service_id);
            //     sum = sum + (Convert.ToInt32(tb1.Duration)* Convert.ToInt32(s.amount));

            // }

            TempData["11"] = model.sum11;
            TempData["21"] = model.sum21;
            TempData["31"] = model.sum31;
            TempData["21"] = model.sum21;
            TempData["22"] = model.sum22;
            TempData["23"] = model.sum23;
            TempData["31"] = model.sum31;
            TempData["32"] = model.sum32;
            TempData["33"] = model.sum33;
            TempData["41"] = model.sum41;
            TempData["42"] = model.sum42;
            TempData["43"] = model.sum43;

            TempData.Keep();





            return View(model);

        }

        public ActionResult sepchart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            var model = new Class1();

            int sum1 = Convert.ToInt32(TempData["1"]);
            int sum2 = Convert.ToInt32(TempData["2"]);
            int sum3 = Convert.ToInt32(TempData["3"]);

            dataPoints.Add(new DataPoint("Day_care", (Convert.ToInt32(TempData["11"]))));
            dataPoints.Add(new DataPoint("Medical", (Convert.ToInt32(TempData["21"]))));
            dataPoints.Add(new DataPoint("Donation", (Convert.ToInt32(TempData["31"]))));
            dataPoints.Add(new DataPoint("Pets_sold", (Convert.ToInt32(TempData["41"]))));


            TempData["Message"] = "August Revenue Summary";
            TempData["DataPoints"] = JsonConvert.SerializeObject(dataPoints);

            model.sum11 = Convert.ToInt32(TempData["11"]);
            model.sum12 = Convert.ToInt32(TempData["12"]);
            model.sum13 = Convert.ToInt32(TempData["13"]);
            model.sum21 = Convert.ToInt32(TempData["21"]);
            model.sum22 = Convert.ToInt32(TempData["22"]);
            model.sum23 = Convert.ToInt32(TempData["23"]);
            model.sum31 = Convert.ToInt32(TempData["31"]);
            model.sum32 = Convert.ToInt32(TempData["32"]);
            model.sum33 = Convert.ToInt32(TempData["33"]);
            model.sum41 = Convert.ToInt32(TempData["41"]);
            model.sum42 = Convert.ToInt32(TempData["42"]);
            model.sum43 = Convert.ToInt32(TempData["43"]);


            TempData.Keep();

            return RedirectToAction("sepchart1");
        }

        public ActionResult sepchart1()
        {

            var model = new Class1();

            model.sum11 = Convert.ToInt32(TempData["11"]);
            model.sum12 = Convert.ToInt32(TempData["12"]);
            model.sum13 = Convert.ToInt32(TempData["13"]);
            model.sum21 = Convert.ToInt32(TempData["21"]);
            model.sum22 = Convert.ToInt32(TempData["22"]);
            model.sum23 = Convert.ToInt32(TempData["23"]);
            model.sum31 = Convert.ToInt32(TempData["31"]);
            model.sum32 = Convert.ToInt32(TempData["32"]);
            model.sum33 = Convert.ToInt32(TempData["33"]);
            model.sum41 = Convert.ToInt32(TempData["41"]);
            model.sum42 = Convert.ToInt32(TempData["42"]);
            model.sum43 = Convert.ToInt32(TempData["43"]);

            TempData.Keep();


            return View();
        }


        public ActionResult Augchart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            int sum1 = Convert.ToInt32(TempData["1"]);
            int sum2 = Convert.ToInt32(TempData["2"]);
            int sum3 = Convert.ToInt32(TempData["3"]);

            dataPoints.Add(new DataPoint("Day_care", (Convert.ToInt32(TempData["12"]))));
            dataPoints.Add(new DataPoint("Medical", (Convert.ToInt32(TempData["22"]))));
            dataPoints.Add(new DataPoint("Donation", (Convert.ToInt32(TempData["32"]))));
            dataPoints.Add(new DataPoint("Pets_sold", (Convert.ToInt32(TempData["42"]))));


            TempData["Message"] = "September Revenue Summary";
            TempData["DataPoints"] = JsonConvert.SerializeObject(dataPoints);

            TempData["DataPoints"] = JsonConvert.SerializeObject(dataPoints);

            var model = new Class1();

            model.sum11 = Convert.ToInt32(TempData["11"]);
            model.sum12 = Convert.ToInt32(TempData["12"]);
            model.sum13 = Convert.ToInt32(TempData["13"]);
            model.sum21 = Convert.ToInt32(TempData["21"]);
            model.sum22 = Convert.ToInt32(TempData["22"]);
            model.sum23 = Convert.ToInt32(TempData["23"]);
            model.sum31 = Convert.ToInt32(TempData["31"]);
            model.sum32 = Convert.ToInt32(TempData["32"]);
            model.sum33 = Convert.ToInt32(TempData["33"]);
            model.sum41 = Convert.ToInt32(TempData["41"]);
            model.sum42 = Convert.ToInt32(TempData["42"]);
            model.sum43 = Convert.ToInt32(TempData["43"]);

            TempData.Keep();



            return RedirectToAction("sepchart1");
        }

        public ActionResult Octchart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            int sum1 = Convert.ToInt32(TempData["1"]);
            int sum2 = Convert.ToInt32(TempData["2"]);
            int sum3 = Convert.ToInt32(TempData["3"]);

            dataPoints.Add(new DataPoint("Day_care", (Convert.ToInt32(TempData["13"]))));
            dataPoints.Add(new DataPoint("Medical", (Convert.ToInt32(TempData["23"]))));
            dataPoints.Add(new DataPoint("Donation", (Convert.ToInt32(TempData["33"]))));
            dataPoints.Add(new DataPoint("Pets_sold", (Convert.ToInt32(TempData["43"]))));


            TempData["Message"] = "October Revenue Summary";
            TempData["DataPoints"] = JsonConvert.SerializeObject(dataPoints);

            var model = new Class1();

            model.sum11 = Convert.ToInt32(TempData["11"]);
            model.sum12 = Convert.ToInt32(TempData["12"]);
            model.sum13 = Convert.ToInt32(TempData["13"]);
            model.sum21 = Convert.ToInt32(TempData["21"]);
            model.sum22 = Convert.ToInt32(TempData["22"]);
            model.sum23 = Convert.ToInt32(TempData["23"]);
            model.sum31 = Convert.ToInt32(TempData["31"]);
            model.sum32 = Convert.ToInt32(TempData["32"]);
            model.sum33 = Convert.ToInt32(TempData["33"]);
            model.sum41 = Convert.ToInt32(TempData["41"]);
            model.sum42 = Convert.ToInt32(TempData["42"]);
            model.sum43 = Convert.ToInt32(TempData["43"]);

            TempData.Keep();

            return RedirectToAction("sepchart1");
        }
    }
}