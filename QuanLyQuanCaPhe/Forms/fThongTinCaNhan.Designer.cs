namespace QuanLyQuanCaPhe.Forms
{
    partial class fThongTinCaNhan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tblThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblHoTenValue = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblGioiTinhValue = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblNgaySinhValue = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblSoDienThoaiValue = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDiaChiValue = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tblThongTin.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(520, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin cá nhân";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlContent.Controls.Add(this.tblThongTin);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(520, 320);
            this.pnlContent.TabIndex = 1;
            // 
            // tblThongTin
            // 
            this.tblThongTin.BackColor = System.Drawing.Color.White;
            this.tblThongTin.ColumnCount = 2;
            this.tblThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblThongTin.Controls.Add(this.lblHoTen, 0, 0);
            this.tblThongTin.Controls.Add(this.lblHoTenValue, 1, 0);
            this.tblThongTin.Controls.Add(this.lblGioiTinh, 0, 1);
            this.tblThongTin.Controls.Add(this.lblGioiTinhValue, 1, 1);
            this.tblThongTin.Controls.Add(this.lblNgaySinh, 0, 2);
            this.tblThongTin.Controls.Add(this.lblNgaySinhValue, 1, 2);
            this.tblThongTin.Controls.Add(this.lblSoDienThoai, 0, 3);
            this.tblThongTin.Controls.Add(this.lblSoDienThoaiValue, 1, 3);
            this.tblThongTin.Controls.Add(this.lblEmail, 0, 4);
            this.tblThongTin.Controls.Add(this.lblEmailValue, 1, 4);
            this.tblThongTin.Controls.Add(this.lblDiaChi, 0, 5);
            this.tblThongTin.Controls.Add(this.lblDiaChiValue, 1, 5);
            this.tblThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblThongTin.Location = new System.Drawing.Point(20, 20);
            this.tblThongTin.Name = "tblThongTin";
            this.tblThongTin.Padding = new System.Windows.Forms.Padding(10);
            this.tblThongTin.RowCount = 6;
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblThongTin.Size = new System.Drawing.Size(480, 280);
            this.tblThongTin.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblHoTen.Location = new System.Drawing.Point(13, 10);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(155, 43);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoTenValue
            // 
            this.lblHoTenValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTenValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTenValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblHoTenValue.Location = new System.Drawing.Point(174, 10);
            this.lblHoTenValue.Name = "lblHoTenValue";
            this.lblHoTenValue.Size = new System.Drawing.Size(293, 43);
            this.lblHoTenValue.TabIndex = 1;
            this.lblHoTenValue.Text = "--";
            this.lblHoTenValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblGioiTinh.Location = new System.Drawing.Point(13, 53);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(155, 43);
            this.lblGioiTinh.TabIndex = 2;
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGioiTinhValue
            // 
            this.lblGioiTinhValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioiTinhValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinhValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblGioiTinhValue.Location = new System.Drawing.Point(174, 53);
            this.lblGioiTinhValue.Name = "lblGioiTinhValue";
            this.lblGioiTinhValue.Size = new System.Drawing.Size(293, 43);
            this.lblGioiTinhValue.TabIndex = 3;
            this.lblGioiTinhValue.Text = "--";
            this.lblGioiTinhValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblNgaySinh.Location = new System.Drawing.Point(13, 96);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(155, 43);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh";
            this.lblNgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgaySinhValue
            // 
            this.lblNgaySinhValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinhValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinhValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblNgaySinhValue.Location = new System.Drawing.Point(174, 96);
            this.lblNgaySinhValue.Name = "lblNgaySinhValue";
            this.lblNgaySinhValue.Size = new System.Drawing.Size(293, 43);
            this.lblNgaySinhValue.TabIndex = 5;
            this.lblNgaySinhValue.Text = "--";
            this.lblNgaySinhValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblSoDienThoai.Location = new System.Drawing.Point(13, 139);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(155, 43);
            this.lblSoDienThoai.TabIndex = 6;
            this.lblSoDienThoai.Text = "Số điện thoại";
            this.lblSoDienThoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoDienThoaiValue
            // 
            this.lblSoDienThoaiValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoaiValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoaiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblSoDienThoaiValue.Location = new System.Drawing.Point(174, 139);
            this.lblSoDienThoaiValue.Name = "lblSoDienThoaiValue";
            this.lblSoDienThoaiValue.Size = new System.Drawing.Size(293, 43);
            this.lblSoDienThoaiValue.TabIndex = 7;
            this.lblSoDienThoaiValue.Text = "--";
            this.lblSoDienThoaiValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblEmail.Location = new System.Drawing.Point(13, 182);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(155, 43);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblEmailValue.Location = new System.Drawing.Point(174, 182);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(293, 43);
            this.lblEmailValue.TabIndex = 9;
            this.lblEmailValue.Text = "--";
            this.lblEmailValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblDiaChi.Location = new System.Drawing.Point(13, 225);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(155, 45);
            this.lblDiaChi.TabIndex = 10;
            this.lblDiaChi.Text = "Địa chỉ";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiaChiValue
            // 
            this.lblDiaChiValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChiValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.lblDiaChiValue.Location = new System.Drawing.Point(174, 225);
            this.lblDiaChiValue.Name = "lblDiaChiValue";
            this.lblDiaChiValue.Size = new System.Drawing.Size(293, 45);
            this.lblDiaChiValue.TabIndex = 11;
            this.lblDiaChiValue.Text = "--";
            this.lblDiaChiValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 380);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(520, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(194, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(132, 36);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // fThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 440);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThongTinCaNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.fThongTinCaNhan_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tblThongTin.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tblThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblHoTenValue;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblGioiTinhValue;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblNgaySinhValue;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoaiValue;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblDiaChiValue;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnDong;
    }
}
