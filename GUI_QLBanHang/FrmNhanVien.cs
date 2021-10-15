using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FrmNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        // load nhân viên lên datagridview
        private void LoadGridview_NhanVien()
        {
            dataGridView1.DataSource = busNhanVien.getNhanVien();
            dataGridView1.Columns[0].HeaderText = "Email";
            dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[3].HeaderText = "Vai Trò";
            dataGridView1.Columns[4].HeaderText = "Tình Trạng";
        }
        // load form nhân viên
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridview_NhanVien();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // reset giá trị form
        private void ResetValue()
        {
            txtMaNV.Text = "Nhập tên nhân viên";
            txtMaNV.ForeColor = Color.Silver;
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Enabled = false;
            txtTenNV.Enabled = false;
            txtDiaChi.Enabled = false;
            rdbtNhanVien.Enabled = false;
            rdbtQuanTri.Enabled = false;
            rdbtHoatDong.Enabled = false;
            rdbtNgungHoatDong.Enabled = false;
            btThem.Enabled = true;
            btLuu.Enabled = false;
            btDong.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
        }
        // bt thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtTenNV.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            rdbtNhanVien.Enabled = true;
            rdbtQuanTri.Enabled = true;
            rdbtNgungHoatDong.Enabled = true;
            rdbtHoatDong.Enabled = true;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            rdbtNhanVien.Checked = false;
            rdbtNgungHoatDong.Enabled = false;
            rdbtQuanTri.Checked = false;
            rdbtHoatDong.Checked = false;
            txtEmail.Focus();
        }
        //bt lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            int role = 0; // vai trò nhân viên
            if (rdbtQuanTri.Checked)
            {
                role = 1;
            }
            int tinhtrang = 0; // tình trạng ngừng hoạt động
            if (rdbtHoatDong.Checked)
            {
                tinhtrang = 1;
            }
            if(txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!IsValid(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập email đúng định dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            if(txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            else if(txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if(rdbtQuanTri.Checked == false && rdbtNhanVien.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn chức vụ cho nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(rdbtHoatDong.Checked == false && rdbtNgungHoatDong.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn tình trạng hoạt động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang);
                if (busNhanVien.InsertNhanVien(nv))
                {
                    MessageBox.Show("Insert thành công");
                    ResetValue();
                    LoadGridview_NhanVien();
                    SendMail(nv.EmailNV);
                }
                else
                {
                    MessageBox.Show("Insert thất bại( Email nhân viên đã tồn tại )");
                }
            }
        }
        // gửi mail
        private void SendMail(string emailNV)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("tieptvps17468@fpt.edu.vn", "@iuenhiulam");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("tieptvps17468@fpt.edu.vn");
                Msg.To.Add(emailNV);
                Msg.Subject = "Chào mừng anh/chị";
                Msg.Body = "Mật khẩu truy cập là: 1234 .Sau khi đăng nhập vui lòng đổi mật khẩu";
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(Msg);
                MessageBox.Show("Một email gửi tới nhân viên!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // kiểm tra email có đúng định dạng không
        private bool IsValid(string mailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(mailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        // bt xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            if (FrmMain.mail == txtEmail.Text)
            {
                MessageBox.Show("Bạn không thể xóa Account mà bạn đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanVien.XoaNhanVien(txtEmail.Text))
                    {
                        MessageBox.Show("Nhân viên đã được xóa trên datagribview, dữ liệu nhân viên vẫn lưu trên CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValue();
                        LoadGridview_NhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
                else
                {
                    ResetValue();
                }
            }

        }
        // bt sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else
            {
                int role = 0; // vai trò nhân viên
                if (rdbtQuanTri.Checked)
                {
                    role = 1;
                }
                int tinhtrang = 0; // ngừng hoạt động
                if (rdbtHoatDong.Checked)
                {
                    tinhtrang = 1;
                }
                else
                {
                    MessageBox.Show("Nhân viên đã ngưng hoạt động thì sẽ mất trong datagridview và dữ liệu vẫn còn trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang);
                if (MessageBox.Show("Bạn chắc chắn muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanVien.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValue();
                        LoadGridview_NhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    ResetValue();
                }
            }
        }
        // Đóng Form nhân viên
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //bt bỏ qua
        private void btBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridview_NhanVien();
        }
        // bt danh sách
        private void btDanhSach_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridview_NhanVien();
        }
        // bt tìm kiếm
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtMaNV.Text;
            DataTable ds = busNhanVien.SearchNhanVien(tenNhanVien);
            if(ds.Rows.Count > 0)
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
            txtMaNV.Text = "Nhập tên nhân viên";
            txtMaNV.ForeColor = Color.Silver;
            ResetValue();
        }

        private void txtMaNV_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = null;
            txtMaNV.ForeColor = Color.Black;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                btLuu.Enabled = false;
                txtTenNV.Enabled = true;
                txtDiaChi.Enabled = true;
                rdbtQuanTri.Enabled = true;
                rdbtNhanVien.Enabled = true;
                rdbtHoatDong.Enabled = true;
                rdbtNgungHoatDong.Enabled = true;
                btSua.Enabled = true;
                btXoa.Enabled = true;
                // đổ dữ liệu vào các ô tương ứng
                txtEmail.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 1)
                {
                    rdbtQuanTri.Checked = true;
                }
                else
                {
                    rdbtNhanVien.Checked = true;
                }
                if (int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 1)
                {
                    rdbtHoatDong.Checked = true;
                }
                else
                {
                    rdbtNgungHoatDong.Checked = true;
                }
                if (FrmMain.mail == txtEmail.Text)
                {
                    rdbtNgungHoatDong.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
