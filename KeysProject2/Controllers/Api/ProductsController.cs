using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using KeysProject2.Models;

namespace KeysProject2.Controllers.Api
{
    public class ProductsController : ApiController
    {
        MVC2Entities mvcDB = new MVC2Entities();
        //GET:GetAllProducts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(mvcDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
    }
}
