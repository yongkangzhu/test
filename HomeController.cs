using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_dot_net_csharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult uploadfile()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult test()
        {
            HttpPostedFileBase ff = Request.Files["File"];
            if (ff != null && ff.ContentLength != 0)
            {
                var virtualpath = Server.MapPath("Attach/");
                if (!Directory.Exists(virtualpath))
                {
                    Directory.CreateDirectory(virtualpath);
                }
            }
            string filepath = Server.MapPath("Attach/") + ff.FileName;
            ff.SaveAs(filepath);//在服务器上保存上传文件


            //string[] readFile = System.IO.File.ReadAllLines(filepath);//读取txt文档存放在字符数组中
            return View("uploadfile",  (object)"upload succeed!" );

        }


        [HttpPost]  
        public ActionResult getfile(string file)
        {
            //var webroot = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            var webroot1 = "http://" + System.Web.HttpContext.Current.Request.Url.Authority;
            //var webroot = AppDomain.CurrentDomain.BaseDirectory;
            //var root = Server.MapPath("/");
            var filepath = webroot1+ @"/home/Attach/temp.xlsx";
            var br = 0;
            return Redirect(filepath);
        }


    }
}
