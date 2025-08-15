using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMovie_DAN.Models;
using WebsiteMovie_DAN.Repository;

namespace WebsiteMovie_DAN.Controllers
{
    public class LuotThichController : Controller
    {
        //WebmovieDataContext data = new WebmovieDataContext();
        //// GET: LuotThich

        ////Danh sách lượt yêu thích phim bộ
        ////public ActionResult YeuThichPhimBo(string tendn)
        ////{
        ////    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotThich).Take(3).ToList();
        ////    ViewData["TopPhim"] = DSPhimBo;
        ////    var tl = data.TheLoais.ToList();
        ////    var nam = data.Nams.ToList();
        ////    ViewData["TheLoai"] = tl;
        ////    ViewData["Nam"] = nam;
        ////    var quocgia = data.QuocGias.ToList();
        ////    ViewData["QuocGia"] = quocgia;
        ////    var yeuthich = data.LuotThichPhimBos.Where(m => m.TenDN.Equals(tendn)).ToList();
        ////    return View(yeuthich);
        ////}

        //////Thêm yêu thích phim bộ
        ////public ActionResult ThemYeuThichPhimBo(string tendn, int idphim, int id)
        ////{
        ////    var quocgia = data.QuocGias.ToList();
        ////    var tl = data.TheLoais.ToList();
        ////    var nam = data.Nams.ToList();
        ////    ViewData["TheLoai"] = tl;
        ////    ViewData["Nam"] = nam;
        ////    ViewData["QuocGia"] = quocgia;

        ////    LuotThichPhimBo yeuthich = new LuotThichPhimBo();
        ////    var dsphim = data.LuotThichPhimBos.Where(m => m.TenDN == tendn).ToList();
        ////    DSPhimBo a = data.DSPhimBos.SingleOrDefault(n => n.ID == id);
        ////    foreach (var item in dsphim)
        ////    {
        ////        if (item.IDPhim == idphim)
        ////        {
        ////            a.LuotThich += 1;
        ////            UpdateModel(a);

        ////            data.SubmitChanges();
        ////            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        ////        }


        ////    }
        ////    yeuthich.TenDN = tendn;
        ////    yeuthich.IDPhim = idphim;
        ////    data.LuotThichPhimBos.InsertOnSubmit(yeuthich);
        ////    data.SubmitChanges();

        ////    a.LuotThich += 1;
        ////    UpdateModel(a);

        ////    data.SubmitChanges();
        ////    return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        ////}

        //////Xóa yêu thích phim bộ
        ////public ActionResult XoaYeuThichPhimBo(string tendn, int idphim)
        ////{
        ////    LuotThichPhimBo pb = data.LuotThichPhimBos.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
        ////    if (pb == null)
        ////    {
        ////        Response.SubStatusCode = 404;
        ////        return null;
        ////    }
        ////    data.LuotThichPhimBos.DeleteOnSubmit(pb);
        ////    data.SubmitChanges();
        ////    return RedirectToAction("YeuThichPhimBo", new { tendn = pb.TenDN });
        ////}
        //private static WebmovieDataContext _instance;
        //private static readonly object _lock = new object();

        //private static WebmovieDataContext Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (_lock)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new WebmovieDataContext();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}

        //// Load dữ liệu chung
        //private void LoadCommonData()
        //{
        //    ViewData["TopPhim"] = Instance.DSPhimBos.OrderByDescending(x => x.LuotThich).Take(3).ToList();
        //    ViewData["TheLoai"] = Instance.TheLoais.ToList();
        //    ViewData["Nam"] = Instance.Nams.ToList();
        //    ViewData["QuocGia"] = Instance.QuocGias.ToList();
        //}

        //// Danh sách yêu thích phim bộ
        //public ActionResult YeuThichPhimBo(string tendn)
        //{
        //    LoadCommonData();
        //    var yeuthich = Instance.LuotThichPhimBos.Where(m => m.TenDN.Equals(tendn)).ToList();
        //    return View(yeuthich);
        //}

        //// Thêm yêu thích phim bộ
        //public ActionResult ThemYeuThichPhimBo(string tendn, int idphim, int id)
        //{
        //    LoadCommonData();

        //    var a = Instance.DSPhimBos.SingleOrDefault(n => n.ID == id);
        //    if (a == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // Kiểm tra phim đã được yêu thích chưa
        //    bool daYeuThich = Instance.LuotThichPhimBos.Any(m => m.TenDN == tendn && m.IDPhim == idphim);
        //    if (daYeuThich)
        //    {
        //        a.LuotThich += 1;
        //        Instance.SubmitChanges();
        //        return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        //    }

        //    // Nếu chưa yêu thích, thêm mới
        //    var yeuthich = new LuotThichPhimBo
        //    {
        //        TenDN = tendn,
        //        IDPhim = idphim
        //    };
        //    Instance.LuotThichPhimBos.InsertOnSubmit(yeuthich);
        //    Instance.SubmitChanges();

