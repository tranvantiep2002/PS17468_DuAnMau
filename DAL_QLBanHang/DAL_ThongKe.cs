using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_ThongKe : DBConnect
    {
        public DataTable ThongKeSP()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "THONGKESP";
                cmd.Connection = _conn;
                DataTable tk = new DataTable();
                tk.Load(cmd.ExecuteReader());
                return tk;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable ThongKeTonKho()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "THONGKETONKHO";
                DataTable dt = new DataTable();
                cmd.Connection = _conn;
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
