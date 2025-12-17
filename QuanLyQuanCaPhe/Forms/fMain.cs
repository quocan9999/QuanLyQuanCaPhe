using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class fMain : Form
    {
        // Biến lưu trạng thái hiện tại
        private int _selectedTableId = -1; // ID bàn đang được chọn
        private string _selectedTableName = "";

        public fMain()
        {
            InitializeComponent();
            InitializeForm();
            SetupEventHandlers();

            // Load dữ liệu
            LoadComboBoxKhuVuc();
            LoadTables();
        }

        private void InitializeForm()
        {
            UpdateDateTime();
            dgvHoaDon.Rows.Clear();
            btnThanhToan.Enabled = false;

            // todo: hiển thị nhân viên động theo bảng đăng nhập
            lblTenNhanVien.Text = "Nhân viên: Admin";
        }

        private void SetupEventHandlers()
        {
            // Các sự kiện nút bấm
            btnMoBan.Click += BtnMoBan_Click;
            btnOrderMon.Click += btnOrderMon_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnChuyenBan.Click += BtnChuyenBan_Click;

            // Sự kiện bộ lọc
            cboLocKhuVuc.SelectedIndexChanged += (s, e) => LoadTables();

            // Sự kiện grid
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;

            // Timer cập nhật ngày giờ
            timer1.Tick += (s, e) => UpdateDateTime();
        }

        #region 1. QUẢN LÝ BÀN & HIỂN THỊ (Load Tables - ADO.NET DataProvider)

        private void LoadComboBoxKhuVuc()
        {
            string query = "SELECT DISTINCT ViTri FROM Ban";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);

            cboLocKhuVuc.Items.Clear();
            cboLocKhuVuc.Items.Add("Tất cả");
            foreach (DataRow row in data.Rows)
            {
                cboLocKhuVuc.Items.Add(row["ViTri"].ToString());
            }
            cboLocKhuVuc.SelectedIndex = 0;
        }

        private void LoadTables()
        {
            flpBan.SuspendLayout();
            flpBan.Controls.Clear();

            string filterKV = cboLocKhuVuc.SelectedItem?.ToString() ?? "Tất cả";

            string query = "SELECT * FROM Ban";
            DataTable data;

            if (filterKV != "Tất cả")
            {
                query += " WHERE ViTri = @ViTri";
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@ViTri", filterKV)
                };
                data = DataProvider.Instance.ExecuteQuery(query, paras);
            }
            else
            {
                data = DataProvider.Instance.ExecuteQuery(query, null);
            }

            foreach (DataRow row in data.Rows)
            {
                int id = (int)row["Id"];
                string tenBan = row["TenBan"].ToString();
                string trangThai = row["TrangThai"].ToString();
                string viTri = row["ViTri"].ToString();

                Button btn = new Button();
                btn.Name = "btnBan_" + id;
                btn.Size = new Size(110, 110);
                btn.Margin = new Padding(5);
                btn.Tag = row; // Lưu cả dòng dữ liệu vào Tag
                btn.Click += BtnTable_Click;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;

                UpdateButtonVisual(btn, tenBan, trangThai, viTri, id);

                flpBan.Controls.Add(btn);
            }
            flpBan.ResumeLayout();
        }

        private void UpdateButtonVisual(Button btn, string tenBan, string trangThai, string viTri, int id)
        {
            // Xử lý màu sắc
            if (id == _selectedTableId)
            {
                btn.BackColor = Color.Yellow;
                btn.ForeColor = Color.Black;
            }
            else if (trangThai == "Có người")
            {
                btn.BackColor = Color.ForestGreen;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
            }

            btn.Text = $"{tenBan}\n({viTri})\n\n{trangThai}";
            btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            DataRow row = (DataRow)btn.Tag;
            _selectedTableId = (int)row["Id"];
            _selectedTableName = row["TenBan"].ToString();
            string trangThai = row["TrangThai"].ToString();

            // Cập nhật giao diện khi chọn bàn
            lblInvoiceTitle.Text = "Hóa đơn: " + _selectedTableName;

            // Highlight nút vừa chọn
            foreach (Control c in flpBan.Controls)
            {
                if (c is Button b && b.Tag is DataRow r)
                {
                    UpdateButtonVisual(b, r["TenBan"].ToString(), r["TrangThai"].ToString(), r["ViTri"].ToString(), (int)r["Id"]);
                }
            }

            // Xử lý logic nút chức năng dựa trên trạng thái bàn
            if (trangThai == "Còn trống")
            {
                btnMoBan.Enabled = true;
                btnOrderMon.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyHoaDon.Enabled = false;
                btnChuyenBan.Enabled = false;

                ResetInvoiceUI();
            }
            else
            {
                btnMoBan.Enabled = false;
                btnOrderMon.Enabled = true;
                btnThanhToan.Enabled = true;
                btnHuyHoaDon.Enabled = true;
                btnChuyenBan.Enabled = true;

                // Load hóa đơn của bàn
                LoadInvoiceData(_selectedTableId);
            }
        }

        #endregion

        #region 2. XỬ LÝ HÓA ĐƠN (Load Invoice)

        private void ResetInvoiceUI()
        {
            dgvHoaDon.Rows.Clear();
            lblMaHoaDon.Text = "Mã hóa đơn: --";
            lblThoiGianBatDau.Text = "GIỜ VÀO\n\nNgày: --/--/----\nGiờ: --:--:--";
            lblTongTien.Text = "TỔNG: 0đ";
            lblGiamGia.Text = "Giảm giá: 0%";
        }

        private void LoadInvoiceData(int banID)
        {
            dgvHoaDon.Rows.Clear();

            // 1. Tìm hóa đơn chưa thanh toán của bàn này
            string queryHD = "SELECT * FROM HoaDon WHERE MaBan = @id AND TrangThai = N'Chưa thanh toán'";
            SqlParameter[] paramHD = new SqlParameter[] { new SqlParameter("@id", banID) };

            DataTable dataHD = DataProvider.Instance.ExecuteQuery(queryHD, paramHD);

            if (dataHD.Rows.Count > 0)
            {
                DataRow hd = dataHD.Rows[0];
                int hoaDonId = (int)hd["Id"];
                DateTime ngayLap = (DateTime)hd["NgayLap"];
                decimal giamGia = Convert.ToDecimal(hd["GiamGiaPhanTram"]);
                decimal tongTien = Convert.ToDecimal(hd["TongTien"]);

                lblMaHoaDon.Text = "Mã hóa đơn: #" + hoaDonId;
                lblThoiGianBatDau.Text = $"GIỜ VÀO\n\nNgày: {ngayLap:dd/MM/yyyy}\nGiờ: {ngayLap:HH:mm:ss}";
                lblGiamGia.Text = $"Giảm giá: {giamGia}%";
                lblTongTien.Text = $"TỔNG: {tongTien:N0}đ";

                // 2. Load chi tiết hóa đơn
                string queryCT = @"
                    SELECT c.Id, s.TenSP, c.DonGia, c.SoLuong, c.ThanhTien 
                    FROM ChiTietHoaDon c 
                    JOIN SanPham s ON c.MaSP = s.Id 
                    WHERE c.MaHoaDon = @idHoaDon";

                SqlParameter[] paramCT = new SqlParameter[] { new SqlParameter("@idHoaDon", hoaDonId) };
                DataTable dataCT = DataProvider.Instance.ExecuteQuery(queryCT, paramCT);

                foreach (DataRow item in dataCT.Rows)
                {
                    int index = dgvHoaDon.Rows.Add();
                    dgvHoaDon.Rows[index].Tag = item["Id"]; // Lưu ID chi tiết hóa đơn để xóa/sửa
                    dgvHoaDon.Rows[index].Cells[0].Value = item["Id"]; // Cột ẩn
                    dgvHoaDon.Rows[index].Cells[1].Value = item["TenSP"];
                    dgvHoaDon.Rows[index].Cells[2].Value = Convert.ToDecimal(item["DonGia"]).ToString("N0");
                    dgvHoaDon.Rows[index].Cells[3].Value = item["SoLuong"];
                    dgvHoaDon.Rows[index].Cells[4].Value = Convert.ToDecimal(item["ThanhTien"]).ToString("N0");
                }
            }
        }

        // Click grid để hiện số lượng lên NumericUpDown
        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHoaDon.CurrentRow != null)
            {
                if (dgvHoaDon.CurrentRow.Cells[3].Value != null)
                {
                    decimal sl = Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells[3].Value);
                    nudQuantity.Value = sl;
                }
            }
        }

        #endregion

        #region 3. CÁC CHỨC NĂNG CHÍNH

        private void BtnMoBan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) return;

            // Kiểm tra trạng thái
            string queryCheck = "SELECT TrangThai FROM Ban WHERE Id = @id";
            object checkStatus = DataProvider.Instance.ExecuteScalar(queryCheck, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

            if (checkStatus != null && checkStatus.ToString() == "Có người")
            {
                MessageBox.Show("Bàn này đã có người ngồi rồi!", "Thông báo");
                LoadTables();
                return;
            }

            // 1. Cập nhật trạng thái bàn
            string queryUpBan = "UPDATE Ban SET TrangThai = N'Có người' WHERE Id = @id";
            DataProvider.Instance.ExecuteNonQuery(queryUpBan, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

            // 2. Tạo hóa đơn mới (Giả sử MaNhanVien = 1 - Admin)
            string queryInsertHD = @"INSERT INTO HoaDon (MaBan, MaNhanVien, NgayLap, TongTien, TrangThai) 
                                     VALUES (@ban, 1, GETDATE(), 0, N'Chưa thanh toán')";
            DataProvider.Instance.ExecuteNonQuery(queryInsertHD, new SqlParameter[] { new SqlParameter("@ban", _selectedTableId) });

            LoadTables();
            // Tự động load lại hóa đơn
            LoadInvoiceData(_selectedTableId);

            btnMoBan.Enabled = false;
            btnOrderMon.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void btnOrderMon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thêm món!");
                return;
            }

            // Mở Form Order (Bạn cần tạo form này)
            // fOrder frm = new fOrder(_selectedTableId); 
            // if (frm.ShowDialog() == DialogResult.OK)
            // {
            //     UpdateTotalMoney(_selectedTableId);
            //     LoadInvoiceData(_selectedTableId);
            // }
            MessageBox.Show("Chức năng này cần Form fOrder. Vui lòng tạo form Order và gọi tại đây.", "Thông báo");
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null || dgvHoaDon.CurrentRow.Tag == null)
            {
                MessageBox.Show("Chọn món cần sửa số lượng!");
                return;
            }

            int idChiTiet = (int)dgvHoaDon.CurrentRow.Tag;
            int soLuongMoi = (int)nudQuantity.Value;

            string query = "UPDATE ChiTietHoaDon SET SoLuong = @sl WHERE Id = @id";
            DataProvider.Instance.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@sl", soLuongMoi),
                new SqlParameter("@id", idChiTiet)
            });

            UpdateTotalMoney(_selectedTableId);
            LoadInvoiceData(_selectedTableId);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null || dgvHoaDon.CurrentRow.Tag == null) return;

            if (MessageBox.Show("Bạn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idChiTiet = (int)dgvHoaDon.CurrentRow.Tag;

                string query = "DELETE FROM ChiTietHoaDon WHERE Id = @id";
                DataProvider.Instance.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@id", idChiTiet) });

                UpdateTotalMoney(_selectedTableId);
                LoadInvoiceData(_selectedTableId);
            }
        }

        private void UpdateTotalMoney(int banId)
        {
            // Lấy ID hóa đơn
            string qGetID = "SELECT Id FROM HoaDon WHERE MaBan = @id AND TrangThai = N'Chưa thanh toán'";
            object objId = DataProvider.Instance.ExecuteScalar(qGetID, new SqlParameter[] { new SqlParameter("@id", banId) });

            if (objId != null)
            {
                int hdId = Convert.ToInt32(objId);

                // Tính tổng tiền chi tiết (này tạo cái trigger)
                string qSum = "SELECT SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHoaDon = @hdId";
                object objSum = DataProvider.Instance.ExecuteScalar(qSum, new SqlParameter[] { new SqlParameter("@hdId", hdId) });
                decimal tong = (objSum != DBNull.Value && objSum != null) ? Convert.ToDecimal(objSum) : 0;

                // Cập nhật lại hóa đơn
                string qUpdate = "UPDATE HoaDon SET TongTien = @tong WHERE Id = @id";
                DataProvider.Instance.ExecuteNonQuery(qUpdate, new SqlParameter[]
                {
                    new SqlParameter("@tong", tong),
                    new SqlParameter("@id", hdId)
                });
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) return;

            string txtTong = lblTongTien.Text.Replace("TỔNG:", "").Replace("đ", "").Replace(",", "").Trim();
            decimal tongTien = 0;
            decimal.TryParse(txtTong, out tongTien);

            if (MessageBox.Show($"Thanh toán hóa đơn cho bàn {_selectedTableName}?\nTổng tiền: {tongTien:N0}đ",
                "Xác nhận thanh toán", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // 1. Update Hóa đơn
                string qHD = "UPDATE HoaDon SET TrangThai = N'Đã thanh toán', TongTien = @tien WHERE MaBan = @ban AND TrangThai = N'Chưa thanh toán'";
                DataProvider.Instance.ExecuteNonQuery(qHD, new SqlParameter[]
                {
                    new SqlParameter("@tien", tongTien),
                    new SqlParameter("@ban", _selectedTableId)
                });

                // 2. Update Bàn -> Trống
                string qBan = "UPDATE Ban SET TrangThai = N'Còn trống' WHERE Id = @id";
                DataProvider.Instance.ExecuteNonQuery(qBan, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

                MessageBox.Show("Thanh toán thành công!", "Thông báo");
                LoadTables();
                ResetInvoiceUI();
                _selectedTableId = -1;
            }
        }

        private void BtnChuyenBan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) return;
            MessageBox.Show("Cần tạo form fChuyenBan để thực hiện chức năng này.", "Thông báo");
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) return;

            if (MessageBox.Show($"Bạn có chắc muốn hủy bàn {_selectedTableName}?\nHóa đơn hiện tại sẽ bị xóa!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string qGetID = "SELECT Id FROM HoaDon WHERE MaBan = @id AND TrangThai = N'Chưa thanh toán'";
                object objId = DataProvider.Instance.ExecuteScalar(qGetID, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

                if (objId != null)
                {
                    int hdId = Convert.ToInt32(objId);

                    DataProvider.Instance.ExecuteNonQuery("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @hdId", new SqlParameter[] { new SqlParameter("hdId", hdId) });
                    DataProvider.Instance.ExecuteNonQuery("DELETE FROM HoaDon WHERE Id = @hdId", new SqlParameter[] { new SqlParameter("hdId", hdId) });
                    DataProvider.Instance.ExecuteNonQuery("UPDATE Ban SET TrangThai = N'Còn trống' WHERE Id = @id", new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

                    LoadTables();
                    ResetInvoiceUI();
                    MessageBox.Show("Đã hủy bàn thành công.");
                }
            }
        }

        #endregion

        private void UpdateDateTime()
        {
            lblNgayHienTai.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy | HH:mm:ss");
        }

        private void tsmiDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}