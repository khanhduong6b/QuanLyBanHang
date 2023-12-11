using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class NhaSanXuatController : Controller
    {
        private QlbhContext db = new QlbhContext();

        public IActionResult Index()
        {
            return View(db.Nhasanxuats);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("Mansx, Tennsx, Diachi")]Nhasanxuat nsx)
        {

            foreach(var item in db.Nhasanxuats)
            {
                if(nsx.Mansx == item.Mansx)
                {
                    ModelState.AddModelError("Mansx", "Ma nha san xuat da ton tai");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                db.Nhasanxuats.Add(nsx);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(nsx);
        }


        public ActionResult Edit(string id)
        {
            var a = db.Nhasanxuats.Find(id);

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Nhasanxuat nsx)
        {
            if (ModelState.IsValid)
            {
                db.Nhasanxuats.Update(nsx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nsx);
        }


        public ActionResult Delete(string id)
        {
            var a = db.Nhasanxuats.Find(id);
            return View(a);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult Delete_post(string id)
        {
            Nhasanxuat? nsx = db.Nhasanxuats.Find(id);
            
            foreach(var item in db.Hanghoas)
            {
                if(nsx.Mansx == item.Mansx)
                {
                    ModelState.AddModelError("Mansx", "Khong the xoa duoc ma nha san xuat");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                db.Nhasanxuats.Remove(nsx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nsx);
        }
    }
}
