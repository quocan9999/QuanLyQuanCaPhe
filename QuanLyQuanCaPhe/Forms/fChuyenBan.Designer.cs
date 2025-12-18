namespace QuanLyQuanCaPhe
{
    partial class fChuyenBan
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblBanHienTai = new System.Windows.Forms.Label();
            this.lblChonBanMoi = new System.Windows.Forms.Label();
            this.cboBanMoi = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlNutBam = new System.Windows.Forms.Panel();
            this.pnlNoiDung.SuspendLayout();
            this.pnlNutBam.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTieuDe.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(364, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CHUYỂN BÀN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNoiDung.Controls.Add(this.cboBanMoi);
            this.pnlNoiDung.Controls.Add(this.lblChonBanMoi);
            this.pnlNoiDung.Controls.Add(this.lblBanHienTai);
            this.pnlNoiDung.Location = new System.Drawing.Point(10, 53);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(20);
            this.pnlNoiDung.Size = new System.Drawing.Size(364, 120);
            this.pnlNoiDung.TabIndex = 1;
            // 
            // lblBanHienTai
            // 
            this.lblBanHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblBanHienTai.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBanHienTai.Location = new System.Drawing.Point(20, 15);
            this.lblBanHienTai.Name = "lblBanHienTai";
            this.lblBanHienTai.Size = new System.Drawing.Size(324, 25);
            this.lblBanHienTai.TabIndex = 0;
            this.lblBanHienTai.Text = "Bàn hiện tại: ---";
            // 
            // lblChonBanMoi
            // 
            this.lblChonBanMoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChonBanMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblChonBanMoi.Location = new System.Drawing.Point(20, 50);
            this.lblChonBanMoi.Name = "lblChonBanMoi";
            this.lblChonBanMoi.Size = new System.Drawing.Size(324, 23);
            this.lblChonBanMoi.TabIndex = 1;
            this.lblChonBanMoi.Text = "Chọn bàn muốn chuyển tới:";
            // 
            // cboBanMoi
            // 
            this.cboBanMoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBanMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cboBanMoi.FormattingEnabled = true;
            this.cboBanMoi.Location = new System.Drawing.Point(20, 76);
            this.cboBanMoi.Name = "cboBanMoi";
            this.cboBanMoi.Size = new System.Drawing.Size(324, 26);
            this.cboBanMoi.TabIndex = 2;
            // 
            // pnlNutBam
            // 
            this.pnlNutBam.Controls.Add(this.btnHuy);
            this.pnlNutBam.Controls.Add(this.btnXacNhan);
            this.pnlNutBam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNutBam.Location = new System.Drawing.Point(10, 179);
            this.pnlNutBam.Name = "pnlNutBam";
            this.pnlNutBam.Size = new System.Drawing.Size(364, 50);
            this.pnlNutBam.TabIndex = 2;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXacNhan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(62, 8);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(110, 35);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            // Gắn sự kiện click trực tiếp tại đây
            this.btnXacNhan.Click += new System.EventHandler(this.BtnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(192, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 35);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // Gắn sự kiện click trực tiếp tại đây
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // fChuyenBan
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlNutBam);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.Name = "fChuyenBan";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển Bàn";
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlNutBam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblBanHienTai;
        private System.Windows.Forms.Label lblChonBanMoi;
        private System.Windows.Forms.ComboBox cboBanMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlNutBam;
    }
}