using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMovie_DAN.Models;
using System.Configuration;
using WebsiteMovie_DAN.Models.Facade;
using WebsiteMovie_DAN.Repository;
using WebsiteMovie_DAN.Facade;

namespace WebsiteMovie_DAN.Controllers
{
    public class TinTucPhimController : Controller
    {
        WebmovieDataContext data = new WebmovieDataContext();
        private ITinTucFacade _tinTucFacade;
        private IRepository<tintucphim> _newRepo;
        public TinTucPhimController(ITinTucFacade tinTucFacade,
            IRepository<tintucphim> newRepo)
        {
            _tinTucFacade = tinTucFacade;
            _newRepo = newRepo;
        }
        // GET: TinTucPhim
        //đoạn kết nối entity

        //public ActionResult TinTuc()
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;
        //    var tt = data.tintucphims.ToList();
        //    return View(tt);
        //}
        //public ActionResult ChiTietTinTuc(int id)
        //{
        //    var DSPhimBo = data.DSPhimBos.OrderByDescending(x => x.LuotXem).Take(3).ToList();
        //    ViewData["TopPhim"] = DSPhimBo;
        //    var tl = data.TheLoais.ToList();
        //    var nam = data.Nams.ToList();
        //    var quocgia = data.QuocGias.ToList();
        //    ViewData["TheLoai"] = tl;
        //    ViewData["Nam"] = nam;
        //    ViewData["QuocGia"] = quocgia;
        //    var tt = data.tintucphims.SingleOrDefault(n => n.idtintuc == id);
        //    return View(tt);
        //}

        //Mẫu facade
        public ActionResult TinTuc()
        {
            var newList = _newRepo.GetAll().ToList();
            CreateViewData();
            return View(newList);
        }

        public ActionResult ChiTietTinTuc(int id)
        {
            var data = _newRepo.Find(x => x.idtintuc == id).FirstOrDefault();
            if (data == null)
            {
                return HttpNotFound();
            }
            CreateViewData();
            return View(data);
        }

        private void CreateViewData()
        {
            var data = _tinTucFacade.GetTinTucData();
            ViewData["TopPhim"] = data.TopPhimBo;
            ViewData["TheLoai"] = data.TheLoais;
            ViewData["Nam"] = data.Nams;
            ViewData["QuocGia"] = data.QuocGias;
        }
    }
}