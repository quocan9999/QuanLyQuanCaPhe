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
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlChonDichVu = new System.Windows.Forms.Panel();
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
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblNgayHienTai
            // 
            this.lblNgayHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgayHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgayHienTai.ForeColor = System.Drawing.Color.White;
            this.lblNgayHienTai.Location = new System.Drawing.Point(800, 15);
            this.lblNgayHienTai.Name = "lblNgayHienTai";
            this.lblNgayHienTai.Size = new System.Drawing.Size(380, 30);
            this.lblNgayHienTai.TabIndex = 2;
            this.lblNgayHienTai.Text = "Waiting...";
            this.lblNgayHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenQuan.ForeColor = System.Drawing.Color.White;
            this.lblTenQuan.Location = new System.Drawing.Point(20, 15);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(400, 30);
            this.lblTenQuan.TabIndex = 0;
            this.lblTenQuan.Text = "☕ QUẢN LÝ CÀ PHÊ";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblTenNhanVien.Location = new System.Drawing.Point(420, 15);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(250, 30);
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
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1200, 640);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flpBan);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(354, 634);
            this.pnlLeft.TabIndex = 0;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 50);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(10);
            this.flpBan.Size = new System.Drawing.Size(354, 584);
            this.flpBan.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilter.Controls.Add(this.cboLocKhuVuc);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(354, 50);
            this.pnlFilter.TabIndex = 0;
            // 
            // lblLocKhuVuc
            // 
            this.lblLocKhuVuc.AutoSize = true;
            this.lblLocKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocKhuVuc.Location = new System.Drawing.Point(10, 15);
            this.lblLocKhuVuc.Name = "lblLocKhuVuc";
            this.lblLocKhuVuc.Size = new System.Drawing.Size(65, 18);
            this.lblLocKhuVuc.TabIndex = 0;
            this.lblLocKhuVuc.Text = "Khu vực:";
            // 
            // cboLocKhuVuc
            // 
            this.cboLocKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocKhuVuc.FormattingEnabled = true;
            this.cboLocKhuVuc.Location = new System.Drawing.Point(90, 12);
            this.cboLocKhuVuc.Name = "cboLocKhuVuc";
            this.cboLocKhuVuc.Size = new System.Drawing.Size(200, 26);
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
            this.pnlCenter.Location = new System.Drawing.Point(363, 3);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(594, 634);
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
            this.dgvHoaDon.Location = new System.Drawing.Point(10, 100);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(574, 350);
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
            this.lblInvoiceTitle.Location = new System.Drawing.Point(9, 59);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(300, 25);
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
            this.btnOrderMon.Location = new System.Drawing.Point(450, 50);
            this.btnOrderMon.Name = "btnOrderMon";
            this.btnOrderMon.Size = new System.Drawing.Size(134, 45);
            this.btnOrderMon.TabIndex = 0;
            this.btnOrderMon.Text = "Thêm món";
            this.btnOrderMon.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightGray;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(276, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(169, 40);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Cập nhật số lượng";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(481, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // pnlChonDichVu
            // 
            this.pnlChonDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChonDichVu.Controls.Add(this.btnXoa);
            this.pnlChonDichVu.Controls.Add(this.btnSua);
            this.pnlChonDichVu.Controls.Add(this.lblQuantity);
            this.pnlChonDichVu.Controls.Add(this.nudQuantity);
            this.pnlChonDichVu.Location = new System.Drawing.Point(10, 510);
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(574, 50);
            this.pnlChonDichVu.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(0, 15);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(150, 25);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng mới:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(160, 15);
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
            this.nudQuantity.Size = new System.Drawing.Size(100, 22);
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
            this.pnlServiceButton.Location = new System.Drawing.Point(10, 570);
            this.pnlServiceButton.Name = "pnlServiceButton";
            this.pnlServiceButton.Size = new System.Drawing.Size(574, 50);
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
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(574, 50);
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
            this.btnMoBan.Size = new System.Drawing.Size(187, 46);
            this.btnMoBan.TabIndex = 0;
            this.btnMoBan.Text = "Mở bàn mới";
            this.btnMoBan.UseVisualStyleBackColor = false;
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.LightGray;
            this.btnChuyenBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Location = new System.Drawing.Point(193, 2);
            this.btnChuyenBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(187, 46);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuyHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(384, 2);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(188, 46);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy bàn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlThongTinHoaDon);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(963, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(234, 634);
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
            this.pnlThongTinHoaDon.Name = "pnlThongTinHoaDon";
            this.pnlThongTinHoaDon.Padding = new System.Windows.Forms.Padding(10);
            this.pnlThongTinHoaDon.Size = new System.Drawing.Size(234, 634);
            this.pnlThongTinHoaDon.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.BackColor = System.Drawing.Color.White;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTien.Location = new System.Drawing.Point(5, 475);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new System.Windows.Forms.Padding(5);
            this.lblTongTien.Size = new System.Drawing.Size(224, 57);
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
            this.lblGiamGia.Location = new System.Drawing.Point(10, 425);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblGiamGia.Size = new System.Drawing.Size(214, 40);
            this.lblGiamGia.TabIndex = 1;
            this.lblGiamGia.Text = "Giảm giá: 0%";
            this.lblGiamGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThoiGianBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(10, 60);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Padding = new System.Windows.Forms.Padding(8);
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(214, 121);
            this.lblThoiGianBatDau.TabIndex = 4;
            this.lblThoiGianBatDau.Text = "GIỜ VÀO\r\n\r\nNgày: --/--/----\r\nGiờ: --:--:--";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblMaHoaDon.Location = new System.Drawing.Point(10, 10);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(214, 40);
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
            this.btnThanhToan.Location = new System.Drawing.Point(10, 548);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(214, 76);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
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
            this.ResumeLayout(false);

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
    }
}