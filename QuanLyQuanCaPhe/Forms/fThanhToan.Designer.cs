namespace QuanLyQuanCaPhe
{
    partial class fThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.lblTienGiam = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.cboLoaiGiamGia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongTienGoc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.btnInTam = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.gbChiTiet, 0, 1);
            this.tlpMain.Controls.Add(this.pnlInfo, 1, 1);
            this.tlpMain.Controls.Add(this.lblTitle, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(813, 496);
            this.tlpMain.TabIndex = 0;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.dgvChiTiet);
            this.gbChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbChiTiet.Location = new System.Drawing.Point(8, 57);
            this.gbChiTiet.Margin = new System.Windows.Forms.Padding(8);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Padding = new System.Windows.Forms.Padding(2);
            this.gbChiTiet.Size = new System.Drawing.Size(471, 431);
            this.gbChiTiet.TabIndex = 0;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết hóa đơn";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenSP,
            this.colDonGia,
            this.colSoLuong,
            this.colThanhTien});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(2, 18);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(467, 411);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colTenSP
            // 
            this.colTenSP.FillWeight = 150F;
            this.colTenSP.HeaderText = "Tên món";
            this.colTenSP.MinimumWidth = 6;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInfo.Controls.Add(this.gbThongTin);
            this.pnlInfo.Controls.Add(this.btnInTam);
            this.pnlInfo.Controls.Add(this.btnHuy);
            this.pnlInfo.Controls.Add(this.btnXacNhan);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(489, 51);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(8);
            this.pnlInfo.Size = new System.Drawing.Size(322, 443);
            this.pnlInfo.TabIndex = 1;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThongTin.BackColor = System.Drawing.Color.White;
            this.gbThongTin.Controls.Add(this.lblFinalTotal);
            this.gbThongTin.Controls.Add(this.label8);
            this.gbThongTin.Controls.Add(this.panelLine);
            this.gbThongTin.Controls.Add(this.lblTienGiam);
            this.gbThongTin.Controls.Add(this.label7);
            this.gbThongTin.Controls.Add(this.txtGiamGia);
            this.gbThongTin.Controls.Add(this.cboLoaiGiamGia);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.lblTongTienGoc);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.lblTenBan);
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.gbThongTin.Location = new System.Drawing.Point(8, 8);
            this.gbThongTin.Margin = new System.Windows.Forms.Padding(2);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(2);
            this.gbThongTin.Size = new System.Drawing.Size(307, 244);
            this.gbThongTin.TabIndex = 2;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin thanh toán";
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblFinalTotal.ForeColor = System.Drawing.Color.Red;
            this.lblFinalTotal.Location = new System.Drawing.Point(130, 195);
            this.lblFinalTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(171, 32);
            this.lblFinalTotal.TabIndex = 14;
            this.lblFinalTotal.Text = "0đ";
            this.lblFinalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(11, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "TỔNG TIỀN";
            // 
            // panelLine
            // 
            this.panelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLine.BackColor = System.Drawing.Color.Black;
            this.panelLine.Location = new System.Drawing.Point(11, 179);
            this.panelLine.Margin = new System.Windows.Forms.Padding(2);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(286, 2);
            this.panelLine.TabIndex = 12;
            // 
            // lblTienGiam
            // 
            this.lblTienGiam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic);
            this.lblTienGiam.ForeColor = System.Drawing.Color.Green;
            this.lblTienGiam.Location = new System.Drawing.Point(136, 150);
            this.lblTienGiam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTienGiam.Name = "lblTienGiam";
            this.lblTienGiam.Size = new System.Drawing.Size(165, 20);
            this.lblTienGiam.TabIndex = 11;
            this.lblTienGiam.Text = "-0đ";
            this.lblTienGiam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Đã giảm:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiamGia.Location = new System.Drawing.Point(196, 114);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(106, 24);
            this.txtGiamGia.TabIndex = 9;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.TxtGiamGia_TextChanged);
            this.txtGiamGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGiamGia_KeyPress);
            // 
            // cboLoaiGiamGia
            // 
            this.cboLoaiGiamGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGiamGia.FormattingEnabled = true;
            this.cboLoaiGiamGia.Items.AddRange(new object[] {
            "Không giảm",
            "Theo %",
            "Theo tiền"});
            this.cboLoaiGiamGia.Location = new System.Drawing.Point(90, 114);
            this.cboLoaiGiamGia.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoaiGiamGia.Name = "cboLoaiGiamGia";
            this.cboLoaiGiamGia.Size = new System.Drawing.Size(98, 26);
            this.cboLoaiGiamGia.TabIndex = 8;
            this.cboLoaiGiamGia.SelectedIndexChanged += new System.EventHandler(this.CboLoaiGiamGia_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(11, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giảm giá:";
            // 
            // lblTongTienGoc
            // 
            this.lblTongTienGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTienGoc.Location = new System.Drawing.Point(113, 81);
            this.lblTongTienGoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTienGoc.Name = "lblTongTienGoc";
            this.lblTongTienGoc.Size = new System.Drawing.Size(188, 20);
            this.lblTongTienGoc.TabIndex = 4;
            this.lblTongTienGoc.Text = "0đ";
            this.lblTongTienGoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền (gốc):";
            // 
            // lblTenBan
            // 
            this.lblTenBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenBan.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenBan.Location = new System.Drawing.Point(2, 19);
            this.lblTenBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(303, 43);
            this.lblTenBan.TabIndex = 0;
            this.lblTenBan.Text = "BÀN 01";
            this.lblTenBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInTam
            // 
            this.btnInTam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInTam.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInTam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnInTam.ForeColor = System.Drawing.Color.White;
            this.btnInTam.Location = new System.Drawing.Point(8, 321);
            this.btnInTam.Margin = new System.Windows.Forms.Padding(2);
            this.btnInTam.Name = "btnInTam";
            this.btnInTam.Size = new System.Drawing.Size(306, 41);
            this.btnInTam.TabIndex = 3;
            this.btnInTam.Text = "IN HÓA ĐƠN TẠM";
            this.btnInTam.UseVisualStyleBackColor = false;
            this.btnInTam.Click += new System.EventHandler(this.BtnInTam_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(8, 378);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 49);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Quay lại";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(105, 378);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(209, 49);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.BtnXacNhan_Click);
            // 
            // lblTitle
            // 
            this.tlpMain.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(2, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(809, 49);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "XÁC NHẬN THANH TOÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 496);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(754, 495);
            this.Name = "fThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.tlpMain.ResumeLayout(false);
            this.gbChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnInTam; // Thêm nút in tạm
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTongTienGoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Label lblTienGiam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.ComboBox cboLoaiGiamGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFinalTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}