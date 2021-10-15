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
    public class DAL_SanPham : DBConnect
    {
        //danh sách sản phẩm
        public DataTable getSanPham()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHSANPHAM";
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
        //thêm sản phẩm
        public bool InsertSanPham(DTO_SanPham sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTDATAINTOSANPHAM";
                cmd.Parameters.AddWithValue("TENHANG", sp.tenhang);
                cmd.Parameters.AddWithValue("SOLUONG", sp.soluong);
                cmd.Parameters.AddWithValue("DONGIABAN", sp.dongiaban);
                cmd.Parameters.AddWithValue("DONGIANHAP", sp.dongianhap);
                cmd.Parameters.AddWithValue("HINHANH", sp.hinhanh);
                cmd.Parameters.AddWithValue("GHICHU", sp.giachu);
                cmd.Parameters.AddWithValue("EMAIL", sp.emailnv);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        //update sản phẩm
        public bool updateSanPham(DTO_SanPham sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATEDATASANPHAM";
                cmd.Parameters.AddWithValue("MAHANG", sp.mahang);
                cmd.Parameters.AddWithValue("TENHANG", sp.tenhang);
                cmd.Parameters.AddWithValue("SOLUONG", sp.soluong);
                cmd.Parameters.AddWithValue("DONGIABAN", sp.dongiaban);
                cmd.Parameters.AddWithValue("DONGIANHAP", sp.dongianhap);
                cmd.Parameters.AddWithValue("HINHANH", sp.hinhanh);
                cmd.Parameters.AddWithValue("GHICHU", sp.giachu);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        //delete sản phẩm
        public bool deleteSanPham(string maSanPham)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETEDATASANPHAM";
                cmd.Parameters.AddWithValue("MAHANG", maSanPham);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // search sản phẩm
        public DataTable SearchNhanVien(string tensanpham)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHSANPHAM";
                cmd.Parameters.AddWithValue("TENHANG", tensanpham);
                cmd.Connection = _conn;
                DataTable dtSanPham = new DataTable();
                dtSanPham.Load(cmd.ExecuteReader());
                return dtSanPham;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
