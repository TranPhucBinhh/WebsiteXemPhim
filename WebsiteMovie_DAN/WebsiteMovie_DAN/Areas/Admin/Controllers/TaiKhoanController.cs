using System.Web.Mvc;
using WebsiteMovie_DAN.Facades;
using WebsiteMovie_DAN.Models;
using WebsiteMovie_DAN.Common;

namespace WebsiteMovie_DAN.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanFacade _taiKhoanFacade;

        public TaiKhoanController()
        {
            _taiKhoanFacade = new TaiKhoanFacade();
        }

        // GET: Admin/TaiKhoan
        public ActionResult DSTaiKhoan()
        {
            var tk = _taiKhoanFacade.LayDanhSachTaiKhoan();
            return View(tk);
        }

        //Xóa TK
        public ActionResult XoaTK(string tendn)
        {
            if (_taiKhoanFacade.XoaTaiKhoan(tendn))
            {
                return RedirectToAction("DSTaiKhoan");
            }
            else
            {
                Response.SubStatusCode = 404;
                return null;
            }
        }

        //Thêm TK
        [HttpGet]
        public ActionResult ThemTK()
        {
            return View(new TaiKhoanDTO());
        }

        [HttpPost]
        public ActionResult ThemTK(TaiKhoanDTO tkDTO)
        {
            string tendn = tkDTO.TenDN;
            string mk = tkDTO.MatKhau;
            string em = tkDTO.Email;

            var existingTaiKhoan = _taiKhoanFacade.LayTaiKhoanTheoTenDangNhap(tendn);

            if (string.IsNullOrEmpty(tendn))
                ViewData["Loi"] = "Tên đăng nhập không được để trống !";
            else if (string.IsNullOrEmpty(mk))
                ViewData["Loi1"] = "Mật khẩu không được để trống !";
            else if (string.IsNullOrEmpty(em))
                ViewData["Loi3"] = "Email không được để trống !";
            else if (existingTaiKhoan != null)
                ViewData["Loi2"] = "Đã có tài khoản này";
            else
            {
                var taiKhoan = new TaiKhoan
                {
                    TenDN = tendn,
                    MatKhau = SHA_Hash.SHA1(mk),
                    Email = tkDTO.Email,
                    Quyen = tkDTO.Quyen == "True"
                };

                if (_taiKhoanFacade.ThemTaiKhoan(taiKhoan))
                {
                    return RedirectToAction("DSTaiKhoan");
                }
                else
                {
                    ViewBag.ErrorMessage = "Có lỗi xảy ra khi thêm tài khoản.";
                    return View();
                }
            }

            return View(tkDTO);
        }

        //Sửa
        public ActionResult SuaTK(string tendn)
        {
            var tk = _taiKhoanFacade.LayTaiKhoanTheoTenDangNhap(tendn);
            if (tk == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
            return View(tk);
        }

        [HttpPost]
        public ActionResult SuaTK(string tendn, FormCollection collection)
        {
            var tk = _taiKhoanFacade.LayTaiKhoanTheoTenDangNhap(tendn);
            if (tk == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }

            var mk = collection["MatKhau"];
            var email = collection["Email"];

            if (string.IsNullOrEmpty(mk))
            {
                ViewData["Loi"] = "Không được để trống";
                return View(tk);
            }
            else
            {
                tk.MatKhau = SHA_Hash.SHA1(mk);
                tk.Email = email; // Cập nhật email
                if (_taiKhoanFacade.CapNhatTaiKhoan(tk))
                {
                    return RedirectToAction("DSTaiKhoan");
                }
                else
                {
                    ViewBag.ErrorMessage = "Có lỗi xảy ra khi cập nhật tài khoản.";
                    return View(tk);
                }
            }
        }
    }
}