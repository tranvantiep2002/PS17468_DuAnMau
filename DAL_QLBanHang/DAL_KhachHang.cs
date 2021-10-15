using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
namespace DAL_QLBanHang
{
    public class DAL_KhachHang : DBConnect
    {
        // danh sách khách hàng
        public DataTable getKhach()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHKH";
                cmd.Connection = _conn;
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                _conn.Close();
            }
        }
        // thêm khách hàng
        public bool InsertKhachHang(DTO_KhachHang khach)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTDATAINTOKHACHHANG";
                cmd.Parameters.AddWithValue("DIENTHOAI", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("TENKHACH", khach.TenKhach);
                cmd.Parameters.AddWithValue("DIACHI", khach.DiaChi);
                cmd.Parameters.AddWithValue("PHAI", khach.Phai);
                cmd.Parameters.AddWithValue("EMAIL", khach.email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Update khách hàng
        public bool UpdateKhachHang(DTO_KhachHang khach)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATEDATAINTOKHACHHANG";
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("DIENTHOAI", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("TENKHACH", khach.TenKhach);
                cmd.Parameters.AddWithValue("DIACHI", khach.DiaChi);
                cmd.Parameters.AddWithValue("PHAI", khach.Phai);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // xóa khách hàng
        public bool DeleteKhachHang(string sodienthoai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETEDATAFROMKHACHHANG";
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("DIENTHOAI", sodienthoai);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // tìm kiếm khách hàng
        public DataTable SearchKhachHang(string sodienthoai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHKHACHHANG";
                cmd.Parameters.AddWithValue("DIENTHOAI", sodienthoai);
                cmd.Connection = _conn;
                DataTable KH = new DataTable();
                KH.Load(cmd.ExecuteReader());
                    return KH;
            }
            finally
            {
                _conn.Close();
            }


        }
    }
}