        //    // Cập nhật số lượt thích của phim
        //    a.LuotThich += 1;
        //    Instance.SubmitChanges();

        //    return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        //}

        //// Xóa yêu thích phim bộ
        //public ActionResult XoaYeuThichPhimBo(string tendn, int idphim)
        //{
        //    var pb = Instance.LuotThichPhimBos.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
        //    if (pb == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }

        //    Instance.LuotThichPhimBos.DeleteOnSubmit(pb);
        //    Instance.SubmitChanges();
        //    return RedirectToAction("YeuThichPhimBo", new { tendn = pb.TenDN });
        //}
        WebmovieDataContext data = new WebmovieDataContext();
        private readonly ILuotYeuThichRepository _repository;
        private readonly IRepository<TheLoai> _theLoaiRepository;
        private readonly IRepository<Nam> _namRepository;
        private readonly IRepository<QuocGia> _quocGiaRepository;

        public LuotThichController(
            ILuotYeuThichRepository repository, IRepository<TheLoai> theLoaiRepository, IRepository<Nam> namRepository, IRepository<QuocGia> quocGiaRepository)
        {
            _repository = repository;
            _theLoaiRepository = theLoaiRepository;
            _namRepository = namRepository;
            _quocGiaRepository = quocGiaRepository;
        }
        // GET: LuotThich

        //Danh sách lượt yêu thích phim bộ
        //public ActionResult YeuThichPhimBo(string tendn)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotThich).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    var yeuthich = data.LuotThichPhimBos.Where(m => m.TenDN.Equals(tendn)).ToList();
        //    return View(yeuthich);
        //}

        ////Thêm yêu thích phim bộ
        //public ActionResult ThemYeuThichPhimBo(string tendn, int idphim, int id)
        //{
        //    var quocgia = data.QuocGias.ToList();
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;

        //    LuotThichPhimBo yeuthich = new LuotThichPhimBo();
        //    var dsphim = data.LuotThichPhimBos.Where(m => m.TenDN == tendn).ToList();
        //    DSPhimBo a = data.DSPhimBos.SingleOrDefault(n => n.ID == id);
        //    foreach (var item in dsphim)
        //    {
        //        if (item.IDPhim == idphim)
        //        {
        //            a.LuotThich += 1;
        //            UpdateModel(a);

        //            data.SubmitChanges();
        //            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        //        }


        //    }
        //    yeuthich.TenDN = tendn;
        //    yeuthich.IDPhim = idphim;
        //    data.LuotThichPhimBos.InsertOnSubmit(yeuthich);
        //    data.SubmitChanges();

        //    a.LuotThich += 1;
        //    UpdateModel(a);

        //    data.SubmitChanges();
        //    return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id = a.ID });
        //}

        ////Xóa yêu thích phim bộ
        //public ActionResult XoaYeuThichPhimBo(string tendn, int idphim)
        //{
        //    LuotThichPhimBo pb = data.LuotThichPhimBos.SingleOrDefault(n => n.TenDN == tendn && n.IDPhim == idphim);
        //    if (pb == null)
        //    {
        //        Response.SubStatusCode = 404;
        //        return null;
        //    }
        //    data.LuotThichPhimBos.DeleteOnSubmit(pb);
        //    data.SubmitChanges();
        //    return RedirectToAction("YeuThichPhimBo", new { tendn = pb.TenDN });
        //}


        // repository
        public ActionResult YeuThichPhimBo(string tendn)
        {
            LoadViewData();
            ViewData["TopPhim"] = _repository.GetTopLikedPhimBo(3).ToList();
            var yeuthich = _repository.GetUserLikes(tendn).ToList();
            return View(yeuthich);
        }

        // POST: Thêm yêu thích phim bộ
        public ActionResult ThemYeuThichPhimBo(string tendn, int idphim, int id)
        {
            LoadViewData();
            _repository.AddLike(tendn, idphim);
            return RedirectToAction("ChiTietPhim", "ChiTietPhim", new { id });
        }

        // POST: Xóa yêu thích phim bộ
        public ActionResult XoaYeuThichPhimBo(string tendn, int idphim)
        {
            LoadViewData();
            _repository.RemoveLike(tendn, idphim);
            if (_repository.GetUserLikes(tendn).Any(l => l.IDPhim == idphim))
            {
                Response.SubStatusCode = 404; // Nếu xóa thất bại
                return null;
            }
            return RedirectToAction("YeuThichPhimBo", new { tendn });
        }

        private void LoadViewData()
        {
            ViewData["TheLoai"] = _theLoaiRepository.GetAll();
            ViewData["Nam"] = _namRepository.GetAll();
            ViewData["QuocGia"] = _quocGiaRepository.GetAll();
        }
    }
}
