using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.ViewModel;
using ShopBridge.Models;
using ShopBridge.ViewModel;


namespace ShopBridge.Controllers
{
    public class ProductShowController : Controller
    {
        ShopDetailsDataEntities1 db = new ShopDetailsDataEntities1();
        // GET: /ProductShow/

        public ActionResult Index(int Id)
        {
            tbl_shop ts = db.tbl_shop.Single(x => x.Id == Id);
            return View(ts);
        }


        public ActionResult Edit(int Id)
        {
            tbl_shop ts = db.tbl_shop.Single(x => x.Id == Id);
            return View(ts);
        }

        [HttpPost]
        public ActionResult Edit(tbl_shop OBJSD)
        {
            //tbl_shop ts = new tbl_shop();
            var Data = db.tbl_shop.Where(s => s.Id == OBJSD.Id).FirstOrDefault();

            // db.tbl_shop.Remove(Data);
            // tbl_shop ts = new tbl_shop();
            if (Data != null)
            {
                Data.Name = OBJSD.Name;
                Data.Price_ = OBJSD.Price_;
                Data.Descreption = OBJSD.Descreption;
                //ts.Imagepath = OBJSD.Imagepath;
                //db.tbl_shop.Add(ts);
                db.SaveChanges();
                string message = string.Empty;
                if (OBJSD != null)
                {
                    message = "Your Data is Update Successfully";
                }
                ViewBag.Message = message;
                // ModelState.Clear();
            }

            return RedirectToAction("GetDetails", "Shop");
        }

        public ActionResult Delete(int id)
        {
           // SessionData sessionData = db.SessionDatas.Find(id);
            tbl_shop ts = db.tbl_shop.Single(x => x.Id == id);
            db.tbl_shop.Remove(ts);
            db.SaveChanges();
            return RedirectToAction("GetDetails", "Shop");
        }

    }
}
