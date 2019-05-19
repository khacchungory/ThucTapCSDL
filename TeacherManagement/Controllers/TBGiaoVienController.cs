﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherManagement.Helpers;
using TeacherManagement.Repository;

namespace TeacherManagement.Controllers
{
    public class TBGiaoVienController : Controller
    {
        private readonly TBGiaoVienRepository _repository = new TBGiaoVienRepository();
        // GET: TBChucVuDang
        public ActionResult Index()
        {
            var list = _repository.GetList();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return View(giaoVien);
        }

        public PartialViewResult ThongTinGiaoVien(string id)
        {
            var hocHamHienTai = _repository.HocHamGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.HocHamHienTai = hocHamHienTai;

            var hocViHienTai = _repository.HocViGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.HocViHienTai = hocViHienTai;

            var donViHienHienTai = _repository.DonViGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.DonViGiaoVienHienTai = donViHienHienTai;

            var chucVuChuyenMonHienTai = _repository.ChuyenMonGiaoVienHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuChuyenMonHienTai = chucVuChuyenMonHienTai;

            var chucVuDangHienTai = _repository.ChucVuDangHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuDang = chucVuDangHienTai;

            var chucVuCQHienTai = _repository.ChucVuChinhQuyenHienTai(Convert.ToInt32(id));
            ViewBag.ChucVuChinhQuyenHienTai = chucVuCQHienTai;

            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return PartialView("_ThongTinGiaoVien", giaoVien);
        }

        public PartialViewResult QuaTrinhHocTap(string id)
        {
            var daiHoc = _repository.LayThongTinDaiHoc(Convert.ToInt32(id));
            ViewBag.LayThongTinDaiHoc = daiHoc;

            var thacSi = _repository.LayThongTinThacSi(Convert.ToInt32(id));
            ViewBag.LayThongTinThacSi = thacSi;

            var tienSi = _repository.LayThongTinTienSi(Convert.ToInt32(id));
            ViewBag.LayThongTinTienSi = tienSi;

            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));

            return PartialView("_QuaTrinhHocTap", giaoVien);
        }
        public PartialViewResult ThamGiaHoatDong(string id)
        {
            var listSchoolYear = CreateSchoolYearExtention.CreateSchoolYear();
            IList<SelectListItem> select = new List<SelectListItem>();
            foreach (var item in listSchoolYear)
            {
                select.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }
            ViewBag.SelectListSchoolYear = select;
            var giaoVien = _repository.LayGiaoVienTheoMaGV(Convert.ToInt32(id));
            return PartialView("_ThamGiaHoatDong", giaoVien);
        }

        public ActionResult ThamGiaHoiDongRenderResult(string id, string NamHoc)
        {
            if (id == null || NamHoc == null) return null;
            var listThamGiaHoiDong = _repository.LayThongTinGiaovienThamGiaHoiDong(int.Parse(id), NamHoc);

            return PartialView("_ThamGiaHoatDongRenderResult", listThamGiaHoiDong);
        }
    }
}