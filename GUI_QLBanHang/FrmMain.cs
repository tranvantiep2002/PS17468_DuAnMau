using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FrmMain : Form
    {
        public static int session = 0;// kiểm tra tình trạng login
        public static int profile = 0;
        public static string mail;// truyền email từ FrmMain cho các form khác
        FrmLogin login;
        public FrmMain()
        {
            InitializeComponent();
        }
        // Khi Load Form
        public void FrmMain_Load(object sender, EventArgs e)
        {
            ReSetvalue();
            if(profile == 1)
            {
                ThongTinNVmnuScriptItem.Text = null;
                profile = 0;
            }
        }
        // thiết lập phân quyền khi đăng nhập thành công
        private void ReSetvalue()
        {
            if(session == 1)
            {
                ThongTinNVmnuScriptItem.Text = "Chào " + mail.ToString();
                mnuItemNhanVien.Visible = true;
                mnuDanhMuc.Visible = true;
                mnuItemDangXuat.Enabled = true;
                mnuThongKe.Visible = true;
                mnuItemTKSP.Visible = true;
                mnuItemHoSoNhanVien.Visible = true;
                mnuItemDangNhap.Enabled = false;
                if(int.Parse(login.vaitro) == 0)
                {
                    VaiTroNV(); // Sử dụng chức năng nhân viên bình thường
                }

            }
            else
            {
                mnuItemNhanVien.Visible = false;
                mnuDanhMuc.Visible = false;
                mnuItemDangXuat.Enabled = false;
                mnuThongKe.Visible = false;
                mnuItemTKSP.Visible = false;
                mnuItemHoSoNhanVien.Visible = false;
                mnuItemDangNhap.Enabled = true;
                ThongTinNVmnuScriptItem.Text = null;
            }
        }
        // Nhân viên bình thường
        private void VaiTroNV()
        {
            mnuItemNhanVien.Visible = false;
            mnuItemTKSP.Visible = false;
        }

        // click menu đăng nhập
        private void mnuItemDangNhap_Click(object sender, EventArgs e)
        {
            login = new FrmLogin();
            if (!ckeckExitForm(login.Text))
            {
                login.MdiParent = this.MdiParent;
                login.Show();
                login.FormClosed += new FormClosedEventHandler(FrmLogin_FormClosed);
            }
            else
            {
                FocusFormExit(login.Text);
            }
        }
        // refresh lại form main sau khi tắt form đăng nhập
        void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender,e);
        }
        //hàm focus form đăng nhập khi đã mở
        private void FocusFormExit(string name)
        {
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == name)
                {
                    f.Focus();
                }
            }
        }
        // hàm check xem form đăng nhập đã mở hay chưa
        private bool ckeckExitForm(string name)
        {
            bool check = false; 
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        // click hồ sơ nhân viên
        private void mnuItemHoSoNhanVien_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau doiMatKhau = new FrmDoiMatKhau(mail.Trim().ToString());
            if (!ckeckExitForm("FrmDoiMatKhau"))
            {
                doiMatKhau.MdiParent = this.MdiParent;
                doiMatKhau.FormClosed += new FormClosedEventHandler(FrmDoiMatKhau_formClosed);
                doiMatKhau.Show();
            }
            else
                FocusFormExit(doiMatKhau.Text);
        }

        void FrmDoiMatKhau_formClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender, e);
        }

        private void mnuItemNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien nhanvien = new FrmNhanVien();
            if (!ckeckExitForm(nhanvien.Text))
            {
                nhanvien.MdiParent = this.MdiParent;
                nhanvien.Show();
                nhanvien.FormClosed += new FormClosedEventHandler(FrmNhanVien_FormClosed);
            }
            else
            {
                FocusFormExit(nhanvien.Text);
            }
        }

        void FrmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender, e);
        }
        // sản phẩm
        private void mnuItemSanPham_Click(object sender, EventArgs e)
        {
            FrmSanPham sp = new FrmSanPham();
            if (!ckeckExitForm(sp.Text))
            {
                sp.MdiParent = this.MdiParent;
                sp.Show();
                sp.FormClosed += new FormClosedEventHandler(FrmSanPham_FormClosed);
            }
            else
            {
                FocusFormExit(sp.Text);
            }
        }

        void FrmSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender, e);
        }
        // khách hàng
        private void mnuItemKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang khachhang = new FrmKhachHang();
            if (!ckeckExitForm(khachhang.Text))
            {
                khachhang.MdiParent = this.MdiParent;
                khachhang.Show();
                khachhang.FormClosed += new FormClosedEventHandler(FrmKhachHang_FormClosed);
            }
            else
            {
                FocusFormExit(khachhang.Text);
            }
        }

        void FrmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender, e);
        }

        private void mnuItemDangXuat_Click(object sender, EventArgs e)
        {
            session = 0;
            FrmMain_Load(sender, e);
        }

        private void mnuItemThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemTKSP_Click(object sender, EventArgs e)
        {
            FrmThongKe thongke = new FrmThongKe();
            if (!ckeckExitForm(thongke.Text))
            {
                thongke.MdiParent = this.MdiParent;
                thongke.Show();
                thongke.Refresh();
                thongke.FormClosed += new FormClosedEventHandler(FrmThongke_FormClosed);
            }
            else
            {
                FocusFormExit(thongke.Text);
            }
        }

        void FrmThongke_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_Load(sender, e);
        }
    }
}
