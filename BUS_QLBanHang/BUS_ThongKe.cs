using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_ThongKe
    {
        DAL_ThongKe thongke = new DAL_ThongKe();
        public DataTable thongkeSPNK()
        {
            return thongke.ThongKeSP();
        }
        public DataTable thongketonkho()
        {
            return thongke.ThongKeTonKho();
        }
    }
}
