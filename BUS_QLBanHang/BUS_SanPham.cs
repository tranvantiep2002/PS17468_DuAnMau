using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_SanPham
    {
        DAL_SanPham dalSanPham = new DAL_SanPham();
        public DataTable getSanPham()
        {
            return dalSanPham.getSanPham();
        }
        public bool InsertSanPham(DTO_SanPham sp)
        {
            return dalSanPham.InsertSanPham(sp);
        }
        public bool UpdateSanPham(DTO_SanPham sp)
        {
            return dalSanPham.updateSanPham(sp);
        }
        public bool deleteSanPham(string masanpham)
        {
            return dalSanPham.deleteSanPham(masanpham);
        }
        public DataTable SearchSanPham(string tensanpham)
        {
            return dalSanPham.SearchNhanVien(tensanpham);
        }
    }
}
