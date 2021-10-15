using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_KhachHang
    {
        private string soDienThoai;
        private string tenKhach;
        private string diaChi;
        private string phai;
        private string emailKH;
        public string SoDienThoai
        {
            get 
            { 
                return soDienThoai;
            }
            set
            {
                soDienThoai = value;
            }
        }
        public string TenKhach
        {
            get
            {
                return tenKhach;
            }
            set
            {
                tenKhach = value;
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
        public string Phai
        {
            get
            {
                return phai;
            }
            set
            {
                phai = value;
            }
        }
        public string email
        {
            get
            {
                return emailKH;
            }
            set
            {
                emailKH = value;
            }
        }
        public DTO_KhachHang(string soDienThoai, string tenKhach, string diaChi, string phai, string email)
        {
            this.soDienThoai = soDienThoai;
            this.tenKhach = tenKhach;
            this.diaChi = diaChi;
            this.phai = phai;
            this.emailKH = email;
        }

        public DTO_KhachHang(string sodienthoai, string tenKH, string diachi, string phai)
        {
            this.soDienThoai = sodienthoai;
            this.TenKhach = tenKH;
            this.DiaChi = diachi;
            this.Phai = phai;
        }
    }
}
