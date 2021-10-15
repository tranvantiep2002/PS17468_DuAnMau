using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private string tenNhanVien;
        private string diaChi;
        private int vaitro;
        private string emailNv;
        private string matKhau;
        private int tinhTrang;
        public string TenNhanVien
        {
            get
            {
                return tenNhanVien;
            }
            set
            {
                tenNhanVien = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diaChi;
            }
            set
            {
                diaChi = value;
            }
        }
        public int VaiTro
        {
            get
            {
                return vaitro;
            }
            set
            {
                vaitro = value;
            }
        }
        public string EmailNV
        {
            get
            {
                return emailNv;
            }
            set
            {
                emailNv = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public int TinhTrang
        {
            get
            {
                return tinhTrang;
            }
            set
            {
                tinhTrang = value;
            }
        }
        public DTO_NhanVien(string emailNV, string tenNV, string diachi, int vaiTro, int tinhtrang, string matkhau)
        {
            this.tenNhanVien = tenNV;
            this.diaChi = diachi;
            this.vaitro = vaiTro;
            this.emailNv = emailNV;
            this.tinhTrang = tinhtrang;
            this.matKhau = matkhau;
        }
        public DTO_NhanVien(string emailNV, string tenNV, string diachi, int VaiTro, int TinhTrang)
        {
            this.tenNhanVien = tenNV;
            this.diaChi = diachi;
            this.vaitro = VaiTro;
            this.emailNv = emailNV;
            this.tinhTrang = TinhTrang;
        }

        public DTO_NhanVien()
        {
        }
    }
}
