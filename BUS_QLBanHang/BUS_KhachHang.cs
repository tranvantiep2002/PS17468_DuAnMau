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
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();
        public DataTable getKhachHang()
        {
            return dalKhachHang.getKhach();
        }
        public bool InsertKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.InsertKhachHang(kh);
        }
        public bool UpdateKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.UpdateKhachHang(kh);
        }
        public bool DeleteKhachHang(string sodienthoai)
        {
            return dalKhachHang.DeleteKhachHang(sodienthoai);
        }
        public DataTable SearchKhachHang(string sodienthoai)
        {
            return dalKhachHang.SearchKhachHang(sodienthoai);
        }
    }
}
