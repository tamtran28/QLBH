using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH.Models;
using System.Data;
using System.Net;
namespace QLBH.Controllers
{
    public class NhanVienController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();
        // GET: NhanVien
        public ActionResult Index()
        {
            // ViewBag.nv = db.nhanviens;
            return View(db.nhanviens);
        }
        [HttpGet]
        public ActionResult themNV()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult themNV([Bind(Include =
"manv,tennv,ngaysinh,phai,diachi,password")]
nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.nhanviens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(nhanvien);
        }
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult themNV([Bind(Include =
        //"manv,tennv,ngaysinh,phai,diachi,password")] nhanvien n)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.nhanviens.Add(n);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            else if (n != null)
        //            {
        //                ViewBag.nv = n;
        //                return View("loiThemNV", n);

        //            }
        //            else
        //            {
        //                ViewBag.nv = null;
        //                return View();
        //            }
        //        }
        //[HttpPost]
        //public Action loiThemNV(Models NhanVien n)
        //{
        //    return View("loiThemNV", "themNV");

        //}
        public ActionResult xoaNV(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //nhanvien n = db.nhanviens.Find(id);
            //if (n == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
            //var ds = db.phieugiaohangs.Where(p => p.manv == n.manv).SingleOrDefault();
            //if (ds != null)
            //    ViewBag.xoaDuoc == true;
            // }
            nhanvien n = db.nhanviens.Find(id);
            int dem = db.phieugiaohangs.Where(p => p.manv == n.manv).ToList().Count();
            ViewBag.flat = dem;
            return View(n);
        }
            [HttpPost, ActionName("xoaNV")]
        public ActionResult xoaNV_Post(string id)
        {
            nhanvien n = db.nhanviens.Find(id);
            db.nhanviens.Remove(n);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}