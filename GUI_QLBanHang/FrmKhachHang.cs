using BUS_QLBanHang;
using DTO_QLBanHang;
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
    public partial class FrmKhachHang : Form
    {
        BUS_KhachHang busKhach = new BUS_KhachHang();
        string stremail = FrmMain.mail;
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            restValue();
            LoadGridView_Khach();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // load danh sách khách hàng
        private void LoadGridView_Khach()
        {
            dataGridView1.DataSource = busKhach.getKhachHang();
            dataGridView1.Columns[0].HeaderText = "Điện Thoại";
            dataGridView1.Columns[1].HeaderText = "Họ và tên";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Giới tính";
        }
        // reset form
        void restValue()
        {
            txtNhapSDT.Text = "Nhập số điện thoại";
            txtNhapSDT.ForeColor = Color.Silver;
            txtSoDienThoai.Text = null;
            txtHoVaTen.Text = null;
            txtDiaChi.Text = null;
            txtSoDienThoai.Enabled = false;
            txtHoVaTen.Enabled = false;
            txtDiaChi.Enabled = false;
            rdbtNam.Enabled = false;
            rdbtNu.Enabled = false;
            btThem.Enabled = true;
            btLuu.Enabled = false;
            btDong.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
        }
        //bt thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.Text = null;
            txtHoVaTen.Text = null;
            txtDiaChi.Text = null;
            txtSoDienThoai.Enabled = true;
            txtHoVaTen.Enabled = true;
            txtDiaChi.Enabled = true;
            rdbtNam.Enabled = true;
            rdbtNu.Enabled = true;
            btThem.Enabled = true;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            rdbtNam.Checked = false;
            rdbtNu.Checked = false;
        }
        //bt lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txtSoDienThoai.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if (rdbtNu.Checked)
            {
                phai = "Nu";
            }
            if(!isInt || float.Parse(txtSoDienThoai.Text) < 0 || txtSoDienThoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("bạn phải nhập số điênh thoại > 0, số nguyên và có độ dài là 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            if(txtHoVaTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                txtHoVaTen.Focus();
                return;
            }
            else if(txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
                txtDiaChi.Focus();
                return;
            }
            else if (!rdbtNam.Checked && !rdbtNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtSoDienThoai.Text, txtHoVaTen.Text, txtDiaChi.Text, phai, stremail);
                if (busKhach.InsertKhachHang(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    restValue();
                    LoadGridView_Khach();
                }
                else
                {
                    MessageBox.Show("Số điện thoại đã tồn tại\nVui lòng kiểm tra lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        // đỗ dữ khi click vào datagridview
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 1)
            {
                btLuu.Enabled = false;
                txtDiaChi.Enabled = true;
                txtSoDienThoai.Enabled = true;
                txtHoVaTen.Enabled = true;
                rdbtNu.Enabled = true;
                rdbtNam.Enabled = true;
                txtSoDienThoai.Focus();
                btSua.Enabled = true;
                btXoa.Enabled = true;
                txtSoDienThoai.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoVaTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string phai = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if(phai == "Nam")
                {
                    rdbtNam.Checked = true;
                }
                else
                {
                    rdbtNu.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // bt sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txtSoDienThoai.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if(!isInt || float.Parse(txtSoDienThoai.Text) < 0 || txtSoDienThoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại > 0, số nguyên và có độ dài là 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtHoVaTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                txtHoVaTen.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
                txtDiaChi.Focus();
                return;
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtSoDienThoai.Text, txtHoVaTen.Text, txtDiaChi.Text, phai);
                if(MessageBox.Show("Bạn có chắc muốn chỉnh sửa","confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.UpdateKhachHang(kh))
                    {
                        MessageBox.Show("Update thành công");
                        restValue();
                        LoadGridView_Khach();
                    }
                    else
                    {
                        MessageBox.Show("Update thất bại");
                    }
                }
                else
                {
                    restValue();
                }

            }
        }
        // bt xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busKhach.DeleteKhachHang(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    restValue();
                    LoadGridView_Khach();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                restValue();
            }
        }
        //bt bỏ qua
        private void btBoQua_Click(object sender, EventArgs e)
        {
            restValue();
            LoadGridView_Khach();
        }
        //bt danh sách
        private void btDanhSach_Click(object sender, EventArgs e)
        {
            restValue();
            LoadGridView_Khach();
        }
        //bt dóng
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // bt tìm kiếm
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string sodienthoai = txtNhapSDT.Text;
            DataTable khachhang = busKhach.SearchKhachHang(sodienthoai);
            if(khachhang.Rows.Count > 0)
            {
                dataGridView1.DataSource = khachhang;
                dataGridView1.Columns[0].HeaderText = "Điện Thoại";
                dataGridView1.Columns[1].HeaderText = "Họ và tên";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].HeaderText = "Giới tính";
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtNhapSDT.Text = "Nhập số điện thoại";
            txtNhapSDT.ForeColor = Color.Silver;
            restValue();
        }
        //
        private void FrmKhachHang_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNhapSDT_Click(object sender, EventArgs e)
        {
            txtNhapSDT.Text = null;
            txtNhapSDT.ForeColor = Color.Black;
        }
    }
}
