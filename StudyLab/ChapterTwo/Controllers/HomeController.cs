using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChapterTwo.Models;

namespace ChapterTwo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(AddItemModel addItemModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addItemModel);
            }
            return View(addItemModel);
        }

        [HttpGet]
        public JsonResult IsTitleAvailable(string title)
        {
            if (!title.Equals("abcde"))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            string suggestedtitle = title + new Random().Next(1, 100);
            return Json(suggestedtitle, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}