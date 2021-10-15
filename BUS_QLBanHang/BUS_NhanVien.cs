using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < encrypt.Length; i++)
            {
                builder.Append(encrypt[i].ToString());
            }
            return builder.ToString();
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }
        public bool TaoMatKhau(string email, string matKhauMoi)
        {
            return dalNhanVien.TaoMatKhau(email, matKhauMoi);
        }
        public DataTable VaiTroNhanVien(string email)
        {
            return dalNhanVien.VaiTroNhanVien(email);
        }
        public bool DoiMK(string email, string matkhaucu, string matkhaumoi)
        {
            return dalNhanVien.DoiMK(email, matkhaucu, matkhaumoi);
        }
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }
        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.InsertNhanVien(nv);
        }
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.UpdateNhanVien(nv);
        }
        public bool TinhTrangNhanVien(string email)
        {
            return dalNhanVien.TinhTrangNhanVien(email);
        }
        public bool XoaNhanVien(string email)
        {
            return dalNhanVien.XoaNhanVien(email);
        }
        public DataTable SearchNhanVien(string tenNhanVien)
        {
            return dalNhanVien.SearchNhanVien(tenNhanVien);
        }
    }
}
