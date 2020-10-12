using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.ViewModel;
using ShopBridge.Models;


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

    }
}
