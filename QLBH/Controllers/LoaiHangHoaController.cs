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
    public class LoaiHangHoaController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();
        // GET: LoaiHangHoa

        public ActionResult Index()
        {
            ViewBag.lhh = db.loaihanghoas;
            return View();
        }
        [HttpGet]
        public ActionResult themLHH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themLHH(loaihanghoa n)
        {
      
            db.loaihanghoas.Add(n);
            db.SaveChanges();  
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult suaLHH(string id)
        {
            loaihanghoa lhh = db.loaihanghoas.Find(id);
            if (lhh == null)
                return HttpNotFound();
            ViewBag.lhh = lhh;
            return View(lhh);
        }
        [HttpPost]
        public ActionResult suaLHH()
        {
            string ma = Request["maloai"].ToString();
            loaihanghoa lhh = db.loaihanghoas.Find(ma);
            if (lhh == null)
                return HttpNotFound();
            lhh.tenloai = Request["tenloai"].ToString();
            
            db.Entry(lhh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult xoaLHH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           loaihanghoa n = db.loaihanghoas.Find(id);
            if (n == null)
            {
                return HttpNotFound();
            }
            ViewBag.lhh = n;
            return View(n);
        }
        [HttpPost, ActionName("xoaLHH")]
        public ActionResult xoaLHH_Post(string id)
        {
            loaihanghoa n = db.loaihanghoas.Find(id);
            db.loaihanghoas.Remove(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}