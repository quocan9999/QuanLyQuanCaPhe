using QuanLyQuanCaPhe.Class;
using QuanLyQuanCaPhe.Forms;
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

            lblTenNhanVien.Text = "Nhân viên: " + LuuTruThongTinDangNhap.HoTen + " (" + LuuTruThongTinDangNhap.VaiTro + ")";

        }

        private void SetupEventHandlers()
        {
            // Sự kiện bộ lọc
            cboLocKhuVuc.SelectedIndexChanged += (s, e) => LoadTables();

            // Sự kiện grid
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;

            // Timer cập nhật ngày giờ
            timer1.Tick += (s, e) => UpdateDateTime();
        }

        #region 1. QUẢN LÝ BÀN & HIỂN THỊ

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
            lblTrangThaiThanhToan.Text = "Trạng thái: --";
            lblTrangThaiThanhToan.ForeColor = Color.DimGray;
        }

        private void LoadInvoiceData(int banID)
        {
            dgvHoaDon.Rows.Clear();

            // 1. tìm hóa đơn chưa thanh toán của bàn này
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
                string trangThai = hd["TrangThai"].ToString(); // lấy trạng thái từ csdl

                lblMaHoaDon.Text = "Mã hóa đơn: #" + hoaDonId;
                lblThoiGianBatDau.Text = $"GIỜ VÀO\n\nNgày: {ngayLap:dd/MM/yyyy}\nGiờ: {ngayLap:HH:mm:ss}";
                lblTongTien.Text = $"TỔNG: {tongTien:N0}đ";

                // hiển thị trạng thái
                lblTrangThaiThanhToan.Text = "Trạng thái: " + trangThai;
                if (trangThai == "Chưa thanh toán")
                {
                    lblTrangThaiThanhToan.ForeColor = Color.Red;
                }
                else
                {
                    lblTrangThaiThanhToan.ForeColor = Color.Green;
                }

                // 2. load chi tiết hóa đơn
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
                    dgvHoaDon.Rows[index].Tag = item["Id"];
                    dgvHoaDon.Rows[index].Cells[0].Value = item["Id"];
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

            // kiểm tra xem bàn có người chưa (đề phòng 2 máy cùng thao tác)
            string queryCheck = "SELECT TrangThai FROM Ban WHERE Id = @id";
            object checkStatus = DataProvider.Instance.ExecuteScalar(queryCheck, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

            if (checkStatus != null && checkStatus.ToString() == "Có người")
            {
                MessageBox.Show("Bàn này đã có người ngồi rồi!", "Thông báo");
                LoadTables();
                return;
            }

            // lấy id nhân viên đang đăng nhập để gán vào người lập hóa đơn
            int idNhanVien = LayIdNhanVienHienTai();

            if (idNhanVien == -1)
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên của tài khoản này!", "Lỗi");
                return;
            }

            // tạo hóa đơn mới - trigger sẽ tự động chuyển trạng thái bàn sang 'có người'
            string queryInsertHD = @"INSERT INTO HoaDon (MaBan, NguoiLap, NgayLap, TongTien, TrangThai) VALUES (@ban, @nguoiLap, GETDATE(), 0, N'Chưa thanh toán')";

            DataProvider.Instance.ExecuteNonQuery(queryInsertHD, new SqlParameter[] { new SqlParameter("@ban", _selectedTableId), new SqlParameter("@nguoiLap", idNhanVien) });

            LoadTables(); // load lại để thấy bàn đổi màu xanh

            // tự động load lại giao diện hóa đơn
            LoadInvoiceData(_selectedTableId);

            // cập nhật trạng thái nút bấm
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

            fOrder f = new fOrder(_selectedTableId);
            if (f.ShowDialog() == DialogResult.OK)
            {
                UpdateTotalMoney(_selectedTableId);
                LoadInvoiceData(_selectedTableId);
            }
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
            // 1. kiểm tra xem đã chọn bàn chưa
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. khởi tạo form thanh toán và truyền id bàn sang
            fThanhToan formThanhToan = new fThanhToan(_selectedTableId);

            // 3. hiển thị form và chờ kết quả trả về
            if (formThanhToan.ShowDialog() == DialogResult.OK)
            {
                // nếu thanh toán thành công (bên kia trả về OK):

                // tải lại danh sách bàn để cập nhật màu sắc (bàn chuyển từ xanh sang xám)
                LoadTables();

                // xóa sạch thông tin hóa đơn đang hiển thị bên phải màn hình
                ResetInvoiceUI();

                // đặt lại trạng thái về mặc định
                _selectedTableId = -1;
                lblInvoiceTitle.Text = "Hóa đơn bàn --";

                // vô hiệu hóa các nút chức năng để tránh lỗi
                btnMoBan.Enabled = false;
                btnOrderMon.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyHoaDon.Enabled = false;
                btnChuyenBan.Enabled = false;
            }
        }

        private void BtnChuyenBan_Click(object sender, EventArgs e)
        {
            // kiểm tra xem người dùng đã chọn bàn chưa
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // khởi tạo form chuyển bàn và truyền id bàn hiện tại (bàn cũ) sang
            fChuyenBan formChuyenBan = new fChuyenBan(_selectedTableId);

            // hiển thị form dưới dạng hộp thoại (dialog) và chờ kết quả
            if (formChuyenBan.ShowDialog() == DialogResult.OK)
            {
                // nếu chuyển bàn thành công:

                // 1. tải lại danh sách bàn để cập nhật màu sắc (bàn cũ thành xám, bàn mới thành xanh)
                LoadTables();

                // 2. xóa thông tin hóa đơn đang hiển thị bên phải (vì bàn cũ giờ đã trống)
                ResetInvoiceUI();

                // 3. đặt lại trạng thái lựa chọn về mặc định để tránh nhầm lẫn
                _selectedTableId = -1;
                lblInvoiceTitle.Text = "Hóa đơn bàn --";

                // 4. vô hiệu hóa các nút chức năng (vì chưa chọn lại bàn nào)
                btnMoBan.Enabled = false;
                btnOrderMon.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyHoaDon.Enabled = false;
                btnChuyenBan.Enabled = false;
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) return;

            if (MessageBox.Show($"Bạn có chắc muốn hủy bàn {_selectedTableName}?\nHóa đơn hiện tại sẽ bị xóa!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // lấy id hóa đơn để xóa chi tiết trước
                string queryGetID = "SELECT Id FROM HoaDon WHERE MaBan = @id AND TrangThai = N'Chưa thanh toán'";
                object objId = DataProvider.Instance.ExecuteScalar(queryGetID, new SqlParameter[] { new SqlParameter("@id", _selectedTableId) });

                if (objId != null)
                {
                    int hdId = Convert.ToInt32(objId);

                    // xóa chi tiết hóa đơn
                    DataProvider.Instance.ExecuteNonQuery("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @hdId", new SqlParameter[] { new SqlParameter("hdId", hdId) });

                    // xóa hóa đơn
                    // trigger sql sẽ bắt sự kiện delete này để cập nhật bàn về trạng thái 'còn trống'
                    DataProvider.Instance.ExecuteNonQuery("DELETE FROM HoaDon WHERE Id = @hdId", new SqlParameter[] { new SqlParameter("hdId", hdId) });

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
            DialogResult thongBaoDangXuat = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongBaoDangXuat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tsmiQuanLyBan_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fQuanLyBan f = new fQuanLyBan();
                f.ShowDialog();
                LoadComboBoxKhuVuc();
                LoadTables();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tmsiQuanLySanPham_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fQuanLySanPham f = new fQuanLySanPham();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fQuanLyDanhMuc f = new fQuanLyDanhMuc();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fQuanLyTaiKhoan f = new fQuanLyTaiKhoan();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiBaoCaoBanChay_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fBaoCaoBanChay f = new fBaoCaoBanChay();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            if (LuuTruThongTinDangNhap.VaiTro == "Admin")
            {
                fBaoCaoDoanhThu f = new fBaoCaoDoanhThu();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // hàm hỗ trợ lấy id nhân viên dựa trên tên đăng nhập hiện tại
        private int LayIdNhanVienHienTai()
        {
            // lấy tên đăng nhập từ biến toàn cục đã lưu lúc login
            string tenDangNhap = LuuTruThongTinDangNhap.TenDangNhap;

            // truy vấn lấy id nhân viên
            string queryGetId = "SELECT Id FROM NhanVien WHERE TenDangNhap = @user";
            object ketQua = DataProvider.Instance.ExecuteScalar(queryGetId, new SqlParameter[] { new SqlParameter("@user", tenDangNhap) });

            if (ketQua != null)
            {
                return Convert.ToInt32(ketQua);
            }

            // trường hợp không tìm thấy (ví dụ admin hệ thống không có trong bảng nhân viên)
            // trả về 1 hoặc xử lý tùy logic, ở đây mình mặc định trả về null hoặc báo lỗi
            return -1;
        }
    }
}