using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_SanPham
    {
        private int maHang;
        private string tenHang;
        private int soLuong;
        private float donGiaBan;
        private float donGiaNhap;
        private string giaChu;
        private string emailNV;
        private string hinhAnh;
        public int mahang
        {
            get
            {
                return maHang;
            }
            set
            {
                maHang = value;
            }
        }
        public string tenhang
        {
            get
            {
                return tenHang;
            }
            set
            {
                tenHang = value;
            }
        }
        public int soluong
        {
            get
            {
                return soLuong;
            }
            set
            {
                soLuong = value;
            }
        }
        public float dongiaban
        {
            get
            {
                return donGiaBan;
            }
            set
            {
                donGiaBan = value;
            }
        }
        public float dongianhap
        {
            get
            {
                return donGiaNhap;
            }
            set
            {
                donGiaNhap = value;
            }
        }
        public string giachu
        {
            get
            {
                return giaChu;
            }
            set
            {
                giaChu = value;
            }
        }
        public string emailnv
        {
            get
            {
                return emailNV;
            }
            set
            {
                emailNV = value;
            }
        }
        public string hinhanh
        {
            get
            {
                return hinhAnh;
            }
            set
            {
                hinhAnh = value;
            }
        }
        public DTO_SanPham(string tenhang, int soluong, float dongiaban, float dongianhap, string giachu, string emailnv, string hinhanh)
        {
            this.tenHang = tenhang;
            this.soLuong = soluong;
            this.donGiaNhap = dongianhap;
            this.dongiaban = dongiaban;
            this.giaChu = giachu;
            this.emailNV = emailnv;
            this.hinhAnh = hinhanh;
        }
        public DTO_SanPham(int mahang ,string tenhang, int soluong, float dongiaban, float dongianhap, string giachu, string hinhanh)
        {
            this.maHang = mahang;
            this.tenHang = tenhang;
            this.soLuong = soluong;
            this.donGiaNhap = dongianhap;
            this.dongiaban = dongiaban;
            this.giaChu = giachu;
            this.hinhAnh = hinhanh;
        }

    }
}
