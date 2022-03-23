using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Jewellery_Shop.Controllers
{
    public class UploadController : System.Web.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [System.Web.Mvc.HttpGet]
        public System.Web.Mvc.ActionResult UploadFile()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}
