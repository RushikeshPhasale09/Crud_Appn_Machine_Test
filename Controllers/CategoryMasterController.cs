using CRUD_Application.Database;
using CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Application.Controllers
{
    public class CategoryMasterController : Controller
    {
        User clsuser = new User();
        // GET: CategoryMaster
        public ActionResult Setup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insertcatdtls(Category insertdtls)
        {
            var response = clsuser.Insertcatdtls(insertdtls);

            return Json(response);
        }

        [HttpPost]
        public ActionResult Getcatdata()
        {
            var response = clsuser.Getcatdata();

            return Json(response);
        }

        [HttpPost]
        public JsonResult Deletecatdata(int id)
        {
            var response = clsuser.Deletecatdata(id);

            return Json(response);
        }
        [HttpPost]
        public ActionResult Editcategorydata(Category catupdate)
        {
            var response = clsuser.editcategorydata(catupdate);

            return Json(response);
        }
    }
}

