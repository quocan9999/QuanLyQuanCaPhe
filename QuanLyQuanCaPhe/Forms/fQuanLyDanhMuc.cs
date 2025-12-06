
using QuanLyQuanCaPhe.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Forms
{
    public partial class fQuanLyDanhMuc : Form
    {
        private string connectionString = "Server=.;Database=QuanLyCaPhe;Trusted_Connection=True;";
        private SqlConnection sqlCon = null;
        private bool isAdding = false;
        private bool isEditing = false;

        public fQuanLyDanhMuc()
        {
            InitializeComponent();
        }
        private void LockControls(bool lockState)
        {
            grvDanhMuc.Enabled = !lockState;   // Khóa chọn dòng
        }

        private void fQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            txtID.ReadOnly = true;
            txtDanhMuc.Text = "";
        }

        private List<DanhMuc> GetListDanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string query = "SELECT * FROM DanhMuc ORDER BY Id ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                foreach (DataRow item in data.Rows)
                {
                    DanhMuc dm = new DanhMuc(item);
                    list.Add(dm);
                }
            }
            return list;
        }

        private void LoadListDanhMuc()
        {
            grvDanhMuc.DataSource = GetListDanhMuc();
        }

        private void AddDanhMucBinding()
        {
            txtID.DataBindings.Clear();
            txtDanhMuc.DataBindings.Clear();
            txtID.DataBindings.Add("Text", grvDanhMuc.DataSource, "Id");
            txtDanhMuc.DataBindings.Add("Text", grvDanhMuc.DataSource, "TenDanhMuc");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListDanhMuc();
            AddDanhMucBinding();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                // Clear binding và input để chuẩn bị thêm mới
                txtID.DataBindings.Clear();
                txtDanhMuc.DataBindings.Clear();
                txtID.Text = "";
                txtDanhMuc.Text = "";
                txtDanhMuc.Focus();
                isAdding = true;
                btnThem.Text = "Lưu";
                return;
            }

            string tenDanhMuc = txtDanhMuc.Text.Trim();
            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                MessageBox.Show("Tên danh mục không được để trống.");
                return;
            }
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            // Kiểm tra trùng tên
            string checkQuery = "SELECT COUNT(*) FROM DanhMuc WHERE TenDanhMuc = @TenDanhMuc";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlCon))
            {
                checkCmd.Parameters.AddWithValue("@TenDanhMuc", tenDanhMuc);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tên danh mục đã tồn tại. Vui lòng nhập tên khác.");
                    return;
                }
            }
            string query = "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@TenDanhMuc)";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@TenDanhMuc", tenDanhMuc);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm danh mục thành công.");
                    LoadListDanhMuc();
                    AddDanhMucBinding();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm danh mục.");
                }
            }
            isAdding = false;
            btnThem.Text = "Thêm";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Nếu chưa vào chế độ sửa → chuyển sang chế độ sửa
            if (!isEditing)
            {
                if (!int.TryParse(txtID.Text.Trim(), out int id))
                {
                    MessageBox.Show("Vui lòng chọn một Danh mục để sửa.", "Lỗi ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isEditing = true;
                LockControls(true);
                btnSua.Text = "Lưu";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }

            // Đang trong chế độ sửa → thực hiện lưu
            if (!int.TryParse(txtID.Text.Trim(), out int idUpdate))
            {
                MessageBox.Show("ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenDanhMucMoi = txtDanhMuc.Text.Trim();
            if (string.IsNullOrEmpty(tenDanhMucMoi))
            {
                MessageBox.Show("Tên Danh mục không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

            string query = "UPDATE DanhMuc SET TenDanhMuc = @TenDanhMuc WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@TenDanhMuc", tenDanhMucMoi);
                cmd.Parameters.AddWithValue("@Id", idUpdate);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Sửa danh mục thành công.");

                    LoadListDanhMuc();
                    AddDanhMucBinding();

                    // Thoát chế độ sửa
                    isEditing = false;
                    LockControls(false);
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text.Trim(), out int id))
            {
                MessageBox.Show("Vui lòng chọn một Danh mục để xóa (ID không hợp lệ).", "Lỗi ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;
            if (sqlCon == null) sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string query = "DELETE FROM DanhMuc WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Xóa danh mục thành công.");
                    LoadListDanhMuc();
                    AddDanhMucBinding();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại hoặc danh mục không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
