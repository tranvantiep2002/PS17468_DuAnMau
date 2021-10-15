using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FrmSanPham : Form
    {
        BUS_SanPham busSanPham = new BUS_SanPham();
        string stremail = FrmMain.mail;
        string checkUrlImage;
        string fileName;
        string fileSavePath;
        string fileAddress;
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            resetValue();
            LoadGridview();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void resetValue()
        {
            txtTenSanPham.Text = "Nhập tên sản phẩm";
            txtTenSanPham.ForeColor = Color.Silver;
            txtTenHang.Text = null;
            txtMaHang.Text = null;
            txtDonGiaBan.Text = null;
            txtDonGiaNhap.Text = null;
            txtSoLuong.Text = null;
            txtGhiChu.Text = null;
            txtHinhAnh.Text = null;
            txtTenHang.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMaHang.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtGhiChu.Enabled = false;
            txtHinhAnh.Enabled = false;
            btThem.Enabled = true;
            btLuu.Enabled = false;
            btDong.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btMoHinh.Enabled = false;
            pictureBoxHinh.Image = null;
        }

        private void LoadGridview()
        {
            dataGridView1.DataSource = busSanPham.getSanPham();
            dataGridView1.Columns[0].HeaderText = "Mã Sản Phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Số Lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn Giá Bán";
            dataGridView1.Columns[4].HeaderText = "Đơn Giá Nhập";
            dataGridView1.Columns[5].HeaderText = "Hình Ảnh";
            dataGridView1.Columns[6].HeaderText = "Ghi Chú";
        }
        //bt thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            txtTenHang.Enabled = true;
            txtSoLuong.Enabled = true;
            txtMaHang.Enabled = false;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtGhiChu.Enabled = true;
            btThem.Enabled = true;
            btLuu.Enabled = true;
            btMoHinh.Enabled = true;
            txtTenHang.Text = null;
            txtMaHang.Text = null;
            txtDonGiaBan.Text = null;
            txtDonGiaNhap.Text = null;
            txtSoLuong.Text = null;
            txtGhiChu.Text = null;
            txtHinhAnh.Text = null;
            pictureBoxHinh.Image = null;
            btXoa.Enabled = false;
            btSua.Enabled = false;
            txtMaHang.Focus();
        }
        //bt lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(),out intSoLuong);
            float dongianban;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim(), out dongianban);
            float dongianhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim(), out dongianhap);
            if(txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm");
                return;
            }
            else if(!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng bằng số và lớn hơn 0");
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá bán bằng số và lớn hơn 0");
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá nhập bằng số và lớn hơn 0");
                return;
            }
            else if(txtHinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh minh họa cho sản phẩm");
                return;
            }
            else
            {
                DTO_SanPham sp = new DTO_SanPham(txtTenHang.Text, int.Parse(txtSoLuong.Text), float.Parse(txtDonGiaBan.Text), float.Parse(txtDonGiaNhap.Text), txtGhiChu.Text, stremail, "\\Images\\" + fileName);
                if (busSanPham.InsertSanPham(sp))
                {
                    MessageBox.Show("Thêm thành công");
                    File.Copy(fileAddress, fileSavePath, true);
                    resetValue();
                    LoadGridview();
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                    resetValue();
                }
            }
        }
        //bt mở hình
        private void btMoHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh họa cho sản phẩm";
            if(dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pictureBoxHinh.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //fileSavePath = "C:\\Program Files (x86)\\Fpoly\\QuanLyBanHang\\Images\\" + fileName;
                //txtHinhAnh.Text = "C:\\Program Files (x86)\\Fpoly\\QuanLyBanHang\\Images\\" + fileName;
                fileSavePath = saveDirectory + "\\Images\\" + fileName;
                txtHinhAnh.Text = "\\Images\\" + fileName;
            }
        }
        //bt sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim().ToString(), out intSoLuong);
            float dongianban;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim(), out dongianban);
            float dongianhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim(), out dongianhap);
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm");
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng bằng số và lớn hơn 0");
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá bán bằng số và lớn hơn 0");
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá nhập bằng số và lớn hơn 0");
                return;
            }
            else if (txtHinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh minh họa cho sản phẩm");
                return;
            }
            else
            {
                DTO_SanPham sp = new DTO_SanPham(int.Parse(txtMaHang.Text),txtTenHang.Text, int.Parse(txtSoLuong.Text), float.Parse(txtDonGiaBan.Text), float.Parse(txtDonGiaNhap.Text), txtGhiChu.Text, "\\Images\\" + fileName);
                if(MessageBox.Show("Bạn chắc chắn muốn chỉnh sửa","Confilm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busSanPham.UpdateSanPham(sp))
                    {
                        if(txtHinhAnh.Text != checkUrlImage)
                        {
                            File.Copy(fileAddress, fileSavePath, true);
                        }
                        MessageBox.Show("Update thành công");
                        resetValue();
                        LoadGridview();
                    }
                    else
                    {
                        MessageBox.Show("Update thất bại");
                    }
                }
            }
        }
        // click vào datagridview
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            if(dataGridView1.Rows.Count > 1)
            {
                btMoHinh.Enabled = true;
                btLuu.Enabled = false;
                txtTenHang.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonGiaBan.Enabled = true;
                txtDonGiaNhap.Enabled = true;
                txtGhiChu.Enabled = true;
                txtTenHang.Focus();
                btSua.Enabled = true;
                btXoa.Enabled = true;
                txtMaHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaBan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDonGiaNhap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtHinhAnh.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtGhiChu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                checkUrlImage = txtHinhAnh.Text;
                pictureBoxHinh.Image = Image.FromFile(saveDirectory+dataGridView1.CurrentRow.Cells[5].Value.ToString());
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //bt xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busSanPham.deleteSanPham(txtMaHang.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    resetValue();
                    LoadGridview();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                resetValue();
            }
        }
        //bt bỏ qua
        private void btBoQua_Click(object sender, EventArgs e)
        {
            resetValue();
            LoadGridview();
        }
        //bt danh sách
        private void btDanhSach_Click(object sender, EventArgs e)
        {
            resetValue();
            LoadGridview();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // tìm kiếm sản phẩm
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtTenSanPham.Text;
            DataTable ds = busSanPham.SearchSanPham(tenNhanVien);
            if (ds.Rows.Count > 0)
            {
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].HeaderText = "Email";
                dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
                dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
                dataGridView1.Columns[3].HeaderText = "Vai Trò";
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            txtTenSanPham.Text = "Nhập tên nhân viên";
            txtTenSanPham.ForeColor = Color.Silver;
            resetValue();
        }

        private void txtTenSanPham_Click(object sender, EventArgs e)
        {
            txtTenSanPham.Text = null;
            txtTenSanPham.ForeColor = Color.Black;
        }
    }
}
