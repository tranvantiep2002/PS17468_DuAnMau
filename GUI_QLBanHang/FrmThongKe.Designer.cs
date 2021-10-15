
namespace GUI_QLBanHang
{
    partial class FrmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableMain = new System.Windows.Forms.TabControl();
            this.tabSPNK = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabTK = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tableMain.SuspendLayout();
            this.tabSPNK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.Controls.Add(this.tabSPNK);
            this.tableMain.Controls.Add(this.tabTK);
            this.tableMain.Location = new System.Drawing.Point(13, 1);
            this.tableMain.Name = "tableMain";
            this.tableMain.SelectedIndex = 0;
            this.tableMain.Size = new System.Drawing.Size(775, 418);
            this.tableMain.TabIndex = 0;
            // 
            // tabSPNK
            // 
            this.tabSPNK.Controls.Add(this.dataGridView1);
            this.tabSPNK.Location = new System.Drawing.Point(4, 22);
            this.tabSPNK.Name = "tabSPNK";
            this.tabSPNK.Padding = new System.Windows.Forms.Padding(3);
            this.tabSPNK.Size = new System.Drawing.Size(767, 392);
            this.tabSPNK.TabIndex = 0;
            this.tabSPNK.Text = "Sản Phẩm Nhập Kho";
            this.tabSPNK.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(758, 317);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // tabTK
            // 
            this.tabTK.Controls.Add(this.dataGridView2);
            this.tabTK.Location = new System.Drawing.Point(4, 22);
            this.tabTK.Name = "tabTK";
            this.tabTK.Padding = new System.Windows.Forms.Padding(3);
            this.tabTK.Size = new System.Drawing.Size(767, 392);
            this.tabTK.TabIndex = 1;
            this.tabTK.Text = "Tồn Kho";
            this.tabTK.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(755, 309);
            this.dataGridView2.TabIndex = 0;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.tableMain);
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.tableMain.ResumeLayout(false);
            this.tabSPNK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabTK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tableMain;
        private System.Windows.Forms.TabPage tabSPNK;
        private System.Windows.Forms.TabPage tabTK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}