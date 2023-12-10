using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using onthi.Models;

namespace onthi.Controllers
{
    public class TranChienChienController : Controller
    {
        private QlhangHoaContext db;
        public TranChienChienController(QlhangHoaContext db)
		{
			this.db = db;
		}
		public IActionResult TranCongChien_MainContent()
        {
			var hang = db.HangHoas.Where(m => m.Gia > 100).ToList();
			return View(hang);
        }
        public IActionResult LoadHH(int mid)
        {
			var hang = db.HangHoas.Where(m => m.Gia > 100).Where(l => l.MaLoai == mid).ToList();
			return PartialView("LoadHH",hang);
			
		}
		[HttpGet]
		public IActionResult Create()
		{
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
			return View();
		}
		[HttpPost]
		public IActionResult Create(HangHoa h)
		{
			db.HangHoas.Add(h);
			db.SaveChanges();
            return RedirectToAction(nameof(TranCongChien_MainContent));

        }
	}
}
