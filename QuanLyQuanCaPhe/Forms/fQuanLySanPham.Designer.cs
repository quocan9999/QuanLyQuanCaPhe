namespace QuanLyQuanCaPhe.Forms
{
    partial class fQuanLySanPham
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grvMon = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.txtTimKiemMon = new System.Windows.Forms.TextBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvMon)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1304, 32);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Món ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnXem);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 512);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1304, 90);
            this.panel2.TabIndex = 1;
            // 
            // btnXem
            // 
            this.btnXem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXem.BackColor = System.Drawing.Color.Lime;
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(730, 28);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 50);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoa.BackColor = System.Drawing.Color.Lime;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(466, 28);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 50);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSua.BackColor = System.Drawing.Color.Lime;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(596, 28);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 50);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThem.BackColor = System.Drawing.Color.Lime;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(336, 28);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 50);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.grvMon);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(908, 498);
            this.panel3.TabIndex = 2;
            // 
            // grvMon
            // 
            this.grvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvMon.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvMon.Location = new System.Drawing.Point(0, 0);
            this.grvMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grvMon.Name = "grvMon";
            this.grvMon.RowHeadersWidth = 51;
            this.grvMon.Size = new System.Drawing.Size(908, 498);
            this.grvMon.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.txtTrangThai);
            this.panel4.Controls.Add(this.txtDVT);
            this.panel4.Controls.Add(this.btnTimKiem);
            this.panel4.Controls.Add(this.txtGia);
            this.panel4.Controls.Add(this.txtTenSanPham);
            this.panel4.Controls.Add(this.txtTimKiemMon);
            this.panel4.Controls.Add(this.cboDanhMuc);
            this.panel4.Controls.Add(this.txtID);
            this.panel4.Location = new System.Drawing.Point(905, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(399, 498);
            this.panel4.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel10.Controls.Add(this.label2);
            this.panel10.Location = new System.Drawing.Point(23, 94);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(114, 22);
            this.panel10.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel9.Controls.Add(this.label4);
            this.panel9.Location = new System.Drawing.Point(23, 142);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(114, 22);
            this.panel9.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tên Món";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(23, 189);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(114, 22);
            this.panel8.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Giá";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(23, 242);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(114, 22);
            this.panel7.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Đơn vị tính ";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(23, 291);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(114, 22);
            this.panel6.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Danh Mục";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(23, 352);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(114, 22);
            this.panel5.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(173, 352);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(172, 22);
            this.txtTrangThai.TabIndex = 20;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(173, 242);
            this.txtDVT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(172, 22);
            this.txtDVT.TabIndex = 18;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Yellow;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(262, 15);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(102, 50);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(173, 189);
            this.txtGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(172, 22);
            this.txtGia.TabIndex = 15;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(173, 142);
            this.txtTenSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(172, 22);
            this.txtTenSanPham.TabIndex = 14;
            // 
            // txtTimKiemMon
            // 
            this.txtTimKiemMon.Location = new System.Drawing.Point(23, 37);
            this.txtTimKiemMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiemMon.Name = "txtTimKiemMon";
            this.txtTimKiemMon.Size = new System.Drawing.Size(220, 22);
            this.txtTimKiemMon.TabIndex = 13;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(173, 294);
            this.cboDanhMuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(172, 24);
            this.cboDanhMuc.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(173, 94);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(172, 22);
            this.txtID.TabIndex = 6;
            // 
            // fQuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 602);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1200, 649);
            this.Name = "fQuanLySanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.fQuanLySanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvMon)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView grvMon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtTimKiemMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
    }
}