using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class QuanLyTaiKhoan : Form
    {
        private DataProvider dataProvider;
        private string selectedTenDangNhap = "";

        public QuanLyTaiKhoan()
        {
            try
            {
                InitializeComponent();
                dataProvider = DataProvider.Instance;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message + "\n\n" + ex.StackTrace,
               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dataProvider đã được khởi tạo chưa
                if (dataProvider == null)
                {
                    MessageBox.Show("DataProvider chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra kết nối trước
                if (!dataProvider.TestConnection())
                {
                    MessageBox.Show("Không thể kết nối đến database. \n",
                       "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadDanhSachNguoiDung();
                SetDefaultValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message + "\n\n" + ex.StackTrace,
           "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách người dùng từ database
        private void LoadDanhSachNguoiDung()
        {
            try
            {
                string query = "SELECT TenDangNhap, MatKhau, VaiTro, NgayTao, TrangThai FROM NguoiDung ORDER BY NgayTao DESC";
                DataTable dt = dataProvider.ExecuteQuery(query);
                dgvNguoiDung.DataSource = dt;

                // Đặt tên cột tiếng Việt
                if (dgvNguoiDung.Columns.Count > 0)
                {
                    dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvNguoiDung.Columns["MatKhau"].HeaderText = "Mật khẩu";
                    dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
                    dgvNguoiDung.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái";

                    // Ẩn mật khẩu
                    dgvNguoiDung.Columns["MatKhau"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đặt giá trị mặc định cho các controls
        private void SetDefaultValues()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = 1; // Mặc định: Nhân viên (chỉ khi tạo mới)
            cboTrangThai.SelectedIndex = 0; // Mặc định: Hoạt động
            dtpNgayTao.Value = DateTime.Now;
            selectedTenDangNhap = "";
            txtTenDangNhap.ReadOnly = false;

            // Bật lại tất cả controls
            cboVaiTro.Enabled = true;
            cboTrangThai.Enabled = true;
            cboVaiTro.BackColor = SystemColors.Window;
            cboTrangThai.BackColor = SystemColors.Window;
        }

        // Xác thực dữ liệu nhập vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            if (txtMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            if (cboVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVaiTro.Focus();
                return false;
            }

            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }

            return true;
        }

        // Sự kiện click vào cell trong DataGridView
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

                // Cho phép sửa tất cả các trường
                txtTenDangNhap.ReadOnly = false;
                cboVaiTro.Enabled = true;
                cboTrangThai.Enabled = true;
                cboVaiTro.BackColor = SystemColors.Window;
                cboTrangThai.BackColor = SystemColors.Window;
            }
        }

        // Thêm tài khoản mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

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
                if (result > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNguoiDung();
                    SetDefaultValues();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Primary key violation
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa thông tin tài khoản
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTenDangNhap))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                // Cập nhật TenDangNhap, MatKhau, VaiTro và TrangThai
                string query = "UPDATE NguoiDung SET TenDangNhap = @TenDangNhapMoi, MatKhau = @MatKhau, VaiTro = @VaiTro, TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhapCu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhapCu", selectedTenDangNhap),
                    new SqlParameter("@TenDangNhapMoi", txtTenDangNhap.Text.Trim()),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@VaiTro", cboVaiTro.Text),
                    new SqlParameter("@TrangThai", cboTrangThai.Text)
                };

                int result = dataProvider.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNguoiDung();
                    SetDefaultValues();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Primary key violation
                {
                    MessageBox.Show("Tên đăng nhập mới đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa tài khoản
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTenDangNhap))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TenDangNhap", selectedTenDangNhap)
                    };

                    int result = dataProvider.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNguoiDung();
                        SetDefaultValues();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetDefaultValues();
            txtTimKiem.Clear();
            LoadDanhSachNguoiDung();
        }

        // Tìm kiếm tài khoản
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDanhSachNguoiDung();
                    return;
                }

                string query = "SELECT TenDangNhap, MatKhau, VaiTro, NgayTao, TrangThai FROM NguoiDung WHERE TenDangNhap LIKE @SearchText OR VaiTro LIKE @SearchText OR TrangThai LIKE @SearchText";
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@SearchText", "%" + searchText + "%")
                };

                DataTable dt = dataProvider.ExecuteQuery(query, parameters);
                dgvNguoiDung.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
