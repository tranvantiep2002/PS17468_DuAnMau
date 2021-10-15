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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public string vaitro { get; set; } // Đăng nhập thành công, kiểm tra vai trò
        public string matkhau { get; set; }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.EmailNV = txtEmail.Text;
            nv.MatKhau = encryption(txtMatKhau.Text);
            if (busNhanVien.TinhTrangNhanVien(txtEmail.Text) == true)
            {
                MessageBox.Show("Tài Khoản của bạn đã ngưng hoạt động");
            }
            else
            {
                if (busNhanVien.NhanVienDangNhap(nv)) // khi đăng nhập thành công
                {
                    FrmMain.mail = nv.EmailNV;// truyền email đăng nhập cho form main
                    DataTable dt = busNhanVien.VaiTroNhanVien(nv.EmailNV);
                    vaitro = dt.Rows[0][0].ToString();// lấy vai trò nhân viên để phân quyền
                    FrmMain.session = 1;// cập nhật trạng thái đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công, kiểm tra lại email hoặc mật khẩu");
                    txtEmail.Text = null;
                    txtMatKhau.Text = null;
                    txtEmail.Focus();
                }
            }
        }
        // mã hóa password
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for(int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        // Quên mật khẩu
        private void btQuenMatKhau_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = encryption(builder.ToString());
                    busNhanVien.TaoMatKhau(txtEmail.Text, matkhaumoi);
                    SendMail(txtEmail.Text, builder.ToString());
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập email nhận thông tin khôi phục mật khẩu!");
                txtEmail.Focus();
            }
        }
        // Tạo số ngẫu nhiên trong mật khẩu
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        // tạo chuỗi ngẫu nhiên trong mật khẩu 
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for(int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        // Gửi mật khẩu đến mail người dùng
        private void SendMail(string email, string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("tieptvps17468@fpt.edu.vn", "@iuenhiulam");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("tieptvps17468@fpt.edu.vn");
                Msg.To.Add(email);
                Msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu";
                Msg.Body = "Chào anh/chị. Mật khẩu mới là: " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(Msg);
                MessageBox.Show("Một email khôi phục đã gửi tới bạn!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                txtMatKhau.PasswordChar = '*';
            }
        }
    }
}
