
namespace GUI_QLBanHang
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mnuOpen = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHoSoNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemTKSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHuongDan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHuongDanSuDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemGioiThieuPhanMem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongTinNVmnuScriptItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuOpen
            // 
            this.mnuOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuOpen.GripMargin = new System.Windows.Forms.Padding(2);
            this.mnuOpen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuThongKe,
            this.mnuHuongDan,
            this.ThongTinNVmnuScriptItem});
            this.mnuOpen.Location = new System.Drawing.Point(0, 0);
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(876, 24);
            this.mnuOpen.TabIndex = 1;
            this.mnuOpen.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemDangNhap,
            this.mnuItemDangXuat,
            this.mnuItemHoSoNhanVien,
            this.mnuItemThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(71, 20);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuItemDangNhap
            // 
            this.mnuItemDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemDangNhap.Image")));
            this.mnuItemDangNhap.Name = "mnuItemDangNhap";
            this.mnuItemDangNhap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuItemDangNhap.Size = new System.Drawing.Size(207, 22);
            this.mnuItemDangNhap.Text = "Đăng Nhập";
            this.mnuItemDangNhap.Click += new System.EventHandler(this.mnuItemDangNhap_Click);
            // 
            // mnuItemDangXuat
            // 
            this.mnuItemDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemDangXuat.Image")));
            this.mnuItemDangXuat.Name = "mnuItemDangXuat";
            this.mnuItemDangXuat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemDangXuat.Size = new System.Drawing.Size(207, 22);
            this.mnuItemDangXuat.Text = "Đăng Xuất";
            this.mnuItemDangXuat.Click += new System.EventHandler(this.mnuItemDangXuat_Click);
            // 
            // mnuItemHoSoNhanVien
            // 
            this.mnuItemHoSoNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemHoSoNhanVien.Image")));
            this.mnuItemHoSoNhanVien.Name = "mnuItemHoSoNhanVien";
            this.mnuItemHoSoNhanVien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuItemHoSoNhanVien.Size = new System.Drawing.Size(207, 22);
            this.mnuItemHoSoNhanVien.Text = "Hồ Sơ Nhân Viên";
            this.mnuItemHoSoNhanVien.Click += new System.EventHandler(this.mnuItemHoSoNhanVien_Click);
            // 
            // mnuItemThoat
            // 
            this.mnuItemThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemThoat.Image")));
            this.mnuItemThoat.Name = "mnuItemThoat";
            this.mnuItemThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuItemThoat.Size = new System.Drawing.Size(207, 22);
            this.mnuItemThoat.Text = "Thoát";
            this.mnuItemThoat.Click += new System.EventHandler(this.mnuItemThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSanPham,
            this.mnuItemNhanVien,
            this.mnuItemKhachHang});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.mnuDanhMuc.Text = "Danh Mục";
            // 
            // mnuItemSanPham
            // 
            this.mnuItemSanPham.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSanPham.Image")));
            this.mnuItemSanPham.Name = "mnuItemSanPham";
            this.mnuItemSanPham.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.mnuItemSanPham.Size = new System.Drawing.Size(180, 22);
            this.mnuItemSanPham.Text = "Sản Phẩm";
            this.mnuItemSanPham.Click += new System.EventHandler(this.mnuItemSanPham_Click);
            // 
            // mnuItemNhanVien
            // 
            this.mnuItemNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemNhanVien.Image")));
            this.mnuItemNhanVien.Name = "mnuItemNhanVien";
            this.mnuItemNhanVien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.mnuItemNhanVien.Size = new System.Drawing.Size(180, 22);
            this.mnuItemNhanVien.Text = "Nhân Viên";
            this.mnuItemNhanVien.Click += new System.EventHandler(this.mnuItemNhanVien_Click);
            // 
            // mnuItemKhachHang
            // 
            this.mnuItemKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemKhachHang.Image")));
            this.mnuItemKhachHang.Name = "mnuItemKhachHang";
            this.mnuItemKhachHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuItemKhachHang.Size = new System.Drawing.Size(180, 22);
            this.mnuItemKhachHang.Text = "Khách Hàng";
            this.mnuItemKhachHang.Click += new System.EventHandler(this.mnuItemKhachHang_Click);
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemTKSP});
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(69, 20);
            this.mnuThongKe.Text = "Thống Kê";
            // 
            // mnuItemTKSP
            // 
            this.mnuItemTKSP.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemTKSP.Image")));
            this.mnuItemTKSP.Name = "mnuItemTKSP";
            this.mnuItemTKSP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mnuItemTKSP.Size = new System.Drawing.Size(217, 22);
            this.mnuItemTKSP.Text = "Thống Kê Sản Phẩm";
            this.mnuItemTKSP.Click += new System.EventHandler(this.mnuItemTKSP_Click);
            // 
            // mnuHuongDan
            // 
            this.mnuHuongDan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemHuongDanSuDung,
            this.mnuItemGioiThieuPhanMem});
            this.mnuHuongDan.Name = "mnuHuongDan";
            this.mnuHuongDan.Size = new System.Drawing.Size(80, 20);
            this.mnuHuongDan.Text = "Hướng Dẫn";
            // 
            // mnuItemHuongDanSuDung
            // 
            this.mnuItemHuongDanSuDung.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemHuongDanSuDung.Image")));
            this.mnuItemHuongDanSuDung.Name = "mnuItemHuongDanSuDung";
            this.mnuItemHuongDanSuDung.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuItemHuongDanSuDung.Size = new System.Drawing.Size(226, 22);
            this.mnuItemHuongDanSuDung.Text = "Hướng Dẫn Sử Dụng";
            // 
            // mnuItemGioiThieuPhanMem
            // 
            this.mnuItemGioiThieuPhanMem.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemGioiThieuPhanMem.Image")));
            this.mnuItemGioiThieuPhanMem.Name = "mnuItemGioiThieuPhanMem";
            this.mnuItemGioiThieuPhanMem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.mnuItemGioiThieuPhanMem.Size = new System.Drawing.Size(226, 22);
            this.mnuItemGioiThieuPhanMem.Text = "Giới Thiệu Phần Mềm";
            // 
            // ThongTinNVmnuScriptItem
            // 
            this.ThongTinNVmnuScriptItem.Margin = new System.Windows.Forms.Padding(350, 0, 0, 0);
            this.ThongTinNVmnuScriptItem.Name = "ThongTinNVmnuScriptItem";
            this.ThongTinNVmnuScriptItem.Size = new System.Drawing.Size(28, 20);
            this.ThongTinNVmnuScriptItem.Text = "   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(157, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "DỰ ÁN MẪU C# - QUẢN LÝ BÁN HÀNG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(354, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 336);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(876, 487);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnuOpen);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmMain";
            this.Text = "QLBH-FPOLY";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnuOpen.ResumeLayout(false);
            this.mnuOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHoSoNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuItemThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnuItemNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuItemKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuItemTKSP;
        private System.Windows.Forms.ToolStripMenuItem mnuHuongDan;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHuongDanSuDung;
        private System.Windows.Forms.ToolStripMenuItem mnuItemGioiThieuPhanMem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ThongTinNVmnuScriptItem;
    }
}

