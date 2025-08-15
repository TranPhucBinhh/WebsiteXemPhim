using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMovie_DAN.Models;

namespace WebsiteMovie_DAN.Controllers
{
    public class XemSauController : Controller
    {
        //WebmovieDataContext data = new WebmovieDataContext();
        //GET: XemSau
        //public ActionResult Index(string tendn)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();    Lấy top 3 phim bộ có lượt xem cao nhất
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    var hopphim = data.HopPhims.Where(m => m.TenDN.Equals(tendn)).ToList();   lấy ds phim người dùng thêm vào xem sau        
        //    return View(hopphim);
        //}

        //public ActionResult ThemVaoXemSau(string tendn, int idphim)
        //{
        //    var quocgia = data.QuocGias.ToList();
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        // Lấy dữ liệu cơ bản
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;
        // Kiểm tra xem phim này đã có trong danh sách xem sau chưa
        //    HopPhim phim = new HopPhim();
        //    var dsphim = data.HopPhims.Where(m => m.TenDN == tendn).ToList();
        //    foreach (var item in dsphim)
        //    {
        //        if (item.IDPhim == idphim)
        //            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = item.IDPhim });
        //    }
        //    phim.TenDN = tendn;
        //    phim.IDPhim = idphim;
        //    data.HopPhims.InsertOnSubmit(phim);
        //    data.SubmitChanges();
        //    return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = idphim });
        //}
        //public ActionResult XoaXemSau(string tendn, int idphim)
        //{
        //    HopPhim tl = data.HopPhims.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
        //    if (tl == null)
        //    {
        //        Response.SubStatusCode = 404;
        //        return null;
        //    }
        //    data.HopPhims.DeleteOnSubmit(tl);
        //    data.SubmitChanges();
        //    return RedirectToAction("Index", new { tendn = tl.TenDN });
        //}
        private static WebmovieDataContext _instance;
        private static readonly object _lock = new object();

                                 // Mẫu single ton
        private static WebmovieDataContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebmovieDataContext();
                        }
                    }
                }
                return _instance;
            }
        }

        // Lấy dữ liệu chung (Thể loại, Năm, Quốc gia)
        private void LoadCommonData()
        {
            ViewData["TopPhim"] = Instance.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
            ViewData["TheLoai"] = Instance.TheLoais.ToList();
            ViewData["Nam"] = Instance.Nams.ToList();
            ViewData["QuocGia"] = Instance.QuocGias.ToList();
        }

        // Danh sách phim xem sau
        public ActionResult Index(string tendn)
        {
            LoadCommonData();
            var hopPhim = Instance.HopPhims.Where(m => m.TenDN.Equals(tendn)).ToList();
            return View(hopPhim);
        }

        // Thêm phim vào danh sách Xem Sau
        public ActionResult ThemVaoXemSau(string tendn, int idphim)
        {
            LoadCommonData();

            // Kiểm tra nếu phim đã có trong danh sách
            var phimTonTai = Instance.HopPhims.Any(m => m.TenDN == tendn && m.IDPhim == idphim);
            if (phimTonTai)
            {
                return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = idphim });
            }

            // Thêm phim vào danh sách Xem Sau
            var phim = new HopPhim { TenDN = tendn, IDPhim = idphim };
            Instance.HopPhims.InsertOnSubmit(phim);
            Instance.SubmitChanges();

            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = idphim });
        }

        // Xóa phim khỏi danh sách Xem Sau
        public ActionResult XoaXemSau(string tendn, int idphim)
        {
            var phim = Instance.HopPhims.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
            if (phim == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }

            Instance.HopPhims.DeleteOnSubmit(phim);
            Instance.SubmitChanges();

            return RedirectToAction("Index", new { tendn = tendn });
        }
    }
}