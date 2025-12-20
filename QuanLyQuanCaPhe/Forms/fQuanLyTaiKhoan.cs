using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyTaiKhoan : Form
    {
        private DataProvider dataProvider;
        private string selectedTenDangNhap = "";

        public fQuanLyTaiKhoan()
        {
            try
            {
                InitializeComponent();
                dataProvider = DataProvider.Instance;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region KHỞI TẠO VÀ TẢI FORM

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                if (dataProvider == null) { MessageBox.Show("DataProvider chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (!dataProvider.TestConnection()) { MessageBox.Show("Không thể kết nối đến database.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                LoadDanhSachNguoiDung();
                SetDefaultValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = 1;
            cboTrangThai.SelectedIndex = 0;
            dtpNgayTao.Value = DateTime.Now;
            selectedTenDangNhap = "";
            txtTenDangNhap.ReadOnly = false;
            cboVaiTro.Enabled = true;
            cboTrangThai.Enabled = true;
            cboVaiTro.BackColor = SystemColors.Window;
            cboTrangThai.BackColor = SystemColors.Window;
        }

        #endregion

        #region TẢI DỮ LIỆU

        private void LoadDanhSachNguoiDung()
        {
            try
            {
                string query = "SELECT TenDangNhap, MatKhau, VaiTro, NgayTao, TrangThai FROM NguoiDung ORDER BY NgayTao DESC";
                DataTable dt = dataProvider.ExecuteQuery(query);
                dgvNguoiDung.DataSource = dt;

                if (dgvNguoiDung.Columns.Count > 0)
                {
                    dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvNguoiDung.Columns["MatKhau"].HeaderText = "Mật khẩu";
                    dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
                    dgvNguoiDung.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvNguoiDung.Columns["MatKhau"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) { MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text)) { MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (txtMatKhau.Text.Length < 6) { MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cboVaiTro.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cboTrangThai.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        #endregion

        #region CHỌN TÀI KHOẢN

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];
                selectedTenDangNhap = row.Cells["TenDangNhap"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cboVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                txtTenDangNhap.ReadOnly = false;
                cboVaiTro.Enabled = true;
                cboTrangThai.Enabled = true;
            }
        }

        #endregion

        #region THÊM TÀI KHOẢN

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, NgayTao, TrangThai) VALUES (@TenDangNhap, @MatKhau, @VaiTro, @NgayTao, @TrangThai)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim()),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@VaiTro", cboVaiTro.Text),
                    new SqlParameter("@NgayTao", dtpNgayTao.Value),
                    new SqlParameter("@TrangThai", cboTrangThai.Text)
                };
                int result = dataProvider.ExecuteNonQuery(query, parameters);
                if (result > 0) { MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadDanhSachNguoiDung(); SetDefaultValues(); }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region SỬA TÀI KHOẢN

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTenDangNhap)) { MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateInput()) return;

            try
            {
                string queryGetOldStatus = "SELECT TrangThai FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
                object oldStatusObj = dataProvider.ExecuteScalar(queryGetOldStatus, new SqlParameter[] { new SqlParameter("@TenDangNhap", selectedTenDangNhap) });
                string trangThaiCu = oldStatusObj?.ToString() ?? "";
                string trangThaiMoi = cboTrangThai.Text;

                string query = "UPDATE NguoiDung SET TenDangNhap = @TenDangNhapMoi, MatKhau = @MatKhau, VaiTro = @VaiTro, TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhapCu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhapCu", selectedTenDangNhap),
                    new SqlParameter("@TenDangNhapMoi", txtTenDangNhap.Text.Trim()),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@VaiTro", cboVaiTro.Text),
                    new SqlParameter("@TrangThai", trangThaiMoi)
                };

                int result = dataProvider.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    if (trangThaiCu != trangThaiMoi)
                    {
                        string trangThaiNhanVien = trangThaiMoi == "Đã khóa" ? "Đã nghỉ việc" : (trangThaiMoi == "Hoạt động" ? "Hoạt động" : "");
                        if (!string.IsNullOrEmpty(trangThaiNhanVien))
                        {
                            string queryUpdateNV = "UPDATE NhanVien SET TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhap";
                            dataProvider.ExecuteNonQuery(queryUpdateNV, new SqlParameter[] { new SqlParameter("@TrangThai", trangThaiNhanVien), new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim()) });
                        }
                    }
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNguoiDung();
                    SetDefaultValues();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Tên đăng nhập mới đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region XÓA TÀI KHOẢN

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTenDangNhap)) { MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa nhân viên liên kết trước
                    string queryDeleteNhanVien = "DELETE FROM NhanVien WHERE TenDangNhap = @TenDangNhap";
                    dataProvider.ExecuteNonQuery(queryDeleteNhanVien, new SqlParameter[] { new SqlParameter("@TenDangNhap", selectedTenDangNhap) });

                    // Sau đó xóa tài khoản
                    string query = "DELETE FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@TenDangNhap", selectedTenDangNhap) };
                    int result = dataProvider.ExecuteNonQuery(query, parameters);
                    if (result > 0) { MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadDanhSachNguoiDung(); SetDefaultValues(); }
                }
                catch (Exception ex)
                {
                    SqlException sqlEx = ex.InnerException as SqlException;
                    if (sqlEx != null && sqlEx.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa tài khoản này vì nhân viên này đã từng lập hóa đơn, chỉ có thể vô hiệu hóa tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("FK_"))
                    {
                        MessageBox.Show("Không thể xóa tài khoản này vì nhân viên này đã từng lập hóa đơn, chỉ có thể vô hiệu hóa tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region TÌM KIẾM & LÀM MỚI

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetDefaultValues();
            txtTimKiem.Clear();
            LoadDanhSachNguoiDung();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchText)) { LoadDanhSachNguoiDung(); return; }
                string query = "SELECT TenDangNhap, MatKhau, VaiTro, NgayTao, TrangThai FROM NguoiDung WHERE TenDangNhap LIKE @SearchText OR VaiTro LIKE @SearchText OR TrangThai LIKE @SearchText";
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@SearchText", "%" + searchText + "%") };
                DataTable dt = dataProvider.ExecuteQuery(query, parameters);
                dgvNguoiDung.DataSource = dt;
                if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
    }
}
