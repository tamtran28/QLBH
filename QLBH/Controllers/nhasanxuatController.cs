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
    public class nhasanxuatController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();
        // GET: nhasanxuat
       
        public ActionResult Index()
        {
            ViewBag.nsx = db.nhasanxuats;
            return View();
        }
        [HttpGet]
        public ActionResult themNSX()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themNSX(nhasanxuat n)
        {
            db.nhasanxuats.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult suaNSX(string id)
        {
            nhasanxuat nsx = db.nhasanxuats.Find(id);
            if (nsx == null)
                return HttpNotFound();
            ViewBag.nsx = nsx;
            return View(nsx);
        }
        [HttpPost]
        public ActionResult suaNSX()
        {
            string ma = Request["mansx"].ToString();
            nhasanxuat nsx = db.nhasanxuats.Find(ma);
            if (nsx == null)
                return HttpNotFound();
            nsx.tennsx = Request["tennsx"].ToString();
            nsx.diachi = Request["diachi"].ToString();
            db.Entry(nsx).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult xoaNSX(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhasanxuat n = db.nhasanxuats.Find(id);
            if (n == null)
            {
                return HttpNotFound();
            }
            ViewBag.nsx = n;
            return View(n);
        }
        [HttpPost, ActionName("xoaNSX")]
        public ActionResult xoaNSX_Post(string id)
        {
            nhasanxuat n = db.nhasanxuats.Find(id);
            db.nhasanxuats.Remove(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}