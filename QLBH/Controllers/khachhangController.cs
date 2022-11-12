using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH.Controllers
{
    public class khachhangController : Controller
    {
        private QLBHDBContext db = new QLBHDBContext();
        // GET: khachhang
        public ActionResult IndexDangNhap()
        {
            ViewBag.kiemtraDangnhap = null;
            return View();
        }
        public ActionResult dangnhap()
        {
            return View();

        }
    }
}