using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.ViewModel;
using ShopBridge.Models;

using System.Web;
using System.IO;



namespace ShopBridge.Controllers
{
    public class ShopController : Controller
    {
        ShopDetailsDataEntities1 db = new ShopDetailsDataEntities1();
        // GET: /Shop/
        [HttpGet]
        public ActionResult Shop()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Shop(ShopData objsd)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    objsd.objresponse = new Response();
                    //string filename = System.IO.Path.GetFileName(ImageData.FileName);
                    objsd.Imagepath = "\\Images\\" + Path.GetFileName(objsd.ImageData.FileName);
                    objsd.ImageData.SaveAs(Server.MapPath("~") + objsd.Imagepath);

                    //string FilePath = "~/Images/" + filename;
                    //objsd.Imagepath = Path.Combine(Server.MapPath("~/Images"), FilePath);
                    //var supportedTypes = new[] { "jpg", "png" };
                    //var fileExt = System.IO.Path.GetExtension(ImageData.FileName).Substring(1);
                    //if (!supportedTypes.Contains(fileExt))
                    //{
                    //    objsd.objresponse.Message = "File Extension Is InValid - Only image file jpg/png Format Accepted";
                    //    return false;
                    //}  
                    if (objsd.Id == 0)
                    {
                        tbl_shop ts = new tbl_shop();
                        ts.Name = objsd.Name;
                        ts.Price_ = objsd.Price;
                        ts.Descreption = objsd.Descreption;
                        ts.Imagepath = objsd.Imagepath;
                        db.tbl_shop.Add(ts);
                        db.SaveChanges();
                        string message = string.Empty;
                        if (objsd != null)
                        {
                            message = "Your Data is Save Successfully" ;
                        }
                        ViewBag.Message = message;
                        ModelState.Clear();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(objsd);

        }

       
        public ActionResult GetDetails()
        {
            var data = db.tbl_shop.ToList();
            return PartialView(data);
        }
    }
}


