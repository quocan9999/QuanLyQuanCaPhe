using QuanLyQuanCaPhe.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyNhanVien : Form
    {
        private DataProvider dataProvider;
        private int selectedNhanVienId = -1;

        public fQuanLyNhanVien()
        {
            InitializeComponent();
            dataProvider = DataProvider.Instance;
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
            SetDefaultValues();
        }

        // Load danh sách nhân viên từ database
        private void LoadDanhSachNhanVien()
        {
            try
            {
                string query = @"SELECT nv.Id, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.SDT, nv.Email, 
                                nv.DiaChi, nv.Luong, nv.TenDangNhap, nv.TrangThai 
                                FROM NhanVien nv ORDER BY nv.Id";
                DataTable dt = dataProvider.ExecuteQuery(query);
                dgvNhanVien.DataSource = dt;

                if (dgvNhanVien.Columns.Count > 0)
                {
                    dgvNhanVien.Columns["Id"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["HoTen"].HeaderText = "Họ tên";
                    dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvNhanVien.Columns["SDT"].HeaderText = "Số điện thoại";
                    dgvNhanVien.Columns["Email"].HeaderText = "Email";
                    dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvNhanVien.Columns["Luong"].HeaderText = "Lương";
                    dgvNhanVien.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvNhanVien.Columns["TrangThai"].HeaderText = "Trạng thái";

                    // Định dạng cột lương
                    dgvNhanVien.Columns["Luong"].DefaultCellStyle.Format = "N0";
                    dgvNhanVien.Columns["Luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đặt giá trị mặc định cho các controls
        private void SetDefaultValues()
        {
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-20);
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            nudLuong.Value = 0;
            txtTenDangNhap.Clear();
            txtTrangThai.Clear();
            selectedNhanVienId = -1;

            // Disable các control cho đến khi chọn nhân viên
            SetControlsEnabled(false);
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtHoTen.Enabled = enabled;
            cboGioiTinh.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            nudLuong.Enabled = enabled;
            
            // Tên đăng nhập và trạng thái không được sửa
            txtTenDangNhap.Enabled = false;
            txtTrangThai.Enabled = false;
            
            btnSua.Enabled = enabled;
        }

        // Xác thực dữ liệu nhập vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            if (dtpNgaySinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            return true;
        }

        // Sự kiện click vào cell trong DataGridView
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                selectedNhanVienId = Convert.ToInt32(row.Cells["Id"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                nudLuong.Value = Convert.ToDecimal(row.Cells["Luong"].Value);
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();

                // Bật các control để sửa
                SetControlsEnabled(true);
            }
        }

        // Sửa thông tin nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedNhanVienId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                // Kiểm tra trùng SĐT
                string queryCheckSDT = "SELECT COUNT(*) FROM NhanVien WHERE SDT = @SDT AND Id != @Id";
                object resultSDT = dataProvider.ExecuteScalar(queryCheckSDT, new SqlParameter[]
                {
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@Id", selectedNhanVienId)
                });
                if (Convert.ToInt32(resultSDT) > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                // Kiểm tra trùng Email
                string queryCheckEmail = "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email AND Id != @Id";
                object resultEmail = dataProvider.ExecuteScalar(queryCheckEmail, new SqlParameter[]
                {
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@Id", selectedNhanVienId)
                });
                if (Convert.ToInt32(resultEmail) > 0)
                {
                    MessageBox.Show("Email đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                // Cập nhật thông tin nhân viên
                string query = @"UPDATE NhanVien SET 
                                HoTen = @HoTen, 
                                GioiTinh = @GioiTinh, 
                                NgaySinh = @NgaySinh, 
                                SDT = @SDT, 
                                Email = @Email, 
                                DiaChi = @DiaChi, 
                                Luong = @Luong 
                                WHERE Id = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                    new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                    new SqlParameter("@Luong", nudLuong.Value),
                    new SqlParameter("@Id", selectedNhanVienId)
                };

                int result = dataProvider.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                    SetDefaultValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetDefaultValues();
            txtTimKiem.Clear();
            LoadDanhSachNhanVien();
        }

        // Tìm kiếm nhân viên
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDanhSachNhanVien();
                    return;
                }

                string query = @"SELECT nv.Id, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.SDT, nv.Email, 
                                nv.DiaChi, nv.Luong, nv.TenDangNhap, nv.TrangThai 
                                FROM NhanVien nv 
                                WHERE nv.HoTen LIKE @SearchText 
                                OR nv.SDT LIKE @SearchText 
                                OR nv.Email LIKE @SearchText 
                                OR nv.TenDangNhap LIKE @SearchText
                                ORDER BY nv.Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchText", "%" + searchText + "%")
                };

                DataTable dt = dataProvider.ExecuteQuery(query, parameters);
                dgvNhanVien.DataSource = dt;

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
