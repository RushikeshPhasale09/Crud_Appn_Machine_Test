using CRUD_Application.Database;
using CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Application.Controllers
{
    public class InquiryMasterController : Controller
    {
        User clsuser = new User();
        // GET: InquiryMaster
        public ActionResult Inquiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowProductData()
        {
            List<Productinq> outputdtls = new List<Productinq>();

            var dtls = clsuser.showproductdata();
           outputdtls=dtls;
            return Json(outputdtls);
        }
        
    }
}