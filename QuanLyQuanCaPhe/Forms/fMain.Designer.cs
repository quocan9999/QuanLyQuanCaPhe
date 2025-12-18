namespace QuanLyQuanCaPhe
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNgayHienTai = new System.Windows.Forms.Label();
            this.lblTenQuan = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblLocKhuVuc = new System.Windows.Forms.Label();
            this.cboLocKhuVuc = new System.Windows.Forms.ComboBox();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.btnOrderMon = new System.Windows.Forms.Button();
            this.pnlChonDichVu = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.pnlServiceButton = new System.Windows.Forms.Panel();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoBan = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlThongTinHoaDon = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tsmiThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiThongTinCaNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuanLyBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiQuanLySanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuanLyDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoCaoBanChay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlChonDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.pnlServiceButton.SuspendLayout();
            this.tlpActions.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlThongTinHoaDon.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlHeader.Controls.Add(this.lblNgayHienTai);
            this.pnlHeader.Controls.Add(this.lblTenQuan);
            this.pnlHeader.Controls.Add(this.lblTenNhanVien);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 24);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 49);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblNgayHienTai
            // 
            this.lblNgayHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgayHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgayHienTai.ForeColor = System.Drawing.Color.White;
            this.lblNgayHienTai.Location = new System.Drawing.Point(600, 12);
            this.lblNgayHienTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayHienTai.Name = "lblNgayHienTai";
            this.lblNgayHienTai.Size = new System.Drawing.Size(285, 24);
            this.lblNgayHienTai.TabIndex = 2;
            this.lblNgayHienTai.Text = "Waiting...";
            this.lblNgayHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenQuan.ForeColor = System.Drawing.Color.White;
            this.lblTenQuan.Location = new System.Drawing.Point(15, 12);
            this.lblTenQuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(300, 24);
            this.lblTenQuan.TabIndex = 0;
            this.lblTenQuan.Text = "☕ QUẢN LÝ CÀ PHÊ";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblTenNhanVien.Location = new System.Drawing.Point(315, 12);
            this.lblTenNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(299, 24);
            this.lblTenNhanVien.TabIndex = 1;
            this.lblTenNhanVien.Text = "Nhân viên: ";
            this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tableLayoutMain.Controls.Add(this.pnlCenter, 1, 0);
            this.tableLayoutMain.Controls.Add(this.pnlRight, 2, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 496F));
            this.tableLayoutMain.Size = new System.Drawing.Size(900, 496);
            this.tableLayoutMain.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flpBan);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(2, 2);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(266, 492);
            this.pnlLeft.TabIndex = 0;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 41);
            this.flpBan.Margin = new System.Windows.Forms.Padding(2);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(8);
            this.flpBan.Size = new System.Drawing.Size(266, 451);
            this.flpBan.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilter.Controls.Add(this.cboLocKhuVuc);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(266, 41);
            this.pnlFilter.TabIndex = 0;
            // 
            // lblLocKhuVuc
            // 
            this.lblLocKhuVuc.AutoSize = true;
            this.lblLocKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocKhuVuc.Location = new System.Drawing.Point(8, 12);
            this.lblLocKhuVuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocKhuVuc.Name = "lblLocKhuVuc";
            this.lblLocKhuVuc.Size = new System.Drawing.Size(53, 15);
            this.lblLocKhuVuc.TabIndex = 0;
            this.lblLocKhuVuc.Text = "Khu vực:";
            // 
            // cboLocKhuVuc
            // 
            this.cboLocKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocKhuVuc.FormattingEnabled = true;
            this.cboLocKhuVuc.Location = new System.Drawing.Point(68, 10);
            this.cboLocKhuVuc.Margin = new System.Windows.Forms.Padding(2);
            this.cboLocKhuVuc.Name = "cboLocKhuVuc";
            this.cboLocKhuVuc.Size = new System.Drawing.Size(151, 23);
            this.cboLocKhuVuc.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.dgvHoaDon);
            this.pnlCenter.Controls.Add(this.lblInvoiceTitle);
            this.pnlCenter.Controls.Add(this.btnOrderMon);
            this.pnlCenter.Controls.Add(this.pnlChonDichVu);
            this.pnlCenter.Controls.Add(this.pnlServiceButton);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(272, 2);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(446, 492);
            this.pnlCenter.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPrice,
            this.colQuantity,
            this.colTotal});
            this.dgvHoaDon.Location = new System.Drawing.Point(8, 81);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(430, 212);
            this.dgvHoaDon.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên Món";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "SL";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Thành tiền";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblInvoiceTitle.Location = new System.Drawing.Point(7, 48);
            this.lblInvoiceTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(225, 20);
            this.lblInvoiceTitle.TabIndex = 1;
            this.lblInvoiceTitle.Text = "Hóa đơn bàn --";
            // 
            // btnOrderMon
            // 
            this.btnOrderMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderMon.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrderMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrderMon.ForeColor = System.Drawing.Color.White;
            this.btnOrderMon.Location = new System.Drawing.Point(338, 41);
            this.btnOrderMon.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderMon.Name = "btnOrderMon";
            this.btnOrderMon.Size = new System.Drawing.Size(100, 37);
            this.btnOrderMon.TabIndex = 0;
            this.btnOrderMon.Text = "Thêm món";
            this.btnOrderMon.UseVisualStyleBackColor = false;
            this.btnOrderMon.Click += new System.EventHandler(this.btnOrderMon_Click);
            // 
            // pnlChonDichVu
            // 
            this.pnlChonDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChonDichVu.Controls.Add(this.btnXoa);
            this.pnlChonDichVu.Controls.Add(this.btnSua);
            this.pnlChonDichVu.Controls.Add(this.lblQuantity);
            this.pnlChonDichVu.Controls.Add(this.nudQuantity);
            this.pnlChonDichVu.Location = new System.Drawing.Point(8, 342);
            this.pnlChonDichVu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(430, 41);
            this.pnlChonDichVu.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(361, 3);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 32);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightGray;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(207, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(127, 32);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Cập nhật số lượng";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(0, 12);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(112, 20);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng mới:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(120, 12);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(75, 20);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlServiceButton
            // 
            this.pnlServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServiceButton.Controls.Add(this.tlpActions);
            this.pnlServiceButton.Location = new System.Drawing.Point(8, 391);
            this.pnlServiceButton.Margin = new System.Windows.Forms.Padding(2);
            this.pnlServiceButton.Name = "pnlServiceButton";
            this.pnlServiceButton.Size = new System.Drawing.Size(430, 41);
            this.pnlServiceButton.TabIndex = 4;
            // 
            // tlpActions
            // 
            this.tlpActions.ColumnCount = 3;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpActions.Controls.Add(this.btnMoBan, 0, 0);
            this.tlpActions.Controls.Add(this.btnChuyenBan, 1, 0);
            this.tlpActions.Controls.Add(this.btnHuyHoaDon, 2, 0);
            this.tlpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActions.Location = new System.Drawing.Point(0, 0);
            this.tlpActions.Margin = new System.Windows.Forms.Padding(2);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(430, 41);
            this.tlpActions.TabIndex = 0;
            // 
            // btnMoBan
            // 
            this.btnMoBan.BackColor = System.Drawing.Color.LightGray;
            this.btnMoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBan.Location = new System.Drawing.Point(2, 2);
            this.btnMoBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoBan.Name = "btnMoBan";
            this.btnMoBan.Size = new System.Drawing.Size(139, 37);
            this.btnMoBan.TabIndex = 0;
            this.btnMoBan.Text = "Mở bàn mới";
            this.btnMoBan.UseVisualStyleBackColor = false;
            this.btnMoBan.Click += new System.EventHandler(this.BtnMoBan_Click);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.LightGray;
            this.btnChuyenBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Location = new System.Drawing.Point(145, 2);
            this.btnChuyenBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(139, 37);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            this.btnChuyenBan.Click += new System.EventHandler(this.BtnChuyenBan_Click);
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuyHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(288, 2);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(140, 37);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy bàn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlThongTinHoaDon);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(722, 2);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(176, 492);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlThongTinHoaDon
            // 
            this.pnlThongTinHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlThongTinHoaDon.Controls.Add(this.lblTongTien);
            this.pnlThongTinHoaDon.Controls.Add(this.lblGiamGia);
            this.pnlThongTinHoaDon.Controls.Add(this.lblThoiGianBatDau);
            this.pnlThongTinHoaDon.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinHoaDon.Controls.Add(this.btnThanhToan);
            this.pnlThongTinHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTinHoaDon.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.pnlThongTinHoaDon.Name = "pnlThongTinHoaDon";
            this.pnlThongTinHoaDon.Padding = new System.Windows.Forms.Padding(8);
            this.pnlThongTinHoaDon.Size = new System.Drawing.Size(176, 492);
            this.pnlThongTinHoaDon.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.BackColor = System.Drawing.Color.White;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTien.Location = new System.Drawing.Point(4, 314);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new System.Windows.Forms.Padding(4);
            this.lblTongTien.Size = new System.Drawing.Size(168, 46);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG: 0đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiamGia.BackColor = System.Drawing.Color.White;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGiamGia.ForeColor = System.Drawing.Color.Black;
            this.lblGiamGia.Location = new System.Drawing.Point(8, 273);
            this.lblGiamGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.lblGiamGia.Size = new System.Drawing.Size(160, 32);
            this.lblGiamGia.TabIndex = 1;
            this.lblGiamGia.Text = "Giảm giá: 0%";
            this.lblGiamGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThoiGianBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(8, 49);
            this.lblThoiGianBatDau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Padding = new System.Windows.Forms.Padding(6);
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(160, 98);
            this.lblThoiGianBatDau.TabIndex = 4;
            this.lblThoiGianBatDau.Text = "GIỜ VÀO\r\n\r\nNgày: --/--/----\r\nGiờ: --:--:--";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblMaHoaDon.Location = new System.Drawing.Point(8, 8);
            this.lblMaHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(160, 32);
            this.lblMaHoaDon.TabIndex = 5;
            this.lblMaHoaDon.Text = "Mã Hóa Đơn: --";
            this.lblMaHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(8, 422);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(160, 62);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThongTinTaiKhoan,
            this.adminToolStripMenuItem,
            this.báoCáoDoanhThuToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnsMain.Size = new System.Drawing.Size(900, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tsmiThongTinTaiKhoan
            // 
            this.tsmiThongTinTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThongTinCaNhan,
            this.tsmiDangXuat});
            this.tsmiThongTinTaiKhoan.Name = "tsmiThongTinTaiKhoan";
            this.tsmiThongTinTaiKhoan.Size = new System.Drawing.Size(122, 20);
            this.tsmiThongTinTaiKhoan.Text = "Thông tin tài khoản";
            // 
            // tsmiThongTinCaNhan
            // 
            this.tsmiThongTinCaNhan.Name = "tsmiThongTinCaNhan";
            this.tsmiThongTinCaNhan.Size = new System.Drawing.Size(170, 22);
            this.tsmiThongTinCaNhan.Text = "Thông tin cá nhân";
            // 
            // tsmiDangXuat
            // 
            this.tsmiDangXuat.Name = "tsmiDangXuat";
            this.tsmiDangXuat.Size = new System.Drawing.Size(170, 22);
            this.tsmiDangXuat.Text = "Đăng xuất";
            this.tsmiDangXuat.Click += new System.EventHandler(this.tsmiDangXuat_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuanLyBan,
            this.tmsiQuanLySanPham,
            this.tsmiQuanLyDanhMuc,
            this.tsmiQuanLyTaiKhoan});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // tsmiQuanLyBan
            // 
            this.tsmiQuanLyBan.Name = "tsmiQuanLyBan";
            this.tsmiQuanLyBan.Size = new System.Drawing.Size(172, 22);
            this.tsmiQuanLyBan.Text = "Quản lý bàn";
            this.tsmiQuanLyBan.Click += new System.EventHandler(this.tsmiQuanLyBan_Click);
            // 
            // tmsiQuanLySanPham
            // 
            this.tmsiQuanLySanPham.Name = "tmsiQuanLySanPham";
            this.tmsiQuanLySanPham.Size = new System.Drawing.Size(172, 22);
            this.tmsiQuanLySanPham.Text = "Quản lý sản phẩm";
            this.tmsiQuanLySanPham.Click += new System.EventHandler(this.tmsiQuanLySanPham_Click);
            // 
            // tsmiQuanLyDanhMuc
            // 
            this.tsmiQuanLyDanhMuc.Name = "tsmiQuanLyDanhMuc";
            this.tsmiQuanLyDanhMuc.Size = new System.Drawing.Size(172, 22);
            this.tsmiQuanLyDanhMuc.Text = "Quản lý danh mục";
            this.tsmiQuanLyDanhMuc.Click += new System.EventHandler(this.tsmiQuanLyDanhMuc_Click);
            // 
            // tsmiQuanLyTaiKhoan
            // 
            this.tsmiQuanLyTaiKhoan.Name = "tsmiQuanLyTaiKhoan";
            this.tsmiQuanLyTaiKhoan.Size = new System.Drawing.Size(172, 22);
            this.tsmiQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.tsmiQuanLyTaiKhoan.Click += new System.EventHandler(this.tsmiQuanLyTaiKhoan_Click);
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBaoCaoBanChay,
            this.tsmiBaoCaoDoanhThu});
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo";
            // 
            // tsmiBaoCaoBanChay
            // 
            this.tsmiBaoCaoBanChay.Name = "tsmiBaoCaoBanChay";
            this.tsmiBaoCaoBanChay.Size = new System.Drawing.Size(174, 22);
            this.tsmiBaoCaoBanChay.Text = "Báo cáo bán chạy";
            this.tsmiBaoCaoBanChay.Click += new System.EventHandler(this.tsmiBaoCaoBanChay_Click);
            // 
            // tsmiBaoCaoDoanhThu
            // 
            this.tsmiBaoCaoDoanhThu.Name = "tsmiBaoCaoDoanhThu";
            this.tsmiBaoCaoDoanhThu.Size = new System.Drawing.Size(174, 22);
            this.tsmiBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            this.tsmiBaoCaoDoanhThu.Click += new System.EventHandler(this.tsmiBaoCaoDoanhThu_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 569);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(916, 608);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Cà Phê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlChonDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.pnlServiceButton.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlThongTinHoaDon.ResumeLayout(false);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNgayHienTai;
        private System.Windows.Forms.Label lblTenQuan;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cboLocKhuVuc;
        private System.Windows.Forms.Label lblLocKhuVuc;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.Button btnOrderMon;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlChonDichVu;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Panel pnlServiceButton;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Button btnMoBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnHuyHoaDon;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlThongTinHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiThongTinTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem tsmiThongTinCaNhan;
        private System.Windows.Forms.ToolStripMenuItem tsmiDangXuat;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLyBan;
        private System.Windows.Forms.ToolStripMenuItem tmsiQuanLySanPham;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLyDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem báoCáoDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaoCaoBanChay;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaoCaoDoanhThu;
    }
}