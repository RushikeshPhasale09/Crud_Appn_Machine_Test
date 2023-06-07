using CRUD_Application.Database;
using CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Application.Controllers
{
    public class ProductMasterController : Controller
    {
        User clsuser = new User();
        // GET: ProductMaster
        public ActionResult Setup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertproductdtls(Product insertdtls)
        {
            var response = clsuser.insertproductdtls(insertdtls);

            return Json(response);
        }

        [HttpPost]
        public ActionResult Getproductdtls()
        {
            var response = clsuser.getproductdtls();

            return Json(response);
        }

        [HttpPost]
        public JsonResult Deleteproductdtls(int id)
        {
            var response = clsuser.deleteproductdtls(id);

            return Json(response);
        }
        [HttpPost]
        public ActionResult Updateproductdtls(Product pdtupdate)
        {
            var response = clsuser.updateproductdtls(pdtupdate);

            return Json(response);
        }
    }
}