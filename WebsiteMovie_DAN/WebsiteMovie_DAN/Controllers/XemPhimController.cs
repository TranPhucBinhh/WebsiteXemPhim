using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebsiteMovie_DAN.Models;
using WebsiteMovie_DAN.Proxy;

namespace WebsiteMovie_DAN.Controllers
{
    public class XemPhimController : Controller
    {
        WebmovieDataContext data = new WebmovieDataContext();
        private readonly IDataContext _data;
        public XemPhimController(IDataContext data)
        {
            _data = data;
        }
        //private List<CTTapPhim> laytap(int id, int count)
        //{

        //    return data.CTTapPhims.Where(m => m.ID == id).Take(count).ToList();
        //}
        //// GET: XemPhim
        //public ActionResult XemPhim(int id, int? tap)
        //{
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    //var Phim = data.CTTapPhims.Where(m => m.ID == id).ToList();
        //    var Phim = data.DSPhimBos.Where(m => m.ID == id).ToList();
        //    int pageSize = 1;
        //    int pageNum = (tap ?? 1);
        //    var a = laytap(id, 1000);
        //    var p = data.CTTapPhims.Where(m => m.TapPhim == tap && m.ID == id).ToList();
        //    ViewData["p"] = p;
        //    return View(a.ToPagedList(pageNum, pageSize));

        //}

        //public ActionResult XemPhimLe(int id)
        //{
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["QuocGia"] = quocgia;
        //    var Phim = data.DSPhimLes.Where(m => m.ID == id).ToList();
        //    return View(Phim);
        //}
        //        public interface IXemPhimProxy
        //        {
        //            List<CTTapPhim> LayTapPhim(int id, int count);
        //            List<DSPhimBo> LayPhimBo(int id);
        //            List<DSPhimLe> LayPhimLe(int id);
        //            List<TheLoai> LayTheLoai();
        //            List<Nam> LayNam();
        //            List<QuocGia> LayQuocGia();
        //        }
        //        public class XemPhimProxy : IXemPhimProxy
        //        {
        //            private readonly WebmovieDataContext _context;

        //            public XemPhimProxy(WebmovieDataContext context)
        //            {
        //                _context = context;
        //            }

        //            public List<CTTapPhim> LayTapPhim(int id, int count)
        //            {
        //                return _context.CTTapPhims.Where(m => m.ID == id).Take(count).ToList();
        //            }

        //            public List<DSPhimBo> LayPhimBo(int id)
        //            {
        //                return _context.DSPhimBos.Where(m => m.ID == id).ToList();
        //            }

        //            public List<DSPhimLe> LayPhimLe(int id)
        //            {
        //                return _context.DSPhimLes.Where(m => m.ID == id).ToList();
        //            }

        //            public List<TheLoai> LayTheLoai()
        //            {
        //                return _context.TheLoais.ToList();
        //            }

        //            public List<Nam> LayNam()
        //            {
        //                return _context.Nams.ToList();
        //            }

        //            public List<QuocGia> LayQuocGia()
        //            {
        //                return _context.QuocGias.ToList();
        //            }
        //        }
        //        public readonly IXemPhimProxy _xemPhimProxy;

        //        public XemPhimController(IXemPhimProxy xemPhimProxy)
        //        {
        //            _xemPhimProxy = xemPhimProxy;
        //        }

        //        private void LoadCommonData()
        //        {
        //            ViewData["TheLoai"] = _xemPhimProxy.LayTheLoai();
        //            ViewData["Nam"] = _xemPhimProxy.LayNam();
        //            ViewData["QuocGia"] = _xemPhimProxy.LayQuocGia();
        //        }

        //        public ActionResult XemPhim(int id, int? tap)
        //        {
        //            LoadCommonData();

        //            var phimBo = _xemPhimProxy.LayPhimBo(id);
        //            if (phimBo == null || !phimBo.Any()) return NotFound();

        //            int pageSize = 1;
        //            int pageNum = tap ?? 1;

        //            var danhSachTap = _xemPhimProxy.LayTapPhim(id, 1000);
        //            var p = danhSachTap.Where(m => m.TapPhim == tap).ToList();

        //            ViewData["p"] = p;
        //            return View(danhSachTap.ToPagedList(pageNum, pageSize));
        //        }

        //        public ActionResult XemPhimLe(int id)
        //        {
        //            LoadCommonData();

        //            var phimLe = _xemPhimProxy.LayPhimLe(id);
        //            if (phimLe == null || !phimLe.Any()) return NotFound();

        //            return View(phimLe);
        //        }

        //        private ActionResult NotFound()
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }
        //}

        
        private void LoadViewData()  //Mẫu proxy
        {
            ViewData["TheLoai"] = _data.GetTheLoais();
            ViewData["Nam"] = _data.GetNams();
            ViewData["QuocGia"] = _data.GetQuocGias();
        }

        public ActionResult XemPhim(int id, int? tap)
        {
            LoadViewData();
            int pageSize = 1;
            int pageNum = tap ?? 1;
            var tapPhims = _data.GetCTTapPhims(id, null, 1000); // Lấy tất cả tập
            var currentTap = _data.GetCTTapPhims(id, tap, 1);   // Lấy tập hiện tại
            ViewData["p"] = currentTap;
            return View(tapPhims.ToPagedList(pageNum, pageSize));
        }

        public ActionResult XemPhimLe(int id)
        {
            LoadViewData();
            var phim = _data.GetDSPhimLes(id);
            return View(phim);
        }
    }
}