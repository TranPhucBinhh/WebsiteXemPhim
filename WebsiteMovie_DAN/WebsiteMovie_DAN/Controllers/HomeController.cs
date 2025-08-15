using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMovie_DAN.Models;
using PagedList;
using PagedList.Mvc;
using WebsiteMovie_DAN.Controllers;

namespace WebsiteMovie_DAN.Controllers
{
    public class HomeController : Controller
    {
        WebmovieDataContext data = new WebmovieDataContext();
        private List<DSPhimBo> LayPhim(int count)
        {
            return data.DSPhimBos.OrderByDescending(a => a.ID).Take(count).ToList();
        }
        public ActionResult Index(int? page)
        {
            var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            var banner1 = data.Banners.Where(a => a.ID == 1).Take(1).ToList();
            ViewData["Banner1"] = banner1;
            var banner2 = data.Banners.Where(a => a.ID == 2).Take(1).ToList();
            ViewData["Banner2"] = banner2;
            var banner3 = data.Banners.Where(a => a.ID == 3).Take(1).ToList();
            ViewData["Banner3"] = banner3;
            var banner4 = data.Banners.Where(a => a.ID == 4).Take(1).ToList();
            ViewData["Banner4"] = banner4;
            var tl = data.TheLoais.ToList();
            var nam = data.Nams.ToList();
            var quocgia = data.QuocGias.ToList();
            ViewData["QuocGia"] = quocgia;
            ViewData["TheLoai"] = tl;
            ViewData["Nam"] = nam;
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var phimmoi = LayPhim(1200);
            var phimle = data.DSPhimLes.ToList();
            ViewData["DSPhimLe"] = phimle;
            return View(phimmoi.ToPagedList(pageNum, pageSize));
        }

        //Thêm Lượt Xem
        public ActionResult LuotXem(int id, int? tap)
        {
            DSPhimBo phim = data.DSPhimBos.SingleOrDefault(n => n.ID == id);

            phim.LuotXem += 1;
            UpdateModel(phim);
            data.SubmitChanges();
            return RedirectToAction("XemPhim", "XemPhim", new { id = phim.ID, tap = 1 });
        }
        public ActionResult LuotXemPhimLe(int id)
        {
            DSPhimLe phim = data.DSPhimLes.SingleOrDefault(n => n.ID == id);

            phim.LuotXem += 1;
            UpdateModel(phim);
            data.SubmitChanges();
            return RedirectToAction("XemPhimLe", "XemPhim", new { id = phim.ID });
        }
        //public ActionResult TimKiem(FormCollection c)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var tim = c["tim"];
        //    var bg = data.DSPhimBos.Where(m => m.TenPhim.Contains(tim) == true).ToList();
        //    return View(bg);
        //}
        public interface ITimKiemStrategy
        {
            List<object> TimKiem(string keyword);
        }
        public class TimKiemPhimBo : ITimKiemStrategy
        {
            private WebmovieDataContext data;

            public TimKiemPhimBo(WebmovieDataContext db)
            {
                data = db;
            }

            public List<object> TimKiem(string keyword)
            {
                return data.DSPhimBos.Where(m => m.TenPhim.Contains(keyword)).Cast<object>().ToList();
            }
        }
        public class TimKiemPhimLe : ITimKiemStrategy
        {
            private WebmovieDataContext data;

            public TimKiemPhimLe(WebmovieDataContext db)
            {
                data = db;
            }

            public List<object> TimKiem(string keyword)
            {
                return data.DSPhimLes.Where(m => m.TenPhim.Contains(keyword)).Cast<object>().ToList();
            }
        }
        public class TimKiemContext
        {
            private ITimKiemStrategy _strategy;

            public void SetStrategy(ITimKiemStrategy strategy)
            {
                _strategy = strategy;
            }

            public List<object> ThucHienTimKiem(string keyword)
            {
                return _strategy?.TimKiem(keyword) ?? new List<object>();
            }
        }
        public ActionResult TimKiem(FormCollection c)
        {
            var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TopPhim"] = DSPhimBo;
            ViewData["QuocGia"] = data.QuocGias.ToList();
            ViewData["TheLoai"] = data.TheLoais.ToList();
            ViewData["Nam"] = data.Nams.ToList();

            var tim = c["tim"];
            if (string.IsNullOrEmpty(tim))
            {
                return View(new List<object>());
            }

            // Strategy Pattern
            var timKiemContext = new TimKiemContext();

            timKiemContext.SetStrategy(new TimKiemPhimBo(data));
            var phimBo = timKiemContext.ThucHienTimKiem(tim);
            timKiemContext.SetStrategy(new TimKiemPhimLe(data));
            var phimLe = timKiemContext.ThucHienTimKiem(tim);

            var ketQua = phimBo.Concat(phimLe).ToList();

            return View(ketQua);
        }
        public ActionResult LuotXemTinTuc(int id)
        {
            tintucphim phim = data.tintucphims.SingleOrDefault(n => n.idtintuc == id);

            phim.luotxem += 1;
            UpdateModel(phim);
            data.SubmitChanges();
            return RedirectToAction("ChiTietTinTuc", "TinTucPhim", new { id = phim.idtintuc });
        }
    }
}