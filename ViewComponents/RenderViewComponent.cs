using Microsoft.AspNetCore.Mvc;
using onthi.Models;

namespace onthi.ViewComponents
{
	public class RenderViewComponent:ViewComponent
	{
		private QlhangHoaContext db;
		private List<LoaiHang> lh;
		public RenderViewComponent(QlhangHoaContext db)
		{
			this.db = db;
			lh=db.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			return View("RenderMenu", lh);
		}

	}
}
