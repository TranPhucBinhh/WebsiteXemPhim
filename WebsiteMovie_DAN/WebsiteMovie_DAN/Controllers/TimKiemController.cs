using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMovie_DAN.Models;
using PagedList;
using PagedList.Mvc;
using WebsiteMovie_DAN.Entity;
namespace WebsiteMovie_DAN.Controllers
{
    public class TimKiemController : Controller
    {

        //GET: /TimKiem/
        WebmovieDataContext data = new WebmovieDataContext();//truy cập dữ liêu cua linQ
        //kết nối entity để truy cập lịch sử
        WebmoviedbEntities db = new WebmoviedbEntities(); 

                        //code cũ 
        //public ActionResult TimKiemTheLoai(int id)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var Phim = data.DSPhimBos.Where(m => m.IDTheLoai == id);
        //    return View(Phim);
        //}
        //public ActionResult TimKiemNam(int id)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;
        //    var Phim = data.DSPhimBos.Where(m => m.NamPhatHanh == id);
        //    return View(Phim);
        //}
        //public ActionResult TimKiemQuocGia(int id)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;
        //    var Phim = data.DSPhimBos.Where(m => m.MaQG == id);
        //    return View(Phim);
        //}

                          //code theo mẫu Strategy
        private readonly TimKiemContext timKiemContext = new TimKiemContext();

        public ActionResult TimKiem(string type, int id)
        {
            // Cấu hình Strategy theo loại tìm kiếm
            switch (type)
            {
                case "TheLoai":
                    timKiemContext.SetStrategy(new TimKiemTheoTheLoai());
                    break;
                case "Nam":
                    timKiemContext.SetStrategy(new TimKiemTheoNam());
                    break;
                case "QuocGia":
                    timKiemContext.SetStrategy(new TimKiemTheoQuocGia());
                    break;
                default:
                    return HttpNotFound();
            }

            // Lấy dữ liệu phim theo chiến lược đã chọn
            var phim = timKiemContext.TimKiem(data, id);

            // Lấy dữ liệu hiển thị
            ViewData["TopPhim"] = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TheLoai"] = data.TheLoais.ToList();
            ViewData["Nam"] = data.Nams.ToList();
            ViewData["QuocGia"] = data.QuocGias.ToList();
            return View(phim);
        }
    }
}
