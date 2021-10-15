using BUS_QLBanHang;
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
    public partial class FrmDoiMatKhau : Form
    {
        string StrEmail;
        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        public FrmDoiMatKhau(string email)
        {
            InitializeComponent();
            StrEmail = email;
            txtEmail.Text = StrEmail;
            txtEmail.Enabled = false;
        }
        // mã hóa password
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            else if(txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else if(txtNhapLaiMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhapLaiMatKhau.Focus();
                return;
            }
            else if(txtMatKhauMoi.Text.Trim() != txtNhapLaiMatKhau.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới và nhập lại mật khẩu giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn chắc chắn muốn cập nhập mật khẩu","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
                {
                    string matkhaumoi = encryption(txtMatKhauMoi.Text);
                    string matkhaucu = encryption(txtMatKhauCu.Text);
                    if (busnhanvien.DoiMK(txtEmail.Text, matkhaucu, matkhaumoi))
                    {
                        FrmMain.profile = 1;
                        FrmMain.session = 0;
                        SendMail(StrEmail, txtNhapLaiMatKhau.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn phải đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
                        MessageBox.Show("" + matkhaucu);
                        txtMatKhauCu.Text = "";
                        txtMatKhauMoi.Text = "";
                        txtNhapLaiMatKhau.Text = "";
                    }
                }
                else
                {
                    txtMatKhauCu.Text = "";
                    txtMatKhauMoi.Text = "";
                    txtNhapLaiMatKhau.Text = "";
                }
            }
        }
        // gửi mật khẩu mới đến mail người dùng
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
