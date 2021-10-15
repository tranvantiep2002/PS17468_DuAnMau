using BUS_QLBanHang;
using DAL_QLBanHang;
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
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }
        BUS_ThongKe busthongke = new BUS_ThongKe();
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            LoadDataNhapKho();
            loadatatonkho();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void loadatatonkho()
        {
            dataGridView2.DataSource = busthongke.thongketonkho();
            dataGridView2.Columns[0].HeaderText = "Tên sản phẩm";
            dataGridView2.Columns[1].HeaderText = "Số lượng tồn";
        }

        void LoadDataNhapKho()
        {
            dataGridView1.DataSource = busthongke.thongkeSPNK();
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Số lượng nhập";
        }
    }
}
