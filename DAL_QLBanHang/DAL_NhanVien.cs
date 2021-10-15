using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DBConnect
    {
        // login
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DANGNHAP";
                cmd.Parameters.AddWithValue("EMAIL", nv.EmailNV);
                cmd.Parameters.AddWithValue("MATKHAU", nv.MatKhau);
                if(Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Quên mật khẩu
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "QUENMATKHAU";
                cmd.Parameters.AddWithValue("EMAIL", email);
                if(Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // tạo mới mật khẩu
        //cập nhật thông tin nhân viên, cập nhật mật khẩu
        public bool TaoMatKhau(string email, string matKhauMoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TAOMOIMATKHAU";
                cmd.Parameters.AddWithValue("EMAIL", email);
                cmd.Parameters.AddWithValue("MATKHAU", matKhauMoi);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch(Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // lấy vai trò khi nhân viên login thành công
        public DataTable VaiTroNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTroNhanVien";
                cmd.Parameters.AddWithValue("EMAIL", email);
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Đổi mật khẩu
        public bool DoiMK(string email, string matkhaucu, string matkhaumoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DOIMK";
                cmd.Parameters.AddWithValue("EMAIL", email);
                cmd.Parameters.AddWithValue("ODDPASS", matkhaucu);
                cmd.Parameters.AddWithValue("NEWPASS", matkhaumoi);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        //Danh sách nhân viên
        public DataTable getNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHNV";
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }
        // thêm nhân viên
        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTDATAINTONHANVIEN";
                cmd.Parameters.AddWithValue("EMAIL", nv.EmailNV);
                cmd.Parameters.AddWithValue("TENNV", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("DIACHI", nv.DiaChi);
                cmd.Parameters.AddWithValue("VAITRO", nv.VaiTro);
                cmd.Parameters.AddWithValue("TINHTRANG", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Sửa nhân viên
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATEDATAINTONHANVIEN";
                cmd.Parameters.AddWithValue("EMAIL", nv.EmailNV);
                cmd.Parameters.AddWithValue("TENNV", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("DIACHI", nv.DiaChi);
                cmd.Parameters.AddWithValue("VAITRO", nv.VaiTro);
                cmd.Parameters.AddWithValue("TINHTRANG", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // kiểm tra tình trạng nhân viên
        public bool TinhTrangNhanVien(string email)
        {
            try
            {
                // làm icon đẹp dữ mày :))
                // khoai thế :)))
                // tạo lại database như cx đc không m
                // đc
                //tạo lại đi t nhờ mấy proc fb :))
                // để attach vô thử
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KIEMTRATINHTRANG";
                cmd.Parameters.AddWithValue("EMAIL", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
                    
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Xóa nhân viên
        public bool XoaNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETEDATAFROMNHANVIEN";
                cmd.Parameters.AddWithValue("EMAIL", email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Tìm kiếm nhân viên
        public DataTable SearchNhanVien(string tenNhanVien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHDATAFROMNHANVIEN";
                cmd.Parameters.AddWithValue("TENNV", tenNhanVien);
                cmd.Connection = _conn;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
