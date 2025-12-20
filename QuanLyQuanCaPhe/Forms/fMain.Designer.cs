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
            this.pnlChatBot = new System.Windows.Forms.Panel();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.pnlChatInput = new System.Windows.Forms.Panel();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.btnClearChat = new System.Windows.Forms.Button();
            this.cboChatMode = new System.Windows.Forms.ComboBox();
            this.lblChatTitle = new System.Windows.Forms.Label();
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
            this.lblTrangThaiThanhToan = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
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
            this.tsmiQuanLyNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoCaoBanChay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlChatBot.SuspendLayout();
            this.pnlChatInput.SuspendLayout();
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
            this.pnlHeader.Location = new System.Drawing.Point(0, 28);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 1;
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
            this.lblTenNhanVien.Size = new System.Drawing.Size(399, 30);
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
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 88);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 610F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1200, 612);
            this.tableLayoutMain.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlChatBot);
            this.pnlLeft.Controls.Add(this.flpBan);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 2);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(354, 608);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlChatBot
            // 
            this.pnlChatBot.BackColor = System.Drawing.Color.White;
            this.pnlChatBot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChatBot.Controls.Add(this.rtbChatHistory);
            this.pnlChatBot.Controls.Add(this.pnlChatInput);
            this.pnlChatBot.Controls.Add(this.lblChatTitle);
            this.pnlChatBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChatBot.Location = new System.Drawing.Point(0, 494);
            this.pnlChatBot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlChatBot.Name = "pnlChatBot";
            this.pnlChatBot.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlChatBot.Size = new System.Drawing.Size(354, 114);
            this.pnlChatBot.TabIndex = 2;
            // 
            // rtbChatHistory
            // 
            this.rtbChatHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbChatHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChatHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtbChatHistory.Location = new System.Drawing.Point(7, 43);
            this.rtbChatHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Size = new System.Drawing.Size(338, 0);
            this.rtbChatHistory.TabIndex = 1;
            this.rtbChatHistory.Text = "Xin chào! Tôi có thể giúp gì cho bạn?\n\nThử hỏi:\n- \"Món bán chạy nhất hôm nay?\"\n- " +
    "\"Gợi ý món cho khách nữ?\"\n- \"Món phù hợp buổi sáng?\"\n";
            // 
            // pnlChatInput
            // 
            this.pnlChatInput.Controls.Add(this.txtChatInput);
            this.pnlChatInput.Controls.Add(this.btnSendChat);
            this.pnlChatInput.Controls.Add(this.btnClearChat);
            this.pnlChatInput.Controls.Add(this.cboChatMode);
            this.pnlChatInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChatInput.Location = new System.Drawing.Point(7, 35);
            this.pnlChatInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlChatInput.Name = "pnlChatInput";
            this.pnlChatInput.Size = new System.Drawing.Size(338, 71);
            this.pnlChatInput.TabIndex = 2;
            // 
            // txtChatInput
            // 
            this.txtChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChatInput.Location = new System.Drawing.Point(0, 31);
            this.txtChatInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(190, 27);
            this.txtChatInput.TabIndex = 1;
            this.txtChatInput.Text = "Nhập câu hỏi...";
            this.txtChatInput.GotFocus += new System.EventHandler(this.txtChatInput_GotFocus);
            this.txtChatInput.LostFocus += new System.EventHandler(this.txtChatInput_LostFocus);
            // 
            // btnSendChat
            // 
            this.btnSendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendChat.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSendChat.ForeColor = System.Drawing.Color.White;
            this.btnSendChat.Location = new System.Drawing.Point(196, 31);
            this.btnSendChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(67, 28);
            this.btnSendChat.TabIndex = 2;
            this.btnSendChat.Text = "Gửi";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // btnClearChat
            // 
            this.btnClearChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearChat.BackColor = System.Drawing.Color.IndianRed;
            this.btnClearChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearChat.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnClearChat.ForeColor = System.Drawing.Color.White;
            this.btnClearChat.Location = new System.Drawing.Point(268, 31);
            this.btnClearChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearChat.Name = "btnClearChat";
            this.btnClearChat.Size = new System.Drawing.Size(67, 28);
            this.btnClearChat.TabIndex = 3;
            this.btnClearChat.Text = "Xóa";
            this.btnClearChat.UseVisualStyleBackColor = false;
            this.btnClearChat.Click += new System.EventHandler(this.btnClearChat_Click);
            // 
            // cboChatMode
            // 
            this.cboChatMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboChatMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChatMode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cboChatMode.Items.AddRange(new object[] {
            "Gợi ý theo bối cảnh",
            "Món bán chạy nhất",
            "Món lợi nhuận cao",
            "Món theo thời gian"});
            this.cboChatMode.Location = new System.Drawing.Point(0, 0);
            this.cboChatMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboChatMode.Name = "cboChatMode";
            this.cboChatMode.Size = new System.Drawing.Size(338, 25);
            this.cboChatMode.TabIndex = 0;
            // 
            // lblChatTitle
            // 
            this.lblChatTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblChatTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChatTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblChatTitle.ForeColor = System.Drawing.Color.White;
            this.lblChatTitle.Location = new System.Drawing.Point(7, 6);
            this.lblChatTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChatTitle.Name = "lblChatTitle";
            this.lblChatTitle.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblChatTitle.Size = new System.Drawing.Size(338, 37);
            this.lblChatTitle.TabIndex = 0;
            this.lblChatTitle.Text = "🤖 Trợ Lý AI Gợi Ý Món";
            this.lblChatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpBan.Location = new System.Drawing.Point(0, 50);
            this.flpBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.flpBan.Size = new System.Drawing.Size(354, 444);
            this.flpBan.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilter.Controls.Add(this.cboLocKhuVuc);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(354, 50);
            this.pnlFilter.TabIndex = 0;
            // 
            // lblLocKhuVuc
            // 
            this.lblLocKhuVuc.AutoSize = true;
            this.lblLocKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocKhuVuc.Location = new System.Drawing.Point(11, 15);
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
            this.cboLocKhuVuc.Location = new System.Drawing.Point(91, 12);
            this.cboLocKhuVuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pnlCenter.Location = new System.Drawing.Point(363, 2);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(594, 608);
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
            this.dgvHoaDon.Location = new System.Drawing.Point(11, 100);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(572, 263);
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
            this.btnOrderMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderMon.Name = "btnOrderMon";
            this.btnOrderMon.Size = new System.Drawing.Size(133, 46);
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
            this.pnlChonDichVu.Location = new System.Drawing.Point(11, 423);
            this.pnlChonDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(572, 50);
            this.pnlChonDichVu.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(481, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 39);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightGray;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(276, 5);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(169, 39);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Cập nhật số lượng";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(0, 15);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(149, 25);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng mới:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(160, 15);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pnlServiceButton.Location = new System.Drawing.Point(11, 483);
            this.pnlServiceButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlServiceButton.Name = "pnlServiceButton";
            this.pnlServiceButton.Size = new System.Drawing.Size(572, 50);
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
            this.tlpActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(572, 50);
            this.tlpActions.TabIndex = 0;
            // 
            // btnMoBan
            // 
            this.btnMoBan.BackColor = System.Drawing.Color.LightGray;
            this.btnMoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBan.Location = new System.Drawing.Point(3, 2);
            this.btnMoBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoBan.Name = "btnMoBan";
            this.btnMoBan.Size = new System.Drawing.Size(184, 46);
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
            this.btnChuyenBan.Location = new System.Drawing.Point(193, 2);
            this.btnChuyenBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(184, 46);
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
            this.btnHuyHoaDon.Location = new System.Drawing.Point(383, 2);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(186, 46);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy bàn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            this.btnHuyHoaDon.Click += new System.EventHandler(this.btnHuyHoaDon_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlThongTinHoaDon);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(963, 2);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(234, 608);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlThongTinHoaDon
            // 
            this.pnlThongTinHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlThongTinHoaDon.Controls.Add(this.lblTrangThaiThanhToan);
            this.pnlThongTinHoaDon.Controls.Add(this.lblTongTien);
            this.pnlThongTinHoaDon.Controls.Add(this.lblThoiGianBatDau);
            this.pnlThongTinHoaDon.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinHoaDon.Controls.Add(this.btnThanhToan);
            this.pnlThongTinHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTinHoaDon.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlThongTinHoaDon.Name = "pnlThongTinHoaDon";
            this.pnlThongTinHoaDon.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlThongTinHoaDon.Size = new System.Drawing.Size(234, 608);
            this.pnlThongTinHoaDon.TabIndex = 0;
            // 
            // lblTrangThaiThanhToan
            // 
            this.lblTrangThaiThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangThaiThanhToan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTrangThaiThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiThanhToan.ForeColor = System.Drawing.Color.DimGray;
            this.lblTrangThaiThanhToan.Location = new System.Drawing.Point(11, 334);
            this.lblTrangThaiThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThaiThanhToan.Name = "lblTrangThaiThanhToan";
            this.lblTrangThaiThanhToan.Size = new System.Drawing.Size(212, 43);
            this.lblTrangThaiThanhToan.TabIndex = 7;
            this.lblTrangThaiThanhToan.Text = "Trạng thái: --";
            this.lblTrangThaiThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.BackColor = System.Drawing.Color.White;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTien.Location = new System.Drawing.Point(5, 388);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblTongTien.Size = new System.Drawing.Size(223, 57);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG: 0đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(11, 60);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(213, 270);
            this.lblThoiGianBatDau.TabIndex = 4;
            this.lblThoiGianBatDau.Text = "GIỜ VÀO\r\n\r\nNgày: --/--/----\r\nGiờ: --:--:--";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblMaHoaDon.Location = new System.Drawing.Point(11, 10);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(213, 39);
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
            this.btnThanhToan.Location = new System.Drawing.Point(11, 522);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(212, 76);
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
            this.mnsMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mnsMain.Size = new System.Drawing.Size(1200, 28);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tsmiThongTinTaiKhoan
            // 
            this.tsmiThongTinTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThongTinCaNhan,
            this.tsmiDangXuat});
            this.tsmiThongTinTaiKhoan.Name = "tsmiThongTinTaiKhoan";
            this.tsmiThongTinTaiKhoan.Size = new System.Drawing.Size(151, 24);
            this.tsmiThongTinTaiKhoan.Text = "Thông tin tài khoản";
            // 
            // tsmiThongTinCaNhan
            // 
            this.tsmiThongTinCaNhan.Name = "tsmiThongTinCaNhan";
            this.tsmiThongTinCaNhan.Size = new System.Drawing.Size(210, 26);
            this.tsmiThongTinCaNhan.Text = "Thông tin cá nhân";
            this.tsmiThongTinCaNhan.Click += new System.EventHandler(this.tsmiThongTinCaNhan_Click);
            // 
            // tsmiDangXuat
            // 
            this.tsmiDangXuat.Name = "tsmiDangXuat";
            this.tsmiDangXuat.Size = new System.Drawing.Size(210, 26);
            this.tsmiDangXuat.Text = "Đăng xuất";
            this.tsmiDangXuat.Click += new System.EventHandler(this.tsmiDangXuat_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuanLyBan,
            this.tmsiQuanLySanPham,
            this.tsmiQuanLyDanhMuc,
            this.tsmiQuanLyTaiKhoan,
            this.tsmiQuanLyNhanVien});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // tsmiQuanLyBan
            // 
            this.tsmiQuanLyBan.Name = "tsmiQuanLyBan";
            this.tsmiQuanLyBan.Size = new System.Drawing.Size(211, 26);
            this.tsmiQuanLyBan.Text = "Quản lý bàn";
            this.tsmiQuanLyBan.Click += new System.EventHandler(this.tsmiQuanLyBan_Click);
            // 
            // tmsiQuanLySanPham
            // 
            this.tmsiQuanLySanPham.Name = "tmsiQuanLySanPham";
            this.tmsiQuanLySanPham.Size = new System.Drawing.Size(211, 26);
            this.tmsiQuanLySanPham.Text = "Quản lý sản phẩm";
            this.tmsiQuanLySanPham.Click += new System.EventHandler(this.tmsiQuanLySanPham_Click);
            // 
            // tsmiQuanLyDanhMuc
            // 
            this.tsmiQuanLyDanhMuc.Name = "tsmiQuanLyDanhMuc";
            this.tsmiQuanLyDanhMuc.Size = new System.Drawing.Size(211, 26);
            this.tsmiQuanLyDanhMuc.Text = "Quản lý danh mục";
            this.tsmiQuanLyDanhMuc.Click += new System.EventHandler(this.tsmiQuanLyDanhMuc_Click);
            // 
            // tsmiQuanLyTaiKhoan
            // 
            this.tsmiQuanLyTaiKhoan.Name = "tsmiQuanLyTaiKhoan";
            this.tsmiQuanLyTaiKhoan.Size = new System.Drawing.Size(211, 26);
            this.tsmiQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.tsmiQuanLyTaiKhoan.Click += new System.EventHandler(this.tsmiQuanLyTaiKhoan_Click);
            // 
            // tsmiQuanLyNhanVien
            // 
            this.tsmiQuanLyNhanVien.Name = "tsmiQuanLyNhanVien";
            this.tsmiQuanLyNhanVien.Size = new System.Drawing.Size(211, 26);
            this.tsmiQuanLyNhanVien.Text = "Quản lý nhân viên";
            this.tsmiQuanLyNhanVien.Click += new System.EventHandler(this.tsmiQuanLyNhanVien_Click);
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBaoCaoBanChay,
            this.tsmiBaoCaoDoanhThu});
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo";
            // 
            // tsmiBaoCaoBanChay
            // 
            this.tsmiBaoCaoBanChay.Name = "tsmiBaoCaoBanChay";
            this.tsmiBaoCaoBanChay.Size = new System.Drawing.Size(217, 26);
            this.tsmiBaoCaoBanChay.Text = "Báo cáo bán chạy";
            this.tsmiBaoCaoBanChay.Click += new System.EventHandler(this.tsmiBaoCaoBanChay_Click);
            // 
            // tsmiBaoCaoDoanhThu
            // 
            this.tsmiBaoCaoDoanhThu.Name = "tsmiBaoCaoDoanhThu";
            this.tsmiBaoCaoDoanhThu.Size = new System.Drawing.Size(217, 26);
            this.tsmiBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            this.tsmiBaoCaoDoanhThu.Click += new System.EventHandler(this.tsmiBaoCaoDoanhThu_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1215, 737);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Cà Phê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlChatBot.ResumeLayout(false);
            this.pnlChatInput.ResumeLayout(false);
            this.pnlChatInput.PerformLayout();
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
        private System.Windows.Forms.Label lblTrangThaiThanhToan;
        private System.Windows.Forms.Panel pnlChatBot;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.Label lblChatTitle;
        private System.Windows.Forms.Panel pnlChatInput;
        private System.Windows.Forms.ComboBox cboChatMode;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLyNhanVien;
    }
}